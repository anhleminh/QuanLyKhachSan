using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Data.Entities
{
    public class DanhMuc
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public List<ProductInDanhMuc> ProductInDanhMuc { get; set; }
    }
}
