using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Database;
using SocialNetwork.Services.Services;
using SocialNetwork.Services.Services.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.PostServiceTests
{
    [TestClass]
    public class GetUserFriendsPostsAsync_Should
    {
        [TestMethod]
        public async Task SuccessWhen_ValidParams10()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SuccessWhen_ValidParams10));
            var posts = Utils.GetPosts();
            var users = Utils.GetUsers();
            var friends = Utils.GetFriendShips();
            var userId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270");  // Magi

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();
            var azureBlobService = Mock.Of<IAzureBlobService>();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.Users.AddRangeAsync(users);
                await arrangeContext.Posts.AddRangeAsync(posts);
                await arrangeContext.Friends.AddRangeAsync(friends);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new PostService(actContext, azureBlobService, mapper);
                var result = await sut.GetUserFriendsPostsAsync(userId);

                Assert.AreEqual(3, result.Count());
            }
        }
    }
}
