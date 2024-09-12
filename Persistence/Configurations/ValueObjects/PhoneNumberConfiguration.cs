using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.ValueObjects;

public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
{
    public void Configure(EntityTypeBuilder<PhoneNumber> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.Id)
            .HasConversion(id => id.Value, value => new PhoneNumberId(value));

        builder
            .Property(x => x.DirectNumber)
            .IsRequired();

        builder
            .Property(x => x.Number)
            .IsRequired();
    }
}