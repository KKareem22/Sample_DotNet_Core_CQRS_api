namespace E_Commerce_WebApplication.Domain.Entites.Orders
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CustomerName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending"; // الحالة المبدئية

        public List<OrderItem> Items { get; set; } = new();

        public decimal Total => Items.Sum(i => i.Quantity * i.UnitPrice);
    }
}
