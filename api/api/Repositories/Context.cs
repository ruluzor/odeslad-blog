using Microsoft.EntityFrameworkCore;

namespace api.Repositories;

public class Context : DbContext
{
    protected readonly IConfiguration Configuration;

    public Context(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.GetConnectionString("Default"));
    }

    public DbSet<Models.User> Users { get; set; }
}