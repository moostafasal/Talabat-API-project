using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.core.Entites
{
    public class product: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public Productbrand productbrand  { get; set; } //nivigtinal proberty =>
        public ProductType ProductType { get; set; }
        //[ForeignKey("Productbrand")]=> we using flunt APi to make clean code 
        public int ProductBrandId { get; set; } // not allow null XX
        //[ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }
    }
}
