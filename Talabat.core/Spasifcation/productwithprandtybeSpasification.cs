using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites;

namespace Talabat.core.Spasifcation
{
    public class productwithprandtybeSpasification : BaseSpasifcation<product>
    {
        //ctor to get All
        public productwithprandtybeSpasification(Productparams product)
            : base(P =>

            (string.IsNullOrEmpty(product.Serch)||P.Name.ToLower().Contains(product.Serch))&&
            (!product.brandId.HasValue || P.ProductBrandId == product.brandId.Value) &&
            (!product.TypeId.HasValue || P.ProductTypeId == product.TypeId.Value)

            
            )
            

        {
            AddInclud(p=>p.productbrand);
            AddInclud(p => p.ProductType);
            AddOrderBy(p => p.Name);
            ApplyPigination(product.Pagesize * (product.pageIndex - 1), product.Pagesize);
            if (!string.IsNullOrEmpty(product.sort))
            {
                switch (product.sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDes":
                        AddOrderByDes(p => p.Price);
                        break;

                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }

        }
        //Ctor To get spasific id
        public productwithprandtybeSpasification(int id):base(P=>P.Id==id)
        {
            AddInclud(p => p.productbrand);
            AddInclud(p => p.ProductType);
        }
    }
}
