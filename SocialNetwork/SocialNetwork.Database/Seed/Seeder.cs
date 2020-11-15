using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models;
using SocialNetwork.Models.Common.Enums;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Database.Seeder
{
    public static class Seeder
    {
        public static void Seed(this ModelBuilder builder)
        {
            // Roles
            var roles = new List<Role>()
            {
                new Role
                {
                    Id = Guid.Parse("943b692d-330e-405d-a019-c3d728442143"),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new Role
                {
                    Id = Guid.Parse("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"),
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<Role>().HasData(roles);

            // Users
            var users = new List<User>()
            {
                new User()  // Admin
                {
                    Id = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),
                    UserName = "magi@mail.com",
                    NormalizedUserName = "MAGI@MAIL.COM",
                    Email = "magi@mail.com",
                    NormalizedEmail = "MAGI@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),

                    DisplayName = "Magi Nikolova",
                    DateOfBirth = new DateTime(1997,02,12),
                    Education = "Sofia University",
                    TownId = 1,
                    ProfilePictureId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/magi_profile_pic.jpg"
                },
                new User()  // Admin
                {
                    Id = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                    UserName = "ali@mail.com",
                    NormalizedUserName = "ALI@MAIL.COM",
                    Email = "ali@mail.com",
                    NormalizedEmail = "ALI@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),

                    DisplayName = "Ali Marekov",
                    DateOfBirth = new DateTime(1999, 09, 23),
                    Education = "Technical University",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/ali_profile_pic.jpg"
                },
                new User()
                {
                    Id = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"),
                    UserName = "telerik@mail.com",
                    NormalizedUserName = "TELERIK@MAIL.COM",
                    Email = "telerik@mail.com",
                    NormalizedEmail = "TELERIK@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),

                    DisplayName = "Telerik Academy",
                    DateOfBirth = new DateTime(2010, 11, 1),
                    Education = "Telerik Academy",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/telerik_profile_pic.jpg"
                },
                new User()
                {
                    Id = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"),
                    UserName = "lovecsharp@mail.com",
                    NormalizedUserName = "LOVECSHARP@MAIL.COM",
                    Email = "lovecsharp@mail.com",
                    NormalizedEmail = "LOVECSHARP@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),

                    DisplayName = "Viktor Ivanov",
                    DateOfBirth = new DateTime(1996, 12, 12),
                    Education = "Technical University",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/viktor_profile_pic.jpg"
                },
                new User()
                {
                    Id = Guid.Parse("0d852e3a-b977-438a-9c33-7679a6e7b4cd"),
                    UserName = "silvia@mail.com",
                    NormalizedUserName = "SILVIA@MAIL.COM",
                    Email = "silvia@mail.com",
                    NormalizedEmail = "SILVIA@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),

                    DisplayName = "Silvia Borisova",
                    DateOfBirth = new DateTime(2000, 10, 4),
                    Education = "Sofia University",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/silvia_profile_pic.jpg"
                },
                new User()
                {
                    Id = Guid.Parse("b87071f5-b71c-45e1-91e7-6e85637ed10a"),
                    UserName = "maria@mail.com",
                    NormalizedUserName = "MARIA@MAIL.COM",
                    Email = "maria@mail.com",
                    NormalizedEmail = "MARIA@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),

                    DisplayName = "Maria Petrova",
                    DateOfBirth = new DateTime(1997, 10, 12),
                    Education = "Sofia University",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg"
                },
                new User()
                {
                    Id = Guid.Parse("5d7ccf05-3080-4a9e-90ca-a4fee33aa196"),
                    UserName = "pablo@mail.com",
                    NormalizedUserName = "PABLO@MAIL.COM",
                    Email = "pablo@mail.com",
                    NormalizedEmail = "PABLO@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),

                    DisplayName = "Pablo Georgiev",
                    DateOfBirth = new DateTime(1996, 12, 12),
                    Education = "Technical University",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/pablo_profile_pic.jpg"
                },
                new User()
                {
                    Id = Guid.Parse("7f8793ff-03ab-458c-bc0e-ed4866a55b48"),
                    UserName = "georgi@mail.com",
                    NormalizedUserName = "GEORGI@MAIL.COM",
                    Email = "georgi@mail.com",
                    NormalizedEmail = "GEORGI@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),

                    DisplayName = "Georgi Georgiev",
                    DateOfBirth = new DateTime(1976, 12, 12),
                    Education = "UNWE",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg"
                },
                new User()
                {
                    Id = Guid.Parse("d6f66ad9-58c9-43d6-adf8-4adbc3a97d36"),
                    UserName = "alexandra@mail.com",
                    NormalizedUserName = "ALEXANDRA@MAIL.COM",
                    Email = "alexandra@mail.com",
                    NormalizedEmail = "ALEXANDRA@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),

                    DisplayName = "Alexandra Kirova",
                    DateOfBirth = new DateTime(1999, 12, 12),
                    Education = "Sofia University",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/alexandra_profile_pic.jpg"
                },
                new User()
                {
                    Id = Guid.Parse("a9e49452-8ffd-460d-9998-8f662e36a2d6"),
                    UserName = "Stanislav@mail.com",
                    NormalizedUserName = "STANISLAV@MAIL.COM",
                    Email = "stanisav@mail.com",
                    NormalizedEmail = "STANISLAV@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),

                    DisplayName = "Stanislav Pulev",
                    DateOfBirth = new DateTime(2000, 12, 12),
                    Education = "UNWE",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg"
                },
                new User()
                {
                    Id = Guid.Parse("35547a2a-8779-416b-9fc8-7aab34e883bd"),
                    UserName = "Nikol@mail.com",
                    NormalizedUserName = "NIKOL@MAIL.COM",
                    Email = "nikol@mail.com",
                    NormalizedEmail = "NIKOL@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),

                    DisplayName = "Nikol Peeva",
                    DateOfBirth = new DateTime(1999, 12, 12),
                    Education = "Sofia University",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg"
                },
            };
            var hasher = new PasswordHasher<User>();
            users[0].PasswordHash = hasher.HashPassword(users[0], "magi123");
            users[1].PasswordHash = hasher.HashPassword(users[1], "ali123");
            users[2].PasswordHash = hasher.HashPassword(users[2], "telerik123");
            users[3].PasswordHash = hasher.HashPassword(users[3], "viktor123");
            users[4].PasswordHash = hasher.HashPassword(users[4], "silvia123");
            users[5].PasswordHash = hasher.HashPassword(users[5], "maria123");
            users[6].PasswordHash = hasher.HashPassword(users[6], "pablo123");
            users[7].PasswordHash = hasher.HashPassword(users[7], "georgi123");
            users[8].PasswordHash = hasher.HashPassword(users[8], "alexandra123");
            users[9].PasswordHash = hasher.HashPassword(users[9], "stanislav123");
            users[10].PasswordHash = hasher.HashPassword(users[10], "nikol123");
            builder.Entity<User>().HasData(users);

            // UserRoles
            var userRoles = new List<IdentityUserRole<Guid>>()
            {
                new IdentityUserRole<Guid>()
                {
                    RoleId = Guid.Parse("943b692d-330e-405d-a019-c3d728442143"),    // Admin
                    UserId = users[0].Id
                },
                new IdentityUserRole<Guid>()
                {
                    RoleId = Guid.Parse("943b692d-330e-405d-a019-c3d728442143"),    // Admin
                    UserId = users[1].Id
                },
                new IdentityUserRole<Guid>()
                {
                    RoleId = Guid.Parse("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"),    // User
                    UserId = users[2].Id
                },
                new IdentityUserRole<Guid>()
                {
                    RoleId = Guid.Parse("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"),    // User
                    UserId = users[3].Id
                },
                new IdentityUserRole<Guid>()
                {
                    RoleId = Guid.Parse("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"),    // User
                    UserId = users[4].Id
                },
                new IdentityUserRole<Guid>()
                {
                    RoleId = Guid.Parse("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"),    // User
                    UserId = users[5].Id
                },
                new IdentityUserRole<Guid>()
                {
                    RoleId = Guid.Parse("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"),    // User
                    UserId = users[6].Id
                },
                new IdentityUserRole<Guid>()
                {
                    RoleId = Guid.Parse("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"),    // User
                    UserId = users[7].Id
                },
                new IdentityUserRole<Guid>()
                {
                    RoleId = Guid.Parse("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"),    // User
                    UserId = users[8].Id
                },
                new IdentityUserRole<Guid>()
                {
                    RoleId = Guid.Parse("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"),    // User
                    UserId = users[9].Id
                },
            };
            builder.Entity<IdentityUserRole<Guid>>().HasData(userRoles);

            // Other
            var comments = new HashSet<Comment>()
            {
                new Comment
                {
                    Id = 1,
                    Content = "This is Amazing!",
                    PostId = 1,
                    UserId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),    // Ali
                },
                new Comment
                {
                    Id = 2,
                    Content = "This is Awful!",
                    PostId = 20,
                    UserId= Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619") // Telerik
                }
            };
            builder.Entity<Comment>().HasData(comments);

            var countries = new HashSet<Country>()
            {
                new Country
                {
                    Id = 1,
                    Name = "Bulgaria",
                    ISO = "BG"
                },
                new Country
                {
                    Id = 2,
                    Name = "Belgium",
                    ISO = "BE"
                },
                new Country
                {
                    Id = 3,
                    Name = "Netherlands",
                    ISO = "NL"
                },
                new Country
                {
                    Id = 4,
                    Name = "Ireland",
                    ISO = "IE"
                },
                new Country
                {
                    Id = 5,
                    Name = "Mexico",
                    ISO = "MX"
                },
                new Country
                {
                    Id = 6,
                    Name = "United Kingdom",
                    ISO = "UK"
                },
                new Country
                {
                    Id = 7,
                    Name = "Serbia",
                    ISO = "RS"
                },
                new Country
                {
                    Id = 8,
                    Name = "Germany",
                    ISO = "DE"
                },
            };
            builder.Entity<Country>().HasData(countries);

            var towns = new HashSet<Town>()
            {
                new Town
                {
                    Id = 1,
                    Name = "Sofia",
                    CountryId = 1   // Bulgaria
                }
            };
            builder.Entity<Town>().HasData(towns);

            var friends = new HashSet<Friend>()
            {
                new Friend
                {
                    Id = 1,
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),          // Magi
                    UserFriendId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5")     // Ali
                },
                new Friend
                {
                    Id = 2,
                    UserId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),          // Ali
                    UserFriendId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270")     // Magi
                },
                new Friend
                {
                    Id = 3,
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),          // Magi
                    UserFriendId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619")     // Telerik
                },
                new Friend
                {
                    Id = 4,
                    UserId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"),          // Ali
                    UserFriendId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270")     // Magi
                },
                new Friend
                {
                    Id = 5,
                    UserId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"),          // Telerik
                    UserFriendId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845")     // Viktor
                },
                new Friend
                {
                    Id = 6,
                    UserId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"),          // Viktor
                    UserFriendId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619")     // Telerik
                },


                new Friend
                {
                    Id = 7,
                    UserId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),          // Ali
                    UserFriendId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845")     // Viktor
                },
                new Friend
                {
                    Id = 8,
                    UserId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"),          // Viktor
                    UserFriendId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5")     // Ali
                },


                new Friend
                {
                    Id = 9,
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),          // Magi
                    UserFriendId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845")     // Viktor
                },
                new Friend
                {
                    Id = 10,
                    UserId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"),          // Viktor
                    UserFriendId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270")     // Magi
                },

                new Friend
                {
                    Id = 11,
                    UserId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),          // Ali
                    UserFriendId = Guid.Parse("0D852E3A-B977-438A-9C33-7679A6E7B4CD")     // Silvia
                },
                new Friend
                {
                    Id = 12,
                    UserId = Guid.Parse("0D852E3A-B977-438A-9C33-7679A6E7B4CD"),          // Silvia
                    UserFriendId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5")     // Ali
                },

                new Friend
                {
                    Id = 13,
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),          // Magi
                    UserFriendId = Guid.Parse("0D852E3A-B977-438A-9C33-7679A6E7B4CD")     // Silvia
                },
                new Friend
                {
                    Id = 15,
                    UserId = Guid.Parse("0D852E3A-B977-438A-9C33-7679A6E7B4CD"),          // Silvia
                    UserFriendId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270")     // Magi
                },

                new Friend
                {
                    Id = 16,
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),          // Magi
                    UserFriendId = Guid.Parse("B87071F5-B71C-45E1-91E7-6E85637ED10A")     // Maria
                },
                new Friend
                {
                    Id = 17,
                    UserId = Guid.Parse("B87071F5-B71C-45E1-91E7-6E85637ED10A"),          // Maria
                    UserFriendId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270")     // Magi
                },
            };
            builder.Entity<Friend>().HasData(friends);

            var friendRequests = new HashSet<FriendRequest>()
            {
                new FriendRequest
                {
                    Id = 1,
                    SenderId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),    // Magi
                    ReceiverId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"),    // Telerik
                },
                new FriendRequest
                {
                    Id = 2,
                    SenderId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),    // Ali
                    ReceiverId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"),    // Telerik
                },
                new FriendRequest
                {
                    Id = 3,
                    SenderId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),    // Ali
                    ReceiverId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"),    // CSharp 
                }
            };
            builder.Entity<FriendRequest>().HasData(friendRequests);

            var posts = new HashSet<Post>()
            {
                new Post
                {
                    Id = 1,
                    Content = "Does anyone know any great restaurants near by?",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),    // Ali
                },
                new Post
                {
                    Id = 10,
                    Content = "A photo of one of my favourite things:",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),    // Magi
                    PhotoId = 1
                },
                new Post
                {
                    Id = 20,
                    Content = "Really funny video :)",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"),    // Telerik
                    VideoId = 1
                }
            };
            builder.Entity<Post>().HasData(posts);

            var photos = new HashSet<Photo>()
            {
                new Photo
                {
                    Id = 1,
                    PostId = 10,
                    Url = "YEYEYYE"
                }
            };
            builder.Entity<Photo>().HasData(photos);

            var videos = new HashSet<Video>()
            {
                new Video
                {
                    Id = 1,
                    PostId = 20,
                    Url = "NONONONO"
                }
            };
            builder.Entity<Video>().HasData(videos);

            var likes = new HashSet<Like>()
            {
                new Like
                {
                    Id = 1,
                    PostId = 1,
                    UserId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619") // Telerik
                }
            };
            builder.Entity<Like>().HasData(likes);

            var socialMedias = new HashSet<SocialMedia>()
            {
                new SocialMedia
                {
                    Id = 1,
                    Name = "Instagram",
                    IconUrl = "",
                    UserLink = "https://www.instagram.com/magisnikolova",
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),    // Magi
                }
            };
            builder.Entity<SocialMedia>().HasData(socialMedias);
        }
    }
}
