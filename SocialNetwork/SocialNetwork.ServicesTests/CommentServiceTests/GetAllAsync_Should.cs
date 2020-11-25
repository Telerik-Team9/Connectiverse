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
            var comments = new Comment[]
            {
                    new Comment() { Content = "zero" },
                    new Comment() { Content = "first" , IsDeleted = true},
                    new Comment() { Content = "second" },
                    new Comment() { Content = "third" },
                    new Comment() { Content = "fourth" , IsDeleted = true},
                    new Comment() { Content = "fith" },
            };

            var posts = Utils.GetPosts();
            var users = Utils.GetUsers();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.Comments.AddRangeAsync(comments);
                await arrangeContext.Posts.AddRangeAsync(posts);
                await arrangeContext.Users.AddRangeAsync(users);
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
