using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using eShopSolution.ApiIntegration;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Constants;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Sales;
using eShopSolution.ViewModels.System.Users;
using eShopSolution.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eShopSolution.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IOrderApiClient _orderApiClient;
        private readonly IUserApiClient _userApiClient;
        public CartController(IProductApiClient productApiClient, IOrderApiClient orderApiClient, IUserApiClient userApiClient)
        {
            _productApiClient = productApiClient;
            _orderApiClient = orderApiClient;
            _userApiClient = userApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View(GetCheckoutViewModel());
        }
        [HttpGet]
        public async Task<IActionResult> Tt1(string usr, int idpro)
        {
            TempData["idpro"] = idpro;
            var userId = await _userApiClient.GetIdByUserName(usr);
            return View(new UserVm
            {
                FirstName = userId.ResultObj.FirstName,
                LastName = userId.ResultObj.LastName,
                PhoneNumber = userId.ResultObj.PhoneNumber,
                Email = userId.ResultObj.Email,
                Pro = idpro,
            });
        }
        public async Task<IActionResult> Tt2()
        {
            int id = Convert.ToInt32(TempData["idpro"].ToString());
            var product = await _productApiClient.GetById(id, "vi");
            return View(new ProductDetailViewModel()
            {
                Product = product
            });
        }
        public IActionResult Successtt()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Book()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Book(ProductVm request)
        {
            var userId = await _userApiClient.GetIdByUserName(request.UserName ??= "admin");
            string temp = userId.ResultObj.Id.ToString();
            var checkoutRequest = new ProductVm()
            {
                Addr = "Đông Hưng - Hà Nội",
                Cmnd = request.Cmnd,
                Id = request.Id,
                UserId = new Guid(temp),
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                DateCreated = DateTime.Now
            };
            await _orderApiClient.CreateOrder(checkoutRequest);

            HttpContext.Session.Remove(SystemConstants.CartSession);

            return RedirectToAction("Tt1", "Cart", new { usr = request.UserName, idpro = request.Id });
        }
        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel request)
        {
            var model = GetCheckoutViewModel();
            var orderDetails = new List<OrderDetailVm>();
            foreach (var item in model.CartItems)
            {
                orderDetails.Add(new OrderDetailVm()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                });
            }
            var checkoutRequest = new CheckoutRequest()
            {
                Address = request.CheckoutModel.Address,
                Name = request.CheckoutModel.Name,
                Email = request.CheckoutModel.Email,
                PhoneNumber = request.CheckoutModel.PhoneNumber,
                OrderDetails = orderDetails
            };
            //TODO: Add to API
            TempData["SuccessMsg"] = "Order puschased successful";
            return View(model);
        }

        [HttpGet]
        public IActionResult GetListItems()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            return Ok(currentCart);
        }

        public async Task<IActionResult> AddToCart(int id, string languageId)
        {
            var product = await _productApiClient.GetById(id, languageId);

            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);

            int quantity = 1;
            if (currentCart.Any(x => x.ProductId == id))
            {
                quantity = currentCart.First(x => x.ProductId == id).Quantity + 1;
            }

            var cartItem = new CartItemViewModel()
            {
                ProductId = id,
                Description = product.Description,
                Image = product.ThumbnailImage,
                Name = product.Name,
                Price = product.Price,
                Quantity = quantity
            };

            currentCart.Add(cartItem);

            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
            return Ok(currentCart);
        }

        public IActionResult UpdateCart(int id, int quantity)
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);

            foreach (var item in currentCart)
            {
                if (item.ProductId == id)
                {
                    if (quantity == 0)
                    {
                        currentCart.Remove(item);
                        break;
                    }
                    item.Quantity = quantity;
                }
            }

            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
            return Ok(currentCart);
        }

        private CheckoutViewModel GetCheckoutViewModel()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            var checkoutVm = new CheckoutViewModel()
            {
                CartItems = currentCart,
                CheckoutModel = new CheckoutRequest()
            };
            return checkoutVm;
        }
    }
}