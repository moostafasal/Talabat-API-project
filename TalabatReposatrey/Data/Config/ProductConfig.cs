using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites;

namespace TalabatReposatrey.Data.Config
{
    public class ProductConfig : IEntityTypeConfiguration<product>
    {
        public void Configure(EntityTypeBuilder<product> builder)
        {
            builder.Property(p => p.Name).IsRequired();
           
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(p => p.productbrand).WithMany().
                HasForeignKey(p => p.ProductBrandId);
            builder.HasOne(p => p.ProductType).WithMany().
                HasForeignKey(P => P.ProductTypeId);
            builder.Property(P => P.Price).HasColumnType("decimal(18,2)");

        }
    }
}
