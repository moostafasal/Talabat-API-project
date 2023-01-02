using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.core.Entites;
using Talabat.core.Entites.OrderAgregt;

namespace TalabatReposatrey.Data
{
    public class StorContextSeed
    {
        public static async Task seedAsync(StoreContext context , ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.productbrands.Any())
                {
                    var brandsData = File.ReadAllText("../TalabatReposatrey/Data/DataSeed/brands.json");
                    var brands = JsonSerializer.Deserialize<List<Productbrand>>(brandsData);

                    foreach (var brand in brands)

                        context.Set<Productbrand>().Add(brand);


                }
                if (!context.ProductTypes.Any())
                {
                    var TypesData = File.ReadAllText("../TalabatReposatrey/Data/DataSeed/types.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);

                    foreach (var type in Types)
                        context.Set<ProductType>().Add(type);
                }
 
                if (!context.products.Any())
                {
                    var productsData = File.ReadAllText("../TalabatReposatrey/Data/DataSeed/products.json");
                    var products = JsonSerializer.Deserialize<List<product>>(productsData);

                    foreach (var product in products)
                        context.Set<product>().Add(product);
                }

                if (!context.DeliveryMethods.Any())
                {
                    var orderDelevaryMethod = File.ReadAllText("../TalabatReposatrey/Data/DataSeed/delivery.json");
                    var delveryMethods = JsonSerializer.Deserialize<List<DelveryMethod>>(orderDelevaryMethod);

                    foreach (var methods in delveryMethods)

                        context.Set<DelveryMethod>().Add(methods);


                }
                await context.SaveChangesAsync();
            }
            catch (System.Exception Ex)
            {
                var loger = loggerFactory.CreateLogger<StorContextSeed>();

                loger.LogError(Ex, Ex.Message);



            }
        }


    }
}
