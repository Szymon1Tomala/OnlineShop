using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Entities;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder
            .Property(x => x.Id)
            .HasConversion(id => id.Value, value => new EmployeeId(value));
        
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
            .Property(x => x.DepartmentId)
            .IsRequired();

        builder
            .HasOne(x => x.PhoneNumber)
            .WithOne(x => x.Employee)
            .HasForeignKey<Employee>(x => x.PhoneNumberId);
        
        builder
            .HasOne(x => x.Department)
            .WithMany()
            .HasForeignKey(x => x.DepartmentId);
    }
}