using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.DbOperations;

public class TenantDbContext(DbContextOptions<TenantDbContext> options) : DbContext(options)
{
    public DbSet<CustomerData> CustomerData { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerData>().ToTable("customer_data");
        
        modelBuilder.Entity<CustomerData>().HasData(
            new CustomerData { Id = 1, Value = "İlk kayıt" },
            new CustomerData { Id = 2, Value = "İkinci kayıt" }
        );
    }
    
    
}