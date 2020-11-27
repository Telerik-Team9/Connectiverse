using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Database;
using SocialNetwork.Models;
using SocialNetwork.Services.Services;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.CommentServiceTests
{
    [TestClass]
    public class GetAllAsync_Should
    {
        [TestMethod]
        public async Task SuccessWhen_ValidParams14()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SuccessWhen_ValidParams14));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var post = Utils.GetPosts().First();
            var user = Utils.GetUsers().First();

            var comments = new Comment[]
            {
                    new Comment() { Content = "zero" ,UserId = user.Id, PostId = post.Id},
                    new Comment() { Content = "first" , IsDeleted = true},
                    new Comment() { Content = "second" ,UserId = user.Id, PostId = post.Id},
                    new Comment() { Content = "third" ,UserId = user.Id, PostId = post.Id},
                    new Comment() { Content = "fourth" , IsDeleted = true},
                    new Comment() { Content = "fith" ,UserId = user.Id, PostId = post.Id},
            };

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.Comments.AddRangeAsync(comments);
                await arrangeContext.Posts.AddRangeAsync(post);
                await arrangeContext.Users.AddRangeAsync(user);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new CommentService(actContext, mapper);
                var result = await sut.GetAllAsync();

                Assert.AreEqual(4, result.Count());
            }
        }

        [TestMethod]
        public async Task ReturnZeroElements()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnZeroElements));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new CommentService(actContext, mapper);
                var result = await sut.GetAllAsync();

                Assert.AreEqual(0, result.Count());
            }
        }
    }
}
