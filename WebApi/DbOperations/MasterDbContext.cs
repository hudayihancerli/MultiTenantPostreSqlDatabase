using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.DbOperations;

public class MasterDbContext(DbContextOptions<MasterDbContext> options) : DbContext(options)
{
    public DbSet<Tenant> Tenants { get; set; }
}