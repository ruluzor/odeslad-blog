using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Api.Models;

namespace Tests.Repositories;

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

    public DbSet<User> Users { get; set; }
}