using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Database;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.CommentServiceTests
{
    [TestClass]
    public class CreateAsync_Should
    {
        [TestMethod]
        public async Task SuccessWhen_ValidParams12()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SuccessWhen_ValidParams12));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var userId = Utils.GetUsers().First().Id;
            var postId = Utils.GetPosts().First().Id;

            var commentDTO = Mock.Of<CommentDTO>(x => x.PostId == postId
                                                   && x.UserId == userId
                                                   && x.Content == "Comment");

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                var posts = Utils.GetPosts();
                var users = Utils.GetUsers();

                await arrangeContext.Posts.AddRangeAsync(posts);
                await arrangeContext.Users.AddRangeAsync(users);
                await arrangeContext.SaveChangesAsync();
            }

            //Act
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new CommentService(actContext, mapper);
                var result = await sut.CreateAsync(commentDTO);
            }

            //Assert
            using (var assertContxt = new SocialNetworkDBContext(options))
            {
                var comment = await assertContxt.Comments.FirstOrDefaultAsync();

                Assert.AreEqual(comment.Content, commentDTO.Content);
                Assert.AreEqual(comment.PostId, commentDTO.PostId);
                Assert.AreEqual(comment.UserId, commentDTO.UserId);
            }
        }

        [TestMethod]
        public async Task ThrowWhen_DTOisNull()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_DTOisNull));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new CommentService(actContext, mapper);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await sut.CreateAsync(null));
            }
        }

        [TestMethod]
        public async Task ThrowWhen_InvalidPost()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_InvalidPost));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var userId = Utils.GetUsers().First().Id;
            var commentDTO = Mock.Of<CommentDTO>(x => x.PostId == 0);
            //Act
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new CommentService(actContext, mapper);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await sut.CreateAsync(commentDTO));
            }
        }

        [TestMethod]
        public async Task ThrowWhen_InvalidUser()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_InvalidUser));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var postId = Utils.GetPosts().First().Id;
            var commentDTO = Mock.Of<CommentDTO>(x => x.UserId == Guid.Empty && x.PostId == postId);

            //Act
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new CommentService(actContext, mapper);

                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.CreateAsync(commentDTO));
            }
        }

        [TestMethod]
        public async Task ThrowWhen_PostNotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_PostNotFound));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var postId = Utils.GetPosts().First().Id;
            var commentDTO = Mock.Of<CommentDTO>(x => x.UserId == Guid.Empty && x.PostId == postId);


            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                var post = Utils.GetPosts().First();
                post.IsDeleted = true;

                await arrangeContext.Posts.AddAsync(post);
                await arrangeContext.SaveChangesAsync();
            }

            //Act
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new CommentService(actContext, mapper);
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.CreateAsync(commentDTO));
            }
        }

        [TestMethod]
        public async Task ThrowWhen_UserNotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_UserNotFound));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var userId = Utils.GetUsers().First().Id;
            var postId = Utils.GetPosts().First().Id;

            var commentDTO = Mock.Of<CommentDTO>(x => x.UserId == userId && x.PostId == postId);

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                var post = Utils.GetUsers().First();
                post.IsDeleted = true;

                await arrangeContext.Users.AddAsync(post);
                await arrangeContext.SaveChangesAsync();
            }

            //Act
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new CommentService(actContext, mapper);
                await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await sut.CreateAsync(commentDTO));
            }
        }
    }
}
