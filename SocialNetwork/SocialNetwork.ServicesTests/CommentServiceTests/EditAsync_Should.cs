using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Database;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services;
using System;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.CommentServiceTests
{

    [TestClass]
    public class EditAsync_Should
    {
        [TestMethod]
        public async Task SuccessWhen_ValidParams13()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SuccessWhen_ValidParams13));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var dto = Mock.Of<CommentDTO>(x => x.Id == 1 && x.Content == "After");

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                var comment = new Comment()
                {
                    Content = "Before"
                };
                await arrangeContext.Comments.AddAsync(comment);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new CommentService(actContext, mapper);
                var result = await sut.EditAsync(dto);

                Assert.AreEqual(dto.Content, result.Content);
            }
        }

        [TestMethod]
        public async Task ThrowWhen_CommentDeleted()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_CommentDeleted));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var dto = Mock.Of<CommentDTO>(x => x.Id == 1 && x.Content == "After");

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                var comment = new Comment()
                {
                    Content = "Before",
                    IsDeleted = true
                };
                await arrangeContext.Comments.AddAsync(comment);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new CommentService(actContext, mapper);

                await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
                {
                    await sut.EditAsync(dto);
                });
            }
        }

        [TestMethod]
        public async Task ThrowWhen_CommentNotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_CommentNotFound));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var dto = Mock.Of<CommentDTO>(x => x.Id == 1 && x.Content == "After");

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new CommentService(actContext, mapper);

                await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
                {
                    await sut.EditAsync(dto);
                });
            }
        }
    }
}
