using E_Commerce_WebApplication.Application.Common.Interfaces;
using E_Commerce_WebApplication.Domain.Entites.Orders;
using E_Commerce_WebApplication.Domain.Events;
using MediatR;

namespace E_Commerce_WebApplication.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator; // ضفنا ده

        public CreateOrderCommandHandler(IApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CustomerName = request.CustomerName,
                Items = request.Items.Select(i => new OrderItem
                {
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList()
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync(cancellationToken);

            // إطلاق الحدث عشان الـ Event Handler يشتغل في الخلفية ويحدث جدول القراءة
            await _mediator.Publish(new OrderCreatedEvent(order), cancellationToken);

            return order.Id;
        }
    }
}
