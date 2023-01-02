 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.core.Entites.OrderAgregt
{
    public class Order:BaseEntity
    {
        
        public Order()
        {
            items = new List<OrderItem>();
        }

        public Order(string buyerEmail, Address shipToAddress, DelveryMethod delveryMethod, decimal subTotal, ICollection<OrderItem> orderItems)
        {
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DelveryMethod = delveryMethod;
            SubTotal = subTotal;
            items = orderItems;
        }

        public string BuyerEmail { get; set; }//whow buy the order
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;//time of cration of the order
        public Address ShipToAddress { get; set; }//shiping address
        public DelveryMethod DelveryMethod { get; set; }//[navigation property][one]
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }
        //price of the order 
        public decimal SubTotal { get; set; }//drevin price not 
        public string DeliveryMethodPrice { get; set; }
        public decimal GetTotal()
        {
            return SubTotal + DelveryMethod.Cost;
        }
        public ICollection<OrderItem> items { get; set; }//navigtion property [many]

    }
}
