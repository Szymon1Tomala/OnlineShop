using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Entities;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.Id)
            .HasConversion(id => id.Value, value => new ProductId(value));

        builder
            .Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(x => x.Price)
            .IsRequired();
    }
}