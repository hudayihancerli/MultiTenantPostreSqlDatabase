using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController(TenantContextService tenantService, MasterDbContext masterDbContext) : ControllerBase
    {
        [HttpGet("{username}")]
        public async Task<IActionResult> Get(string username)
        {
            try
            {
                var dbContext = await tenantService.GetTenantContextAsync(username);
                var data = await dbContext.CustomerData.ToListAsync();
                return Ok(data);
            }
            catch (Exception e)
            {
                 return NotFound(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(string username, string password)
        {
            var connectionString = $"Host=localhost;Database={username}_db;Username=postgres;Password=464646";

            var options = new DbContextOptionsBuilder<TenantDbContext>()
                .UseNpgsql(connectionString)
                .Options;

            using var tenatnDbContext = new TenantDbContext(options);
            await tenatnDbContext.Database.EnsureCreatedAsync();

            var tenant = new Tenant
            {
                Id = Guid.NewGuid(),
                Username = username,
                ConnectionString = connectionString
            };

            masterDbContext.Tenants.Add(tenant);
            await masterDbContext.SaveChangesAsync();

            return Ok("Yeni tenant olusturuldu");
        }
    }
}