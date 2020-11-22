using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SocialNetwork.Database;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.UserServiceTests
{
    [TestClass]
    public class CreateSocialMediaAsync_Should
    {
        [TestMethod]
        public async Task SuccessWhen_ValidParams8()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(SuccessWhen_ValidParams8));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            var dto = Mock.Of<SocialMediaDTO>();

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.CreateSocialMediaAsync(dto);

                Assert.IsNotNull(result);
                Assert.AreEqual(1, actContext.SocialMedias.Count());
            }
        }

        [TestMethod]
        public async Task ThrowWhen_InvalidParams8()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_InvalidParams8));
            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                     (async () => await sut.CreateSocialMediaAsync(default));
            }
        }
    }
}
