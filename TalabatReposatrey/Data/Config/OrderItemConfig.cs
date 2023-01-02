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
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(orderItem=> orderItem.product, Np => Np.WithOwner());
            builder.Property(O => O.price).HasColumnType("decimal(18,2)");


        }
    }
}
