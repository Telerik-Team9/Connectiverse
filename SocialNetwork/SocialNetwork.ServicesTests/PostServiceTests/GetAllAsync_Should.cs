using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Database;
using SocialNetwork.Services.Services;
using SocialNetwork.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.PostServiceTests
{
    [TestClass]
    public class GetAllAsync_Should
    {
        [TestMethod]
        public async Task ReturnCorrectPosts()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnCorrectPosts));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();
            var azureBlobService = Mock.Of<IAzureBlobService>();

            var posts = Utils.GetPosts();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.Posts.AddRangeAsync(posts);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new PostService(actContext, azureBlobService, mapper);
                var result = await sut.GetAllAsync();

                Assert.IsNotNull(result);
                Assert.AreEqual(posts.ToList().Count(), result.Count());
                Assert.AreEqual(posts.First().Id, result.First().Id);
                Assert.AreEqual(posts.Skip(1).First().Id, result.Skip(1).First().Id);
                Assert.AreEqual(posts.Skip(2).First().Id, result.Skip(2).First().Id);
            }
        }
    }
}
