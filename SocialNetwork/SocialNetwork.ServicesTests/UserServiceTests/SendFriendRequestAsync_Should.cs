using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Database;
using SocialNetwork.Models;
using SocialNetwork.Services.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.UserServiceTests
{
    [TestClass]
    public class SendFriendRequestAsync_Should
    {

        [TestMethod]
        public async Task SuccessWhen_ValidParams2()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SuccessWhen_ValidParams2));
            var sender = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270");
            var receiver = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5");

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.SendFriendRequestAsync(sender, receiver);

                Assert.AreEqual(1, actContext.FriendRequests.Count());
                Assert.AreEqual(1, actContext.FriendRequests.First().Id);
            }
        }

        [TestMethod]
        public async Task ReturnRequestIfPreviouslyAdded()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnRequestIfPreviouslyAdded));
            var sender = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270");
            var receiver = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5");

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();
            var request = Mock.Of<FriendRequest>(fr => fr.SenderId == sender
                                                    && fr.ReceiverId == receiver
                                                    && fr.IsDeleted);
            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.FriendRequests.AddAsync(request);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.SendFriendRequestAsync(sender, receiver);

                Assert.AreEqual(request.Id, result.Id);
                //Assert.AreNotEqual(request.CreatedOn, result.CreatedOn);
            }
        }
    }
}
