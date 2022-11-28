using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace api.Repositories;

public class TestContext : DbContext
{
    protected readonly IConfiguration _configuration;

    public TestContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(_configuration.GetConnectionString("Test"));
    }

    public DbSet<Models.User> Users { get; set; }
}