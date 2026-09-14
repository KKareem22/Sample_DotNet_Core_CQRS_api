namespace E_Commerce_WebApplication.Domain.Entites.Orders
{
    public class OrderSummaryReadModel
    {
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int ItemCount { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
