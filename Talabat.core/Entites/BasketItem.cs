using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.core.Entites
{
    public class BasketItem:BaseEntity
    {
        public string productName { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal price { get; set; }
        public string pictureUrl { get; set; }

        public string brand { get; set; }

        public string type { get; set; }
    }
}
