using Api.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tests
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            IConfiguration configuration = Api.Helpers.GetConfiguration();
            services.AddSingleton(configuration);
            services.AddDbContext<Context>();
            services.AddTransient<IUsersRepository, UsersRepository>();
        }
    }
}