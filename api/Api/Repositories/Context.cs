using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Models.User> Users { get; set; }
    }
}