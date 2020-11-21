using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Database;
using SocialNetwork.Services.Services;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.UserServiceTests
{
    [TestClass]
    public class IsLegitAsync_Should
    {
        [TestMethod]
        public async Task SuccessWhen_ValidParams7()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SuccessWhen_ValidParams7));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();
            var users = Utils.GetUsers();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.Users.AddRangeAsync(users);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.IsLegitAsync("ali@mail.com");

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task ReturnFalseWhen_InvalidParams7()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnFalseWhen_InvalidParams7));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();
            var users = Utils.GetUsers();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.Users.AddRangeAsync(users);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.IsLegitAsync("a7@mail.com");

                Assert.IsFalse(result);
            }
        }
    }
}

