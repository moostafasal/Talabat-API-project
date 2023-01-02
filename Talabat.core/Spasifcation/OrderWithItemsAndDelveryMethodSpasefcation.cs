using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites.OrderAgregt;

namespace Talabat.core.Spasifcation
{
    public  class OrderWithItemsAndDelveryMethodSpasefcation:BaseSpasifcation<Order>
    {
        public OrderWithItemsAndDelveryMethodSpasefcation(string BuyerEmail):base(o=>o.BuyerEmail==BuyerEmail)
        {
            Includs.Add(o => o.items);
            Includs.Add(o => o.DelveryMethod);
            
        }

        public OrderWithItemsAndDelveryMethodSpasefcation(int id,string BuyerEmail) : base(o => o.Id == id )
        {
            Includs.Add(o => o.items);
            Includs.Add(o => o.DelveryMethod);

        }
    }
}
