using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Database;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.LikeServiceTests
{
    [TestClass]
    public class DislikeAsync_Should
    {
        [TestMethod]
        public async Task ReturnTrueWhen_ValidParams1()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnTrueWhen_ValidParams1));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var userId1 = Utils.GetUsers().First().Id;

            var postDTO = Mock.Of<PostDTO>(p => p.Content == "This is a new post." &&
                                                p.Visibility == Models.Common.Enums.Visibility.Public &&
                                                p.UserId == userId1);

            //Act
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var like = new Like
                {
                    PostId = postDTO.Id,
                    UserId = userId1
                };

                await actContext.Likes.AddAsync(like);
                await actContext.SaveChangesAsync();
            }

            //Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new LikeService(actContext, mapper);
                var result = await sut.DislikeAsync(postDTO);

                Assert.IsFalse(result);
                Assert.AreEqual(0, actContext.Likes.Count());
            }
        }

        [TestMethod]
        public async Task ReturnFalseWhen_ValidParams1()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnFalseWhen_ValidParams1));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var userId1 = Utils.GetUsers().First().Id;

            var postDTO = Mock.Of<PostDTO>(p => p.Content == "This is a new post." &&
                                                p.Visibility == Models.Common.Enums.Visibility.Public &&
                                                p.UserId == userId1);

            //Act
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var like = new Like
                {
                    PostId = postDTO.Id,
                    UserId = userId1
                };

                await actContext.Likes.AddAsync(like);
                await actContext.SaveChangesAsync();
            }
            using (var assertContext = new SocialNetworkDBContext(options))
            {
                var sut = new LikeService(assertContext, mapper);
                var result = await sut.DislikeAsync(postDTO);

                Assert.IsFalse(result);
                Assert.AreEqual(0, assertContext.Likes.Count());
            }

        }
    }
}
