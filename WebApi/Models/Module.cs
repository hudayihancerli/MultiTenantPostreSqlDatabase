namespace WebApi.Models;

public class Module
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public ICollection<Tenant> Tenants { get; set; } = new List<Tenant>();

}