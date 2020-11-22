using AutoMapper;
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
    public class CreateAsync_Should
    {
        [TestMethod]
        public async Task CreatePostWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreatePostWhen_ValidParams));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var user = Utils.GetUsers().First();
            var postDTO = Mock.Of<PostDTO>(p => p.Content == "This is a new post." && p.Visibility == Models.Common.Enums.Visibility.OnlyMe);
            postDTO.UserId = user.Id;
            var azureBlobService = Mock.Of<IAzureBlobService>();
            /*var mapper = Mock.Of<IMapper>();*/

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.Users.AddAsync(user);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new PostService(actContext, azureBlobService, mapper);
                var result = await sut.CreateAsync(postDTO);

                Assert.IsNotNull(result);
                Assert.AreEqual(1, actContext.Posts.Count());
                Assert.AreEqual(postDTO.Content, actContext.Posts.First().Content);
            }
        }

        [TestMethod]
        public async Task ThrowWhen_InvalidParams()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_InvalidParams));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();
            var azureBlobService = Mock.Of<IAzureBlobService>();

            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new PostService(actContext, azureBlobService, mapper);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                     (async () => await sut.CreateAsync(null));
            }
        }
    }
}
