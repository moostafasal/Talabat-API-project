using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites;

namespace Talabat.core.Spasifcation
{
    public class ProductWithFiltaar : BaseSpasifcation<product>
    {
        public ProductWithFiltaar(Productparams product)
    : base(P =>

       (string.IsNullOrEmpty(product.Serch) || P.Name.ToLower().Contains(product.Serch)) &&
       (!product.brandId.HasValue || P.ProductBrandId == product.brandId.Value) &&
    (!product.TypeId.HasValue || P.ProductTypeId == product.TypeId.Value)


    )
        { }



            
    }
}
