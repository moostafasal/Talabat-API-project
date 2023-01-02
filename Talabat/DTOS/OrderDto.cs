using Talabat.core.Entites.Identity;

namespace Talabat.DTOS
{ 
    public class OrderDto
    {
        public string basketId { get; set; }
        public AddressDto ShipToAddress { get; set; }
        public int DeliveryMethodId { get; set; }
  
    }
}
