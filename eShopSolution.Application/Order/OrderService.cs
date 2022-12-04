using eShopSolution.Application.Catalog.Products;
using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;
using eShopSolution.Utilities.Constants;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Order
{
    public class OrderService : IOrderService
    {
        private readonly EShopDbContext _context;
        private readonly IProductService _productService;
        public OrderService(EShopDbContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }
        public async Task<int> CreateAsync(ProductVm request)
        {
            if (request == null)
                return -1;
            var order = new eShopSolution.Data.Entities.Order()
            {
                Address = request.Addr,
                CMND = request.Cmnd,
                UserId = request.UserId,
                OrderDate = request.DateCreated,
                FullName = request.Name,
                Email = request.Email,
                Phone = request.Phone.ToString(),
                More = "Thông tin thêm",
                ReturnDate = DateTime.Now
            };
            Product pro = await _context.Products.FindAsync(request.Id);
            pro.IsFeatured = true;
            _context.Products.Update(pro);
            _context.Orders.Add(order);

            return await _context.SaveChangesAsync();
        }
    }
}
