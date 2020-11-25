using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Database;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.LikeServiceTests
{
    [TestClass]
    public class LikeAsync_Should
    {
        [TestMethod]
        public async Task ReturnTrueWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnTrueWhen_ValidParams));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var userId1 = Utils.GetUsers().First().Id;

            var postDTO = Mock.Of<PostDTO>(p => p.Content == "This is a new post." &&
                                                p.Visibility == Models.Common.Enums.Visibility.Public &&
                                                p.UserId == userId1);

            //Act
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new LikeService(actContext, mapper);
                var result = await sut.LikeAsync(postDTO);

                Assert.IsTrue(result);
                Assert.AreEqual(1, actContext.Likes.Count());
            }
        }

        [TestMethod]
        public async Task ReturnFalseWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnFalseWhen_ValidParams));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var userId1 = Utils.GetUsers().First().Id;

            var postDTO = Mock.Of<PostDTO>(p => p.Content == "This is a new post." &&
                                                p.Visibility == Models.Common.Enums.Visibility.Public &&
                                                p.UserId == userId1);

            //Act
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new LikeService(actContext, mapper);
                var result = await sut.LikeAsync(postDTO);
            }
            //Act
            using (var assertContext = new SocialNetworkDBContext(options))
            {
                var sut = new LikeService(assertContext, mapper);
                var result = await sut.LikeAsync(postDTO);

                Assert.IsFalse(result);
                Assert.AreEqual(1, assertContext.Likes.Count());
            }

        }
    }
}
