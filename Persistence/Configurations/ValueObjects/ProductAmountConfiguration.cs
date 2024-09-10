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
            .Property(x => x.Amount)
            .IsRequired();

        builder
            .Property(x => x.ProductId)
            .IsRequired();

        builder
            .HasOne<Order>()
            .WithMany()
            .HasForeignKey(x => x.Id);
    }
}