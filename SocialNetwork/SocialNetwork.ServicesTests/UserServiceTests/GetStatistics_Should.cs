using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Database;
using SocialNetwork.Models;
using SocialNetwork.Services.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.UserServiceTests
{
    [TestClass]
    public class GetStatistics_Should
    {
        [TestMethod]
        public async Task ReturnUsersCount()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnUsersCount));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var users = Utils.GetUsers();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                users.First().IsDeleted = true;

                await arrangeContext.Users.AddRangeAsync(users);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.GetStatistics();

                Assert.AreEqual(users.Count() - 1, result.Item1);
            }
        }

        [TestMethod]
        public async Task ReturnConnectionsCount()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnConnectionsCount));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var connetions = Utils.GetFriendShips();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                connetions.First().IsDeleted = true;

                await arrangeContext.Friends.AddRangeAsync(connetions);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.GetStatistics();

                Assert.AreEqual((connetions.Count() - 1) / 2, result.Item2);
            }
        }

        [TestMethod]
        public async Task ReturnPostsCount()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnPostsCount));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var posts = Utils.GetPosts();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                posts.First().IsDeleted = true;

                await arrangeContext.Posts.AddRangeAsync(posts);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.GetStatistics();

                Assert.AreEqual(posts.Count() - 1, result.Item3);
            }
        }

        [TestMethod]
        public async Task ReturnCommentsCount()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnCommentsCount));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var commments = new List<Comment>
            {
                new Comment(),
                new Comment()
            };

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                commments.First().IsDeleted = true;

                await arrangeContext.Comments.AddRangeAsync(commments);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.GetStatistics();

                Assert.AreEqual(1, result.Item4);
            }
        }

        [TestMethod]
        public async Task ReturnFullStats()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnFullStats));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var users = Utils.GetUsers();
            var posts = Utils.GetPosts();
            var comments = new List<Comment>();
            var connections = Utils.GetFriendShips();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.Users.AddRangeAsync(users);
                await arrangeContext.Friends.AddRangeAsync(connections);
                await arrangeContext.Posts.AddRangeAsync(posts);
                await arrangeContext.Comments.AddRangeAsync(comments);

                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.GetStatistics();

                Assert.AreEqual(users.Count(), result.Item1);
                Assert.AreEqual(connections.Count() / 2, result.Item2);
                Assert.AreEqual(posts.Count(), result.Item3);
                Assert.AreEqual(comments.Count(), result.Item4);
            }
        }
    }
}
