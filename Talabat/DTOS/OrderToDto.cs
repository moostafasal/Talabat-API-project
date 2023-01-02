using System;
using System.Collections.Generic;
using Talabat.core.Entites.OrderAgregt;

namespace Talabat.DTOS
{
    public class OrderToDto
    {
        public int Id { get; set; }
        public string BuyerEmail { get; set; }//whow buy the order
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;//time of cration of the order
        public Address ShipToAddress { get; set; }//shiping address
        //public DelveryMethod DelveryMethod { get; set; }//[navigation property][one]

        public string DeleveryMethod { get; set; }
        public decimal DelverMethodCost { get; set; }

        public string OrderStatus { get; set; }//coversion 
        public string PaymentIntentId { get; set; }
        //price of the order 
        public decimal SubTotal { get; set; }//drevin price not 
        //public string DeliveryMethodPrice { get; set; }
         
        public decimal Total { get; set; }
        public ICollection<OrderItemDto> items { get; set; }//navigtion property [many]

    }
}
