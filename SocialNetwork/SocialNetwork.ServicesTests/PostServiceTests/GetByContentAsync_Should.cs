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
    public class GetByContentAsync_Should
    {
        [TestMethod]
        public async Task ThrowWhen_InvalidParams17()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_InvalidParams17));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var azureBlobService = Mock.Of<IAzureBlobService>();

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new PostService(actContext, azureBlobService, mapper);

                await Assert.ThrowsExceptionAsync<ArgumentException>
                    (async () => await sut.GetByContentAsync(null, default));
            }
        }

        [TestMethod]
        public async Task OrderByContentAsc()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(OrderByContentAsc));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var posts = Utils.GetPosts().Where(x => x.Content.Contains("photo")).OrderBy(x => x.Content);
            var users = Utils.GetUsers();
            var azureBlobService = Mock.Of<IAzureBlobService>();

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
                var result = await sut.GetByContentAsync("photo", "nameAsc");

                Assert.AreEqual(posts.First().Id, result.First().Id);
                Assert.AreEqual(posts.Skip(1).First().Id, result.Skip(1).First().Id);
                Assert.AreEqual(posts.Skip(2).First().Id, result.Skip(2).First().Id);
                Assert.AreEqual(posts.Count(), result.Count());
            }
        }

        [TestMethod]
        public async Task OrderByContentDesc()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(OrderByContentDesc));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var posts = Utils.GetPosts().Where(x => x.Content.Contains("photo")).OrderByDescending(x => x.Content);
            var users = Utils.GetUsers();
            var azureBlobService = Mock.Of<IAzureBlobService>();

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
                var result = await sut.GetByContentAsync("photo", "nameDesc");

                Assert.AreEqual(posts.First().Id, result.First().Id);
                Assert.AreEqual(posts.Skip(1).First().Id, result.Skip(1).First().Id);
                Assert.AreEqual(posts.Skip(2).First().Id, result.Skip(2).First().Id);
                Assert.AreEqual(posts.Count(), result.Count());
            }
        }

        [TestMethod]
        public async Task OrderByDate()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(OrderByDate));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var posts = Utils.GetPosts().Where(x => x.Content.Contains("photo")).OrderByDescending(x => x.CreatedOn);
            var users = Utils.GetUsers();
            var azureBlobService = Mock.Of<IAzureBlobService>();

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
                var result = await sut.GetByContentAsync("photo", "mostRecent");

                Assert.AreEqual(posts.First().Id, result.First().Id);
                Assert.AreEqual(posts.Skip(1).First().Id, result.Skip(1).First().Id);
                Assert.AreEqual(posts.Skip(2).First().Id, result.Skip(2).First().Id);
                Assert.AreEqual(posts.Count(), result.Count());
            }
        }

        [TestMethod]
        public async Task ReturnCorrectCountIfDeletedPosts()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnCorrectCountIfDeletedPosts));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var posts = Utils.GetPosts().Where(x => x.Content.Contains("photo")).OrderBy(x => x.Content);
            var users = Utils.GetUsers();
            var azureBlobService = Mock.Of<IAzureBlobService>();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                posts.First().IsDeleted = true;
                posts.Skip(1).First().IsDeleted = true;

                await arrangeContext.Posts.AddRangeAsync(posts);
                await arrangeContext.Users.AddRangeAsync(users);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new PostService(actContext, azureBlobService, mapper);
                var result = await sut.GetByContentAsync("photo", "nameAsc");

                Assert.AreEqual(posts.Skip(2).First().Id, result.First().Id);
                Assert.AreEqual(posts.Count() - 2, result.Count());
            }
        }
    }
}
