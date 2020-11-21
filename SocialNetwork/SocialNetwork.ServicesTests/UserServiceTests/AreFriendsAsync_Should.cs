using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Database;
using SocialNetwork.Services.Services;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.UserServiceTests
{
    [TestClass]
    public class AreFriendsAsync_Should
    {
        [TestMethod]
        public async Task ReturnTrueIfUsersAreFriends()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnTrueIfUsersAreFriends));
            var friendships = Utils.GetFriendShips();

            var user = friendships.First().UserId;
            var userFriend = friendships.First().UserFriendId;

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.Friends.AddRangeAsync(friendships);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert 
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.AreFriendsAsync(user, userFriend);

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task ReturnFalseIfFriendshipDeleted()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnFalseIfFriendshipDeleted));
            var friendships = Utils.GetFriendShips().ToList();

            var user = friendships.First().UserId;
            var userFriend = friendships.First().UserFriendId;

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                friendships[0].IsDeleted = true;
                friendships[1].IsDeleted = true;

                await arrangeContext.Friends.AddRangeAsync(friendships);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert 
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.AreFriendsAsync(user, userFriend);

                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public async Task ReturnFalseIfDoesNotExist()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnFalseIfFriendshipDeleted));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            //Act & Assert 
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.AreFriendsAsync(default, default);

                Assert.IsFalse(result);
            }
        }
    }
}
