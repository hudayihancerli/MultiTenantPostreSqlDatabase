using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Services;

public class TenantContextService(MasterDbContext masterDbContext, TenantDbContextFactory  factory)
{
    public async Task<TenantDbContext> GetTenantContextAsync(string username)
    {
        var tenant = await masterDbContext.Tenants
            .FirstOrDefaultAsync(t => t.Username == username);
        if (tenant == null)
            throw new Exception("Tenant bulunamadı.");

        return factory.Create(tenant.ConnectionString);
    }
    
}