using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Entities;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.Id)
            .HasConversion(id => id.Value, value => new OrderId(value));

        builder
            .Property(x => x.UserId)
            .IsRequired();

        builder
            .Property(x => x.OrderDate)
            .IsRequired();

        builder
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.UserId);
    }
}