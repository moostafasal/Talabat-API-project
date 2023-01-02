using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites.OrderAgregt;

namespace Talabat.core.Entites
{
    public class CustmerBasket
    {
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public CustmerBasket(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
        public string paymentIntendId { get; set; }


        public string ClintSecret { get; set; }

        public int?  DelveryMethodId  { get; set; }
        public decimal shpingPrice { get; set; }
    }
}
