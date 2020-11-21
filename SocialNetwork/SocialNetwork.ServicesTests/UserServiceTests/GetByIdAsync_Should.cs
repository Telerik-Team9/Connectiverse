using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Database;
using SocialNetwork.Services.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.UserServiceTests
{
    [TestClass]
    public class GetByIdAsync_Should
    {
        [TestMethod]
        public async Task SuccessWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SuccessWhen_ValidParams));
            var id = Utils.GetUsers().First().Id;

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                var users = Utils.GetUsers();

                await arrangeContext.Users.AddRangeAsync(users);
                await arrangeContext.SaveChangesAsync();
            }
            
            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.GetByIdAsync(id);

                Assert.AreEqual(result.Id, id);
            }
        }

        [TestMethod]
        public async Task ThrowWhen_InvalidParams()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_InvalidParams));
            var id = Utils.GetUsers().First().Id;

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                var users = Utils.GetUsers();

                await arrangeContext.Users.AddRangeAsync(users);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);

                await Assert.ThrowsExceptionAsync<ArgumentException>
                     (async () => await sut.GetByIdAsync(default));
            }
        }
    }
}
