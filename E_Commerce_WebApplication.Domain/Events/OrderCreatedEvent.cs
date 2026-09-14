using E_Commerce_WebApplication.Domain.Entites.Orders;
using MediatR;

namespace E_Commerce_WebApplication.Domain.Events
{
    public class OrderCreatedEvent : INotification
    {
        public Order Order { get; }

        public OrderCreatedEvent(Order order)
        {
            Order = order;
        }

    }
}
