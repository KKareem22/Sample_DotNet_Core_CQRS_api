using E_Commerce_WebApplication.Application.Common.Interfaces;
using E_Commerce_WebApplication.Domain.Entites.Orders;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_WebApplication.Infrastructure.Data
{
    public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options),IApplicationDbContext
    {
        #region DbSets
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderSummaryReadModel> OrderSummaries { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);

        }


    }
}
