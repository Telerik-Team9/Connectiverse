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
    public class GetUserPostsAsync_Should
    {
        [TestMethod]
        public async Task SuccessWhen_ValidParams15()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SuccessWhen_ValidParams15));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();
            var azureBlobService = Mock.Of<IAzureBlobService>();

            var posts = Utils.GetPosts();
            var users = Utils.GetUsers();
            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.Posts.AddRangeAsync(posts);
                await arrangeContext.Users.AddRangeAsync(users);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert 
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new PostService(actContext, azureBlobService, mapper);
                var result = await sut.GetUserPostsAsync(users.First().Id);

                Assert.AreEqual(1, result.Count());
            }
        }

        [TestMethod]
        public async Task ThrowWhen_NoUserPosts()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SuccessWhen_ValidParams15));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();
            var azureBlobService = Mock.Of<IAzureBlobService>();

            //Act & Assert 
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new PostService(actContext, azureBlobService, mapper);
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
                {
                    await sut.GetUserPostsAsync(Guid.Empty);
                });
            }
        }
    }
}
