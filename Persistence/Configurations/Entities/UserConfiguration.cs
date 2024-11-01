using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Entities;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.Id)
            .HasConversion(id => id.Value, value => new UserId(value));
        
        builder
            .Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder
            .Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(254);
        
        builder
            .Property(x => x.PhoneNumberId)
            .IsRequired();
        
        builder
            .HasOne(x => x.PhoneNumber)
            .WithOne(x => x.User)
            .HasForeignKey<User>(x => x.PhoneNumberId);
    }
}