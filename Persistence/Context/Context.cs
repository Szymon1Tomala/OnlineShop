using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<User> User { get; set; }
    
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    public DbSet<ProductAmount> ProductAmounts { get; set; }
}