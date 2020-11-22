using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Database;
using SocialNetwork.Services.Services;
using SocialNetwork.Services.Services.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.PostServiceTests
{
    [TestClass]
    public class DeletePostAsync_Should
    {
        [TestMethod]
        public async Task DeletePostWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(DeletePostWhen_ValidParams));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();
            var azureBlobService = Mock.Of<IAzureBlobService>();

            var post = Utils.GetPosts().First();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.Posts.AddAsync(post);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new PostService(actContext, azureBlobService, mapper);
                var result = await sut.DeletePostAsync(post.Id);

                Assert.IsTrue(result);
                Assert.AreEqual(true, actContext.Posts.First().IsDeleted);
            }
        }

        [TestMethod]
        public async Task ReturnFalseWhen_InvalidParams()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnFalseWhen_InvalidParams));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();
            var azureBlobService = Mock.Of<IAzureBlobService>();

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new PostService(actContext, azureBlobService, mapper);
                var result = await sut.DeletePostAsync(default);

                Assert.IsFalse(result);
            }
        }
    }
}
