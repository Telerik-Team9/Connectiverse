using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Database;
using SocialNetwork.Models;
using SocialNetwork.Services.Services;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.CommentServiceTests
{
    [TestClass]
    public class DeleteAsync_Should
    {
        [TestMethod]
        public async Task ReturnTrueWhen_ValidParams2()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnTrueWhen_ValidParams2));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                var comment = new Comment();
                await arrangeContext.Comments.AddAsync(comment);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new CommentService(actContext, mapper);
                var result = await sut.DeleteAsync(1);

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task ReturnFalseWhen_ValidParams2()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnFalseWhen_ValidParams2));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new CommentService(actContext, mapper);
                var result = await sut.DeleteAsync(1);

                Assert.IsFalse(result);
            }
        }
    }
}
