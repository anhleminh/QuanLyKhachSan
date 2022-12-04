using eShopSolution.Data.Entities;
using eShopSolution.ViewModels.Catalog.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class ProductVm
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public int Id { set; get; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public DateTime DateCreated { set; get; }
        public Guid UserId { get; set; }
        public int Phone { get; set; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string Addr { get; set; }
        public string Cmnd { get; set; }

        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }

        public bool? IsFeatured { get; set; }

        public string ThumbnailImage { get; set; }
        public string TypeBed { set; get; }
        public int CoundCustomer { set; get; }
        public List<string> DanhMuc { get; set; } = new List<string>();
        public List<string> Categories { get; set; } = new List<string>();
    }
}