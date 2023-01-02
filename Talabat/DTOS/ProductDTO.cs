using Talabat.core.Entites;

namespace Talabat.DTOS
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string productbrand { get; set; } 
        public string ProductType { get; set; }
        public int ProductBrandId { get; set; }
        public int ProductTypeId { get; set; }
    }
}
