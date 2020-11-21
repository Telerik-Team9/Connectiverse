using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Database;
using SocialNetwork.Services.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.UserServiceTests
{
    [TestClass]
    public class GetAllFriendRequestsSentAsync_Should
    {
        [TestMethod]
        public async Task SuccessWhen_ValidParams5()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SuccessWhen_ValidParams5));
            var user = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270");

            var users = Utils.GetUsers();

            var friendships = Utils.GetFriendRequests().ToList();

            var count = friendships.Where(x => x.SenderId == user).Count();

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.Users.AddRangeAsync(users);
                await arrangeContext.FriendRequests.AddRangeAsync(friendships);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(assertContext, mapper);
                var result = await sut.GetAllFriendRequestsSentAsync(user);

                Assert.AreEqual(count, result.Count());
            }
        }

        [TestMethod]
        public async Task ThrowWhen_NoResults()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_NoResults));
            var user = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270");

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                await Assert.ThrowsExceptionAsync<ArgumentException>
                     (async () => await sut.GetAllFriendRequestsSentAsync(user));
            }
        }
    }
}
