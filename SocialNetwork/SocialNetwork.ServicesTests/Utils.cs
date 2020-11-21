using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Database;

namespace SocialNetwork.ServicesTests
{
    public class Utils
    {
        public static DbContextOptions<SocialNetworkDBContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<SocialNetworkDBContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }

    }
}
