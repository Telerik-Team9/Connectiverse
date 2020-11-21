using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialNetwork.Database;
using SocialNetwork.Models;
using SocialNetwork.Models.Common.Enums;
using SocialNetwork.Web.AutoMapperConfigs;
using System;
using System.Collections.Generic;

namespace SocialNetwork.ServicesTests
{
    public class Utils
    {
        public static DbContextOptions<SocialNetworkDBContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<SocialNetworkDBContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }

        public static IEnumerable<User> GetUsers()
        {
            return new List<User>()
            {
                new User()  // Admin
                {
                    Id = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),
                    UserName = "magi@mail.com",
                    NormalizedUserName = "MAGI@MAIL.COM",
                    Email = "magi@mail.com",
                    NormalizedEmail = "MAGI@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "0886868686",

                    DisplayName = "Magi Nikolova",
                    DateOfBirth = new DateTime(1997,02,12),
                    Education = "Sofia University",
                    TownId = 1,
                    ProfilePictureId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/magi_profile_pic.jpg"
                }, //Magi
                new User()  // Admin
                {
                    Id = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                    UserName = "ali@mail.com",
                    NormalizedUserName = "ALI@MAIL.COM",
                    Email = "ali@mail.com",
                    NormalizedEmail = "ALI@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "088686843",

                    DisplayName = "Ali Marekov",
                    DateOfBirth = new DateTime(1999, 09, 23),
                    Education = "Technical University",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/ali_profile_pic.jpg"
                }, //Ali
                new User()
                {
                    Id = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"),
                    UserName = "telerik@mail.com",
                    NormalizedUserName = "TELERIK@MAIL.COM",
                    Email = "telerik@mail.com",
                    NormalizedEmail = "TELERIK@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "081111111",

                    DisplayName = "Telerik Academy",
                    DateOfBirth = new DateTime(2010, 11, 1),
                    Education = "Telerik Academy",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/telerik_profile_pic.jpg"
                }, //Telerik
                new User()
                {
                    Id = Guid.Parse("dc6788da-53ae-44e7-b53c-e53a2f77a1af"),
                    UserName = "csharp@mail.com",
                    NormalizedUserName = "CSHARP@MAIL.COM",
                    Email = "csharp@mail.com",
                    NormalizedEmail = "CSHARP@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "0833333333",

                    DisplayName = "C Sharp",
                    DateOfBirth = new DateTime(2010, 11, 1),
                    Education = "Alpha C# Track",
                    TownId = 1,
                    ProfilePictureUrl = "/img/noavatar.jpg"
                }, //CSharp
                new User()
                {
                    Id = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"),
                    UserName = "viktor@mail.com",
                    NormalizedUserName = "VIKTOR@MAIL.COM",
                    Email = "viktor@mail.com",
                    NormalizedEmail = "VIKTOR@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "0884444444",

                    DisplayName = "Viktor Ivanov",
                    DateOfBirth = new DateTime(1996, 12, 12),
                    Education = "Technical University",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/viktor_profile_pic.jpg"
                }, //Viktor
                new User()
                {
                    Id = Guid.Parse("0d852e3a-b977-438a-9c33-7679a6e7b4cd"),
                    UserName = "silvia@mail.com",
                    NormalizedUserName = "SILVIA@MAIL.COM",
                    Email = "silvia@mail.com",
                    NormalizedEmail = "SILVIA@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "088555555",

                    DisplayName = "Silvia Borisova",
                    DateOfBirth = new DateTime(2000, 10, 4),
                    Education = "Sofia University",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/silvia_profile_pic.jpg"
                }, //Silvia
                new User()
                {
                    Id = Guid.Parse("b87071f5-b71c-45e1-91e7-6e85637ed10a"),
                    UserName = "maria@mail.com",
                    NormalizedUserName = "MARIA@MAIL.COM",
                    Email = "maria@mail.com",
                    NormalizedEmail = "MARIA@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "088666666",

                    DisplayName = "Maria Petrova",
                    DateOfBirth = new DateTime(1997, 10, 12),
                    Education = "",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg"
                }  //Maria
            };
        }

        public static IEnumerable<Friend> GetFriendShips()
        {
            return new List<Friend>()
            {
                new Friend
                {
                    Id = 1,
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),          // Magi
                    UserFriendId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5")     // Ali
                }, //Magi-Ali
                new Friend
                {
                    Id = 2,
                    UserId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),          // Ali
                    UserFriendId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270")     // Magi
                }, //Ali-Magi
                new Friend
                {
                    Id = 3,
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),          // Magi
                    UserFriendId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619")     // Telerik
                }, //Magi-Telerik
                new Friend
                {
                    Id = 4,
                    UserId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"),          // Telerik
                    UserFriendId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270")     // Magi
                }, //Telerik-Magi
                new Friend
                {
                    Id = 5,
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),          // Magi
                    UserFriendId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845")     // Viktor
                }, //Magi-Vikor
                new Friend
                {
                    Id = 6,
                    UserId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"),          // Viktor
                    UserFriendId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270")     // Magi
                }, //Viktor-Magi
                new Friend
                {
                    Id = 11,
                    UserId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),          // Ali
                    UserFriendId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845")     // Viktor
                }, //Ali-Viktor
                new Friend
                {
                    Id = 12,
                    UserId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"),          // Viktor
                    UserFriendId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5")     // Ali
                }, //Viktor-Ali
            };
        }

        public static IEnumerable<FriendRequest> GetFriendRequests()
        {
            return new List<FriendRequest>()
            {
                new FriendRequest
                {
                    Id = 1,
                    SenderId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),    // Magi
                    ReceiverId = Guid.Parse("dc6788da-53ae-44e7-b53c-e53a2f77a1af"),    // CSharp 
                }, //Magi-CSharp
                new FriendRequest
                {
                    Id = 5,
                    SenderId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),    // Ali
                    ReceiverId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"),    // Telerik
                }, //Ali-Telerik
            };
        }

        public static IEnumerable<Post> GetPosts()
        {
            return new List<Post>()
            {
                new Post
                {
                    Id = 1,
                    Content = "My new profile photo",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),    // Magi
                    PhotoId = 1
                },
                new Post
                {
                    Id = 2,
                    Content = "My new profile photo",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),    // Ali
                    PhotoId = 2
                },
                new Post
                {
                    Id = 3,
                    Content = "My new profile photo",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"),    // Telerik
                    PhotoId = 3
                },
                new Post
                {
                    Id = 4,
                    Content = "My new profile photo",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"),    // Victor
                    PhotoId = 4
                },
                new Post
                {
                    Id = 5,
                    Content = "My new profile photo",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("0d852e3a-b977-438a-9c33-7679a6e7b4cd"),    // silvia
                    PhotoId = 5
                },
            };
        }

        public static IEnumerable<Photo> GetPhotos()
        {
            return new List<Photo>()
            {
                new Photo
                {
                    Id = 1,
                    PostId = 1,
                    Url = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/magi_profile_pic.jpg"
                },
                new Photo
                {
                    Id = 2,
                    PostId = 2,
                    Url = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/ali_profile_pic.jpg"
                },
                new Photo
                {
                    Id = 3,
                    PostId = 3,
                    Url = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/telerik_profile_pic.jpg"
                },
                new Photo
                {
                    Id = 4,
                    PostId = 4,
                    Url = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/viktor_profile_pic.jpg"
                },
                new Photo
                {
                    Id = 5,
                    PostId = 5,
                    Url = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/silvia_profile_pic.jpg"
                },
            };
        }

        public static MapperConfiguration GetMappingConfig()
        {
            return new MapperConfiguration(opts =>
            {
                opts.AddProfile(typeof(UserVMConfig));
                opts.AddProfile(typeof(PostVMConfig));
                opts.AddProfile(typeof(CommentVMConfig));
                opts.AddProfile(typeof(PhotoVMConfig));
                opts.AddProfile(typeof(FriendRequestVMConfig));
                opts.AddProfile(typeof(FriendVMConfig));
                opts.AddProfile(typeof(SocialMediaVMConfig));
                opts.AddProfile(typeof(LikeVMConfig));
                opts.AddProfile(typeof(TownVMConfig));
            });
        }
    }
}
