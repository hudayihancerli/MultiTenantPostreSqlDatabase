using Microsoft.EntityFrameworkCore;

namespace WebApi.DbOperations;

public class TenantDbContextFactory
{
    public TenantDbContext Create(string connectionString)
    {
        DbContextOptionsBuilder<TenantDbContext> optionsBuilder = new();
        optionsBuilder.UseNpgsql(connectionString);
        return new TenantDbContext(optionsBuilder.Options);
    }
}