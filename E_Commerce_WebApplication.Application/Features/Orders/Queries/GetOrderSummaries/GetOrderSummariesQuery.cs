using MediatR;

namespace E_Commerce_WebApplication.Application.Features.Orders.Queries.GetOrderSummaries
{
    public class GetOrderSummariesQuery : IRequest<List<OrderSummaryDto>>
    {


    }
    public class OrderSummaryDto
    {
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public int ItemCount { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
