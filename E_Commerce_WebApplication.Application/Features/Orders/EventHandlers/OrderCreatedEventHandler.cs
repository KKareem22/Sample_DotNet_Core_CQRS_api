using E_Commerce_WebApplication.Application.Common.Interfaces;
using E_Commerce_WebApplication.Domain.Entites.Orders;
using E_Commerce_WebApplication.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_WebApplication.Application.Features.Orders.EventHandlers
{
    public class OrderCreatedEventHandler : INotificationHandler<OrderCreatedEvent>
    {
        private readonly IApplicationDbContext _context;

        public OrderCreatedEventHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            // 1. حساب الإجمالي للطلب
            var totalAmount = notification.Order.Items.Sum(i => i.Quantity * i.UnitPrice);
            var totalItems = notification.Order.Items.Sum(i => i.Quantity);

            // 2. تجهيز سطر جديد لجدول القراءة
            var summary = new OrderSummaryReadModel
            {
                OrderId = notification.Order.Id,
                CustomerName = notification.Order.CustomerName,
                Total = totalAmount,     
                ItemCount = totalItems,  
                Status = "Pending"       
            };

            // 3. الحفظ في جدول الـ Materialized View
            _context.OrderSummaries.Add(summary);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}