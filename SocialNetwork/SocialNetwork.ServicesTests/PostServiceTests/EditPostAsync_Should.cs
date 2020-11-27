using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Database;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services;
using SocialNetwork.Services.Services.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.PostServiceTests
{
    [TestClass]
    public class EditPostAsync_Should
    {
        [TestMethod]
        public async Task SuccessWhen_ValidParams16()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SuccessWhen_ValidParams16));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var user = Utils.GetUsers().First();
            var postDTO = Mock.Of<PostDTO>(p => p.Id == 25
                                             && p.Content == "This is a new post."
                                             && p.Visibility == Models.Common.Enums.Visibility.OnlyMe
                                             && p.UserId == user.Id);

            var azureBlobService = Mock.Of<IAzureBlobService>();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                var post = mapper.Map<Post>(postDTO);
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.Posts.AddAsync(post);
                await arrangeContext.SaveChangesAsync();
            }

            postDTO.Content = "modified";
            postDTO.Visibility = Models.Common.Enums.Visibility.Public;
            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new PostService(actContext, azureBlobService, mapper);
                var result = await sut.EditPostAsync(postDTO);

                Assert.AreEqual("modified", result.Content);
                Assert.AreEqual(postDTO.Visibility, result.Visibility);
                Assert.IsNotNull(result.ModifiedOn);
            }
        }

        [TestMethod]
        public async Task ThrowWhen_InvalidParams16()
        {

            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_InvalidParams16));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var user = Utils.GetUsers().First();
            var postDTO = Mock.Of<PostDTO>(p => p.Id == 25
                                             && p.Content == "This is a new post."
                                             && p.Visibility == Models.Common.Enums.Visibility.OnlyMe
                                             && p.UserId == user.Id);

            var azureBlobService = Mock.Of<IAzureBlobService>();

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new PostService(actContext, azureBlobService, mapper);

                await Assert.ThrowsExceptionAsync<ArgumentException>
                    (async () => await sut.EditPostAsync(postDTO));
            }
        }

        [TestMethod]
        public async Task ThrowWhen_PostIsDeleted()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_PostIsDeleted));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var user = Utils.GetUsers().First();
            var postDTO = Mock.Of<PostDTO>(p => p.Id == 25
                                             && p.Content == "This is a new post."
                                             && p.Visibility == Models.Common.Enums.Visibility.OnlyMe
                                             && p.UserId == user.Id);

            var azureBlobService = Mock.Of<IAzureBlobService>();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                var post = mapper.Map<Post>(postDTO);
                post.IsDeleted = true;

                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.Posts.AddAsync(post);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new PostService(actContext, azureBlobService, mapper);

                await Assert.ThrowsExceptionAsync<ArgumentException>
                    (async () => await sut.EditPostAsync(postDTO));
            }
        }
    }
}
