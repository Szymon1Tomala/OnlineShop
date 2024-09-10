using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Entities;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}