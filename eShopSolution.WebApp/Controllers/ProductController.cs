using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.ApiIntegration;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;

        public ProductController(IProductApiClient productApiClient, ICategoryApiClient categoryApiClient)
        {
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
        }

        public async Task<IActionResult> Detail(int id, string culture)
        {
            TempData["ID"] = id;
            var product = await _productApiClient.GetById(id, culture);
            return View(new ProductDetailViewModel()
            {
                Product = product
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getProducts = await _productApiClient.GetAll();
            return View(new HomeViewModel() { LatestProducts = getProducts });
        }
        [HttpGet]
        public async Task<IActionResult> GetAl()
        {
            var getProducts = await _productApiClient.GetAll();
            return View(new HomeViewModel() { LatestProducts = getProducts });
        }
        [HttpGet]
        public async Task<IActionResult> GetAl2()
        {
            var getProducts = await _productApiClient.GetAll();
            return View(new HomeViewModel() { LatestProducts = getProducts });
        }
        [HttpGet]
        public async Task<IActionResult> GetAl3()
        {
            var getProducts = await _productApiClient.GetAll();
            return View(new HomeViewModel() { LatestProducts = getProducts });
        }
        [HttpGet]
        public async Task<IActionResult> GetAl4()
        {
            var getProducts = await _productApiClient.GetAll();
            return View(new HomeViewModel() { LatestProducts = getProducts });
        }

        public IActionResult Services() => View();
        public IActionResult News() => View();
        public IActionResult Intro() => View();
        public IActionResult Contact() => View();

        [HttpGet]
        public async Task<IActionResult> GetAlls(int number, string name)
        {
            name ??= " ";
            var getProducts = await _productApiClient.GetByName(name, number);
            return View(new HomeViewModel() { LatestProducts = getProducts });
        }
        [HttpGet]
        public IActionResult Book()
        {
            return View();
        }
        public async Task<IActionResult> Category(int id, string culture, int page = 1)
        {
            var products = await _productApiClient.GetPagings(new GetManageProductPagingRequest()
            {
                CategoryId = id,
                PageIndex = page,
                LanguageId = culture,
                PageSize = 10
            });
            return View(new ProductCategoryViewModel()
            {
                Category = await _categoryApiClient.GetById(culture, id),
                Products = products
            }); ;
        }
    }
}