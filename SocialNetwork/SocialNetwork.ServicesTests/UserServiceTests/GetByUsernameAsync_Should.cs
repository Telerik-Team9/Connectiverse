using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Database;
using SocialNetwork.Services.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.ServicesTests.UserServiceTests
{
    [TestClass]
    public class GetByUsernameAsync_Should
    {
        [TestMethod]
        public async Task ReturnUsersOrderedAlphabeticallyWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnUsersOrderedAlphabeticallyWhen_ValidParams));
            var users = Utils.GetUsers().OrderBy(x => x.DisplayName).ToList();

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.Users.AddRangeAsync(users);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.GetByUserNameAsync(searchCriteria: "a", sortOrder: "nameAsc");
                var arr = result.ToArray();

                for (int i = 0; i < users.Count; i++)
                {
                    Assert.AreEqual(users[i].Id, arr[i].Id);
                    Assert.AreEqual(users[i].DisplayName, arr[i].DisplayName);
                }
            }
        }

        [TestMethod]
        public async Task ReturnUsersOrderedChronologicallyWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnUsersOrderedChronologicallyWhen_ValidParams));
            var users = Utils.GetUsers().OrderByDescending(x => x.CreatedOn).ToList();

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.Users.AddRangeAsync(users);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.GetByUserNameAsync(searchCriteria: "a", sortOrder: "mostRecent");
                var arr = result.ToArray();

                for (int i = 0; i < users.Count; i++)
                {
                    Assert.AreEqual(users[i].Id, arr[i].Id);
                    Assert.AreEqual(users[i].CreatedOn, arr[i].CreatedOn);
                }
            }
        }

        [TestMethod]
        public async Task ReturnUsersOrderedAlphabeticallyDescWhen_ValidParams()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ReturnUsersOrderedAlphabeticallyDescWhen_ValidParams));
            var users = Utils.GetUsers().OrderByDescending(x => x.DisplayName).ToList();

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                await arrangeContext.Users.AddRangeAsync(users);
                await arrangeContext.SaveChangesAsync();
            }

            //Act & Assert
            using (var actContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(actContext, mapper);
                var result = await sut.GetByUserNameAsync(searchCriteria: "a", sortOrder: "nameDesc");
                var arr = result.ToArray();

                for (int i = 0; i < users.Count; i++)
                {
                    Assert.AreEqual(users[i].Id, arr[i].Id);
                    Assert.AreEqual(users[i].DisplayName, arr[i].DisplayName);
                }
            }
        }

        [TestMethod]
        public async Task ThrowWhen_InvalidParams()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(ThrowWhen_InvalidParams));

            var config = Utils.GetMappingConfig();
            var mapper = config.CreateMapper();

            using (var arrangeContext = new SocialNetworkDBContext(options))
            {
                var sut = new UserService(arrangeContext, mapper);
                await Assert.ThrowsExceptionAsync<ArgumentException>
                     (async () => await sut.GetByUserNameAsync("", ""));
            }
        }
    }
}