namespace Talabat.DTOS
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string productName { get; set; }
        public string pictuerUrl { get; set; }
        public decimal price { get; set; }
        public int Quantity { get; set; }
    }
}