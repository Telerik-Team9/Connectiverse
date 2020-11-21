using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Database;
using SocialNetwork.Services.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.UserServiceTests
{
    [TestClass]
    public class DeleteFriendRequestAsync_Should
    {
        [TestMethod]
        public async Task SuccessWhen_ValidParams1()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SuccessWhen_ValidParams1));
            var request = Utils.GetFriendRequests().First();

            var senderId = request.SenderId;
            var receiverId = request.ReceiverId;

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                var requests = Utils.GetFriendRequests();

                await arrangeContext.FriendRequests.AddRangeAsync(requests);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.DeleteFriendRequestAsync(senderId, receiverId);

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task ThrowWhen_InvalidParams1()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_InvalidParams1));
            var request = Utils.GetFriendRequests().First();

            var senderId = request.SenderId;
            var receiverId = request.ReceiverId;

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                var requests = Utils.GetFriendRequests();

                await arrangeContext.FriendRequests.AddRangeAsync(requests);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);

                await Assert.ThrowsExceptionAsync<ArgumentException>
                     (async () => await sut.DeleteFriendRequestAsync(default, default));
            }
        }
    }
}
