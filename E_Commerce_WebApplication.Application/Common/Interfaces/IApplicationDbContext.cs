using E_Commerce_WebApplication.Domain.Entites.Orders;
using Microsoft.EntityFrameworkCore;
namespace E_Commerce_WebApplication.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Order> Orders { get; }
        DbSet<OrderItem> OrderItems { get; }
        DbSet<OrderSummaryReadModel> OrderSummaries { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
