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

    public class ChangeDisplayPicture_Should
    {
        [TestMethod]
        public async Task ThrowWhen_InvalidParams18()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_InvalidParams18));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var azureBlobService = Mock.Of<IAzureBlobService>();

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new PostService(actContext, azureBlobService, mapper);

                await Assert.ThrowsExceptionAsync<ArgumentException>
                    (async () => await sut.ChangeDisplayPicture(default, default, default));
            }
        }

        [TestMethod]
        public async Task ChangeProfilePictureWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ChangeProfilePictureWhen_ValidParams));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var users = Utils.GetUsers();
            var posts = Utils.GetPosts();

            var azureBlobService = new Mock<IAzureBlobService>();
            azureBlobService.Setup(x => x.UploadToBlobStorageAsync(default))
                            .ReturnsAsync("profilePhoto.url");

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.Users.AddRangeAsync(users);
                await arrangeContext.Posts.AddRangeAsync(posts);
                await arrangeContext.SaveChangesAsync();
            }

            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new PostService(actContext, azureBlobService.Object, mapper);
                var result = await sut.ChangeDisplayPicture(default, users.First().Id, "profile");

                Assert.AreEqual("profilePhoto.url", actContext.Users.First().ProfilePictureUrl);
            }
        }

        [TestMethod]
        public async Task ChangeCoverPictureWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ChangeCoverPictureWhen_ValidParams));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var users = Utils.GetUsers();
            var posts = Utils.GetPosts();

            var azureBlobService = new Mock<IAzureBlobService>();
            azureBlobService.Setup(x => x.UploadToBlobStorageAsync(default))
                            .ReturnsAsync("coverPhoto.url");

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.Users.AddRangeAsync(users);
                await arrangeContext.Posts.AddRangeAsync(posts);
                await arrangeContext.SaveChangesAsync();
            }

            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new PostService(actContext, azureBlobService.Object, mapper);
                var result = await sut.ChangeDisplayPicture(default, users.First().Id, "cover");

                Assert.AreEqual("coverPhoto.url", actContext.Users.First().CoverPictureUrl);
            }
        }
    }
}
