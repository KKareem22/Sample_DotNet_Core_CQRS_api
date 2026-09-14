using E_Commerce_WebApplication.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_WebApplication.Application.Features.Orders.Queries.GetOrderSummaries
{
    public class GetOrderSummariesQueryHandler : IRequestHandler<GetOrderSummariesQuery, List<OrderSummaryDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetOrderSummariesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderSummaryDto>> Handle(GetOrderSummariesQuery request, CancellationToken cancellationToken)
        {
            var summaries = await _context.OrderSummaries
                .Select(s => new OrderSummaryDto
                {
                    OrderId = s.OrderId,
                    CustomerName = s.CustomerName,
                    Total = s.Total,
                    ItemCount = s.ItemCount,
                    Status = s.Status
                })
                .ToListAsync(cancellationToken);

            return summaries;
        }
    }
}
