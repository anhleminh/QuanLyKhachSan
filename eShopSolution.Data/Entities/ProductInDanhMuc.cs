using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Data.Entities
{
    public class ProductInDanhMuc
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int DanhMucId { get; set; }

        public DanhMuc DanhMuc { get; set; }
    }
}
