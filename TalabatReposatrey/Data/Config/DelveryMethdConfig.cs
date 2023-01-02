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
    public class DelveryMethdConfig : IEntityTypeConfiguration<DelveryMethod>
    {
        public void Configure(EntityTypeBuilder<DelveryMethod> builder)
        {
            
            builder.Property(D => D.Cost).HasColumnType("decimal(18,2)");
            
        }
    }
}
