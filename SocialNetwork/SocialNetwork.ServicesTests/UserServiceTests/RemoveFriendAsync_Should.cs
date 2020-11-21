using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Database;
using SocialNetwork.Services.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.UserServiceTests
{
    [TestClass]
    public class RemoveFriendAsync_Should
    {

        [TestMethod]
        public async Task SuccessWhen_ValidParams1()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SuccessWhen_ValidParams1));
            var friendships = Utils.GetFriendShips();
            var user = friendships.First().UserId;
            var userFriend = friendships.First().UserFriendId;

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                var requests = Utils.GetFriendRequests();

                await arrangeContext.Friends.AddRangeAsync(friendships);
                await arrangeContext.SaveChangesAsync();
            }
            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.RemoveFriendAsync(user, userFriend);

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task ThrowWhen_InvalidUser1Params()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_InvalidUser1Params));
            var friendships = Utils.GetFriendShips();
            var user = friendships.First().UserId;
            var userFriend = friendships.First().UserFriendId;

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                var requests = Utils.GetFriendRequests();

                await arrangeContext.Friends.AddRangeAsync(friendships);
                await arrangeContext.SaveChangesAsync();
            }
            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);

                await Assert.ThrowsExceptionAsync<ArgumentException>
                     (async () => await sut.RemoveFriendAsync(user, default));
            }
        }

        [TestMethod]
        public async Task ThrowWhen_InvalidUser2Params()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_InvalidUser2Params));
            var friendships = Utils.GetFriendShips();
            var user = friendships.First().UserId;
            var userFriend = friendships.First().UserFriendId;

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                var requests = Utils.GetFriendRequests();

                await arrangeContext.Friends.AddRangeAsync(friendships);
                await arrangeContext.SaveChangesAsync();
            }
            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);

                await Assert.ThrowsExceptionAsync<ArgumentException>
                     (async () => await sut.RemoveFriendAsync(default, userFriend));
            }
        }
    }
}
