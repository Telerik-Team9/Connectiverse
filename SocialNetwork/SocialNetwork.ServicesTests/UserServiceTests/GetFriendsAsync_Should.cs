using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Database;
using SocialNetwork.Services.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.UserServiceTests
{
    [TestClass]
    public class GetFriendsAsync_Should
    {
        [TestMethod]
        public async Task SuccessWhen_ValidParams4()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SuccessWhen_ValidParams4));
            var user = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270");

            var users = Utils.GetUsers();

            var friendships = Utils.GetFriendShips().ToList();

            var count = friendships.Where(x => x.UserId == user).Count();

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.Users.AddRangeAsync(users);
                await arrangeContext.Friends.AddRangeAsync(friendships);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(assertContext, mapper);
                var result = await sut.GetFriendsAsync(user);

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
                     (async () => await sut.GetFriendsAsync(user));
            }
        }

        [TestMethod]
        public async Task ReturnCorrectFriendCount()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnCorrectFriendCount));
            var user = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270");

            var users = Utils.GetUsers();

            var friendships = Utils.GetFriendShips().ToList();

            var count = friendships.Where(x => x.UserId == user).Count();

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                friendships.First().IsDeleted = true;
                await arrangeContext.Users.AddRangeAsync(users);
                await arrangeContext.Friends.AddRangeAsync(friendships);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var assertContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(assertContext, mapper);
                var result = await sut.GetFriendsAsync(user);

                Assert.AreEqual(count - 1, result.Count());
            }
        }
    }
}
