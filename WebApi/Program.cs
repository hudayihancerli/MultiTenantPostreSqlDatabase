using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MasterDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("MasterDb")));
builder.Services.AddDbContextFactory<TenantDbContext>();

builder.Services.AddSingleton<TenantDbContextFactory>();
builder.Services.AddScoped<TenantContextService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();