using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites.OrderAgregt;

namespace TalabatReposatrey.Data.Config
{
    public class Ordercongfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(O => O.ShipToAddress, NP => NP.WithOwner()
    
                );

            builder.Property(O => O.OrderStatus).HasConversion(
    orderstatus => orderstatus.ToString(),
    orderstatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), orderstatus)
    );
            //save in databeas as streing and retrev as (integer)=> enum 
            builder.HasMany(O => O.items).WithOne().OnDelete(DeleteBehavior.Cascade);
            //builder.HasOne(O => O.DelveryMethod).WithOne().OnDelete(DeleteBehavior.SetNull);
            //convert cost type to decmal 18,2
            builder.Property(O => O.SubTotal).HasColumnType("decimal(18,2)");





        }
    }
}
