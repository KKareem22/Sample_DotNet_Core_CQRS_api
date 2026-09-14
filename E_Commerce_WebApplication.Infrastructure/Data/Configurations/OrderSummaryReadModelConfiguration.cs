using E_Commerce_WebApplication.Domain.Entites.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce_WebApplication.Infrastructure.Data.Configurations
{
    public class OrderSummaryReadModelConfiguration : IEntityTypeConfiguration<OrderSummaryReadModel>
    {
        public void Configure(EntityTypeBuilder<OrderSummaryReadModel> builder)
        {
            builder.HasKey(x => x.OrderId);
            builder.Property(x => x.Total).HasPrecision(18, 2);
        }
    }
}
