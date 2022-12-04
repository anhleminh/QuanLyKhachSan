using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Data.Configurations
{
    public class ProductInDanhMucConfiguration : IEntityTypeConfiguration<ProductInDanhMuc>
    {
        public void Configure(EntityTypeBuilder<ProductInDanhMuc> builder)
        {
            builder.HasKey(t => new { t.DanhMucId, t.ProductId });

            builder.ToTable("ProductInDanhMuc");

            builder.HasOne(t => t.Product).WithMany(pc => pc.ProductInDanhMuc)
                .HasForeignKey(pc => pc.ProductId);

            builder.HasOne(t => t.DanhMuc).WithMany(pc => pc.ProductInDanhMuc)
              .HasForeignKey(pc => pc.DanhMucId);
        }
    }
}
