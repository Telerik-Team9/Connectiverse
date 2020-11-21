using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Database;
using SocialNetwork.Services.Services;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.UserServiceTests
{
    [TestClass]
    public class DeleteAsync_Should
    {
        [TestMethod]
        public async Task ReturnTrueIfDeleted()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnTrueIfDeleted));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();
            var users = Utils.GetUsers();
            var id = users.First().Id;

            using(var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.Users.AddRangeAsync(users);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using(var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.DeleteAsync(id);

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task ReturnFalseIfError()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnTrueIfDeleted));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();
            

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.DeleteAsync(default);

                Assert.IsFalse(result);
            }
        }
    }
}
