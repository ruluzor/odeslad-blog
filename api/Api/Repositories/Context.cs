using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class Context : DbContext
    {
        protected readonly IConfiguration _configuration;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("Default"));
        }

        public DbSet<Models.User> Users { get; set; }
    }
}