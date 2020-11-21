using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Database;
using SocialNetwork.Services.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.UserServiceTests
{
    [TestClass]
    public class GetAllFriendRequestsReceivedAsync_Should
    {
        [TestMethod]
        public async Task SuccessWhen_ValidParams6()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SuccessWhen_ValidParams6));
            var user = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270");

            var requests = Utils.GetFriendRequests().ToList();

            var count = requests.Where(x => x.ReceiverId == user).Count();

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.FriendRequests.AddRangeAsync(requests);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(assertContext, mapper);
                var result = await sut.GetAllFriendRequestsReceivedAsync(user);

                Assert.AreEqual(count, result.Count());
            }
        }

        [TestMethod]
        public async Task ReturnZeroWhen_NoResults()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnZeroWhen_NoResults));
            var user = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270");

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.GetAllFriendRequestsReceivedAsync(user);

                Assert.AreEqual(0, result.Count());
            }
        }
    }
}
