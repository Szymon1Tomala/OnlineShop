using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.ValueObjects;

public class ProductAmountConfiguration : IEntityTypeConfiguration<ProductAmount>
{
    public void Configure(EntityTypeBuilder<ProductAmount> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.Id)
            .HasConversion(id => id.Value, value => new ProductAmountId(value));

        builder
            .Property(x => x.Amount)
            .IsRequired();

        builder
            .Property(x => x.ProductId)
            .IsRequired();

        builder
            .HasOne(x => x.Order)
            .WithMany(x => x.ProductAmounts)
            .HasForeignKey(x => x.OrderId);
        
        builder
            .HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.ProductId);
    }
}