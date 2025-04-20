namespace WebApi.Models;

public class Tenant
{
    public Guid Id { get; set; }
    public string Username { get; set; }= string.Empty;
    public string ConnectionString { get; set; } = string.Empty;
}