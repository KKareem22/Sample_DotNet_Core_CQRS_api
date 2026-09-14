using MediatR;

namespace E_Commerce_WebApplication.Application.Features.Orders.Commands.CreateOrder
{
    public class OrderItemDto
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
    public class CreateOrderCommand : IRequest<Guid>
    {
        public string CustomerName { get; set; } = string.Empty;
        public List<OrderItemDto> Items { get; set; } = new();
    }
}
