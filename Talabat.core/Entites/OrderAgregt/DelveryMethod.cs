using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.core.Entites.OrderAgregt
{
    public class DelveryMethod:BaseEntity
    {
        public DelveryMethod()
        {

        }
        public DelveryMethod(string shortName, string deliveryTime, string description, decimal cost)
        {
            ShortName = shortName; 
            DeliveryTime = deliveryTime;
            Description = description;
            Cost = cost;

        }

        public string ShortName { get; set; }
        public string DeliveryTime { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        //public ICollection<Order> Orders { get; set; }
    }
}
