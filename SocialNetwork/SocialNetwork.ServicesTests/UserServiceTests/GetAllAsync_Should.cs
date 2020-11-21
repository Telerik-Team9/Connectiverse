using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Database;
using SocialNetwork.Services.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.UserServiceTests
{
    [TestClass]
    public class GetAllAsync_Should
    {
        [TestMethod]
        public async Task SuccessWhen_ValidParams3()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SuccessWhen_ValidParams3));
            var users = Utils.GetUsers().ToList();

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.AddRangeAsync(users);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.GetAllAsync();

                Assert.AreEqual(users.Count, result.Count());
            }
        }

        [TestMethod]
        public async Task ThrowWhen_NoResults()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_NoResults));

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                await Assert.ThrowsExceptionAsync<ArgumentException>
                     (async () => await sut.GetAllAsync());
            }
        }

        [TestMethod]
        public async Task ReturnCorrectCount()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnCorrectCount));
            var users = Utils.GetUsers().ToList();

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                users.First().IsDeleted = true;

                await arrangeContext.AddRangeAsync(users);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.GetAllAsync();

                Assert.AreEqual(users.Count - 1, result.Count());
            }
        }
    }
}
