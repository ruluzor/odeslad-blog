using Api.Models;
using Microsoft.Extensions.Configuration;

namespace Tests
{
    public class Helpers
    {
        public static List<User> GetMockListUsers()
        {
            return new List<User>
            {
                new User()
                {
                    Id = 1,
                    Title = "Rubén",
                    PasswordHash = "$2a$11$0pJV5Xx0curItzOhLTIc2eXreV.xif37D2pGY2zMuO0g9vFeOkv76"
                },
                new User()
                {
                    Id = 2,
                    Title = "Test 2",
                    PasswordHash = "1234"
                }
            };
        }

         public static User GetMockLoginUser()
        {
            return new User()
            {
                Id = 1,
                Title = "Rubén",
                PasswordHash = "1234"
            };
        }

        public static IConfiguration GetConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            return configurationBuilder.Build();
        }
    }
}