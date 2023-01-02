using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.core.Entites.OrderAgregt
{
    public class OrderItem:BaseEntity
    {
   
        public OrderItem()
        {

        }

        public OrderItem(productItemOrder productItemOrder, decimal price, int quantity)
        {
            product = productItemOrder;
            this.price = price;
            Quantity = quantity;
        }

        public productItemOrder product { get; set; }
        public decimal price { get; set; }
        public int Quantity { get; set; }

        //public Order Order { get; set; }
    }
}
