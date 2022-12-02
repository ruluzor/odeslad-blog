using Api.Models;
using Microsoft.Extensions.Configuration;

namespace Tests
{
    public class Helpers
    {
        public static List<User> GetMockDbListUsers()
        {
            return new List<User>
            {
                new User()
                {
                    Id = 1,
                    Title = "test 1",
                    PasswordHash = "$2a$11$NI1F7cCSQXndMQa19Aupqu/cUXEfX5VR5RsQnFIUzCrQf2wV1MQLm"
                },
                new User()
                {
                    Id = 2,
                    Title = "test 2",
                    PasswordHash = "$2a$11$NI1F7cCSQXndMQa19Aupqu/cUXEfX5VR5RsQnFIUzCrQf2wV1MQLm"
                }
            };
        }

        public static User GetMockNewUser()
        {
            return new User()
            {
                Id = 0,
                Title = "new test",
                Email = "test@gmail.com",
                PasswordHash = "1234"
            };
        }

         public static User GetMockLoginUser()
        {
            return new User()
            {
                Id = 1,
                Title = "test 1",
                PasswordHash = "1234"
            };
        }
    }
}