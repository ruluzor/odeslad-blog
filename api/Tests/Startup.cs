using Tests.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Api.Repositories;

namespace Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            IConfiguration configuration = GetConfiguration();
            services.AddSingleton(configuration);
            services.AddDbContext<TestContext>();
            services.AddTransient<IUsersRepository, UsersRepository>();
        }

        private IConfiguration GetConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            return configurationBuilder.Build();
        }
    }
}