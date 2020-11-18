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
                    PhoneNumber = "0886868686",

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
                    PhoneNumber = "088686843",

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
                    PhoneNumber = "081111111",

                    DisplayName = "Telerik Academy",
                    DateOfBirth = new DateTime(2010, 11, 1),
                    Education = "Telerik Academy",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/telerik_profile_pic.jpg"
                },
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
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg"
                },
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
                },
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
                },
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
                    PhoneNumber = "087777777",

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
                    PhoneNumber = "0888888888",

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
                    PhoneNumber = "088899989",

                    DisplayName = "Alexandra Kirova",
                    DateOfBirth = new DateTime(1999, 12, 12),
                    Education = "Sofia University",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/alexandra_profile_pic.jpg"
                },
                new User()
                {
                    Id = Guid.Parse("a9e49452-8ffd-460d-9998-8f662e36a2d6"),
                    UserName = "stanislav@mail.com",
                    NormalizedUserName = "STANISLAV@MAIL.COM",
                    Email = "stanisav@mail.com",
                    NormalizedEmail = "STANISLAV@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "088679446",

                    DisplayName = "Stanislav Pulev",
                    DateOfBirth = new DateTime(2000, 12, 12),
                    Education = "UNWE",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg"
                },
                new User()
                {
                    Id = Guid.Parse("35547a2a-8779-416b-9fc8-7aab34e883bd"),
                    UserName = "nikol@mail.com",
                    NormalizedUserName = "NIKOL@MAIL.COM",
                    Email = "nikol@mail.com",
                    NormalizedEmail = "NIKOL@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "08868324",

                    DisplayName = "Nikol Peeva",
                    DateOfBirth = new DateTime(1999, 12, 12),
                    Education = "Sofia University",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg"
                },
                new User()
                {
                    Id = Guid.Parse("d93d2d61-e0ce-4a8d-9d61-93c8bc2849d7"),
                    UserName = "radko@mail.com",
                    NormalizedUserName = "RADKO@MAIL.COM",
                    Email = "radko@mail.com",
                    NormalizedEmail = "RADKO@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "545453423",

                    DisplayName = "Radko Stanev",
                    DateOfBirth = new DateTime(1990, 12, 10),
                    Education = "Telerik Academy",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg"
                },
                new User()
                {
                    Id = Guid.Parse("5acf2b77-ab0a-4a04-8a5a-9ec38ffab96b"),
                    UserName = "kiro@mail.com",
                    NormalizedUserName = "KIRO@MAIL.COM",
                    Email = "kiro@mail.com",
                    NormalizedEmail = "KIRO@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "5435345345",

                    DisplayName = "Kiro Stanoev",
                    DateOfBirth = new DateTime(1990, 1, 10),
                    Education = "Telerik Academy",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg"
                },
                new User()
                {
                    Id = Guid.Parse("6405b148-f626-4142-a342-0ccd2c82c30f"),
                    UserName = "bobi@mail.com",
                    NormalizedUserName = "BOBI@MAIL.COM",
                    Email = "bobi@mail.com",
                    NormalizedEmail = "BOBI@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PhoneNumber = "653534564",

                    DisplayName = "Bobi Hadzhiev",
                    DateOfBirth = new DateTime(1990, 2, 06),
                    Education = "Telerik Academy",
                    TownId = 1,
                    ProfilePictureUrl = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg"
                }
            };
            var hasher = new PasswordHasher<User>();
            users[0].PasswordHash = hasher.HashPassword(users[0], "magi123");
            users[1].PasswordHash = hasher.HashPassword(users[1], "ali123");
            users[2].PasswordHash = hasher.HashPassword(users[2], "telerik123");
            users[3].PasswordHash = hasher.HashPassword(users[3], "csharp123");
            users[4].PasswordHash = hasher.HashPassword(users[4], "viktor123");
            users[5].PasswordHash = hasher.HashPassword(users[5], "silvia123");
            users[6].PasswordHash = hasher.HashPassword(users[6], "maria123");
            users[7].PasswordHash = hasher.HashPassword(users[7], "pablo123");
            users[8].PasswordHash = hasher.HashPassword(users[8], "georgi123");
            users[9].PasswordHash = hasher.HashPassword(users[9], "alexandra123");
            users[10].PasswordHash = hasher.HashPassword(users[10], "stanislav123");
            users[11].PasswordHash = hasher.HashPassword(users[11], "nikol123");
            users[12].PasswordHash = hasher.HashPassword(users[12], "radko123");
            users[13].PasswordHash = hasher.HashPassword(users[13], "kiro123");
            users[14].PasswordHash = hasher.HashPassword(users[14], "bobi123");
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

            // Friendships
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
                    UserId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"),          // Telerik
                    UserFriendId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270")     // Magi
                },
                new Friend
                {
                    Id = 5,
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),          // Magi
                    UserFriendId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845")     // Viktor
                },
                new Friend
                {
                    Id = 6,
                    UserId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"),          // Viktor
                    UserFriendId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270")     // Magi
                },
                new Friend
                {
                    Id = 7,
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),          // Magi
                    UserFriendId = Guid.Parse("0D852E3A-B977-438A-9C33-7679A6E7B4CD")     // Silvia
                },
                new Friend
                {
                    Id = 8,
                    UserId = Guid.Parse("0D852E3A-B977-438A-9C33-7679A6E7B4CD"),          // Silvia
                    UserFriendId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270")     // Magi
                },
                new Friend
                {
                    Id = 9,
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),          // Magi
                    UserFriendId = Guid.Parse("B87071F5-B71C-45E1-91E7-6E85637ED10A")     // Maria
                },
                new Friend
                {
                    Id = 10,
                    UserId = Guid.Parse("B87071F5-B71C-45E1-91E7-6E85637ED10A"),          // Maria
                    UserFriendId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270")     // Magi
                },
                new Friend
                {
                    Id = 11,
                    UserId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),          // Ali
                    UserFriendId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845")     // Viktor
                },
                new Friend
                {
                    Id = 12,
                    UserId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"),          // Viktor
                    UserFriendId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5")     // Ali
                },
                new Friend
                {
                    Id = 13,
                    UserId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),          // Ali
                    UserFriendId = Guid.Parse("0D852E3A-B977-438A-9C33-7679A6E7B4CD")     // Silvia
                },
                new Friend
                {
                    Id = 14,
                    UserId = Guid.Parse("0D852E3A-B977-438A-9C33-7679A6E7B4CD"),          // Silvia
                    UserFriendId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5")     // Ali
                },
                new Friend
                {
                    Id = 15,
                    UserId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"),          // Telerik
                    UserFriendId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845")     // Viktor
                },
                new Friend
                {
                    Id = 16,
                    UserId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"),          // Viktor
                    UserFriendId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619")     // Telerik
                }
            };
            builder.Entity<Friend>().HasData(friends);

            // Friend Requests
            var friendRequests = new HashSet<FriendRequest>()
            {
                new FriendRequest
                {
                    Id = 1,
                    SenderId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),    // Magi
                    ReceiverId = Guid.Parse("dc6788da-53ae-44e7-b53c-e53a2f77a1af"),    // CSharp 
                },
                new FriendRequest
                {
                    Id = 2,
                    SenderId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),    // Magi
                    ReceiverId = Guid.Parse("35547a2a-8779-416b-9fc8-7aab34e883bd"),    // Nikol
                },
                new FriendRequest
                {
                    Id = 3,
                    SenderId = Guid.Parse("5d7ccf05-3080-4a9e-90ca-a4fee33aa196"),    // Pablo
                    ReceiverId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),    // Magi
                },
                new FriendRequest
                {
                    Id = 4,
                    SenderId = Guid.Parse("a9e49452-8ffd-460d-9998-8f662e36a2d6"),    // Stanislav
                    ReceiverId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),    // Magi
                },
                new FriendRequest
                {
                    Id = 5,
                    SenderId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),    // Ali
                    ReceiverId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"),    // Telerik
                },
                new FriendRequest
                {
                    Id = 6,
                    SenderId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),    // Ali
                    ReceiverId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"),    // Viktor
                },
                new FriendRequest
                {
                    Id = 7,
                    SenderId = Guid.Parse("5d7ccf05-3080-4a9e-90ca-a4fee33aa196"),    // Pablo
                    ReceiverId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),    // Ali
                },
                new FriendRequest
                {
                    Id = 8,
                    SenderId = Guid.Parse("a9e49452-8ffd-460d-9998-8f662e36a2d6"),    // Stanislav
                    ReceiverId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),    // Ali
                }
            };
            builder.Entity<FriendRequest>().HasData(friendRequests);

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
                    UserId= Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619")      // Telerik
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

            var posts = new HashSet<Post>()
            {                
                new Post
                {
                    Id = 1,
                    Content = "My new profile photo:",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),    // Magi
                    PhotoId = 1
                },
                new Post
                {
                    Id = 2,
                    Content = "My new profile photo:",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),    // Ali
                    PhotoId = 2
                },
                new Post
                {
                    Id = 3,
                    Content = "My new profile photo:",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"),    // Telerik
                    PhotoId = 3
                },
                new Post
                {
                    Id = 4,
                    Content = "My new profile photo:",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"),    // Victor
                    PhotoId = 4
                },
                new Post
                {
                    Id = 5,
                    Content = "My new profile photo:",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("0d852e3a-b977-438a-9c33-7679a6e7b4cd"),    // silvia
                    PhotoId = 5
                },
                new Post
                {
                    Id = 6,
                    Content = "My new profile photo:",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("d6f66ad9-58c9-43d6-adf8-4adbc3a97d36"),    // Alexandra
                    PhotoId = 6
                },
                new Post
                {
                    Id = 7,
                    Content = "My new profile photo:",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("b87071f5-b71c-45e1-91e7-6e85637ed10a"),    // Maria,
                    PhotoId = 7
                },
                new Post
                {
                    Id = 8,
                    Content = "My new profile photo:",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("5d7ccf05-3080-4a9e-90ca-a4fee33aa196"),    // Pablo,
                    PhotoId = 8
                },
                new Post
                {
                    Id = 9,
                    Content = "My new profile photo:",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("d93d2d61-e0ce-4a8d-9d61-93c8bc2849d7"),    // Radko
                    PhotoId = 9
                },
                new Post
                {   Id = 10,
                    Content = "My new profile photo:",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("5acf2b77-ab0a-4a04-8a5a-9ec38ffab96b"),    // Kiro,
                    PhotoId = 10
                },
                new Post
                {   Id = 11,
                    Content = "My new profile photo:",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("6405b148-f626-4142-a342-0ccd2c82c30f"),    // bobi,
                    PhotoId = 11
                },
                new Post
                {
                    Id = 12,
                    Content = "My new profile photo:",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("7f8793ff-03ab-458c-bc0e-ed4866a55b48"),    // Georgi,
                    PhotoId = 12
                },
                new Post
                {
                    Id = 13,
                    Content = "My new profile photo:",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("a9e49452-8ffd-460d-9998-8f662e36a2d6"),    // Stanislav,
                    PhotoId = 13
                },
                new Post
                {
                    Id = 14,
                    Content = "My new profile photo:",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("35547a2a-8779-416b-9fc8-7aab34e883bd"),    // Nikol,
                    PhotoId = 14
                },
                new Post
                {
                    Id = 15,
                    Content = "My new profile photo:",
                    Visibility = Visibility.Public,
                    UserId = Guid.Parse("dc6788da-53ae-44e7-b53c-e53a2f77a1af"),    // C#,
                    PhotoId = 15
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
                new Photo
                {
                    Id = 6,
                    PostId = 6,
                    Url = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/alexandra_profile_pic.jpg"
                },
                new Photo
                {
                   Id = 7,
                   PostId = 7,
                   Url = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg"
                },
                new Photo
                {
                   Id = 8,
                   PostId = 8,
                   Url = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/pablo_profile_pic.jpg"
                },
                new Photo
                {
                   Id = 9,
                   PostId = 9,
                   Url = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg"
                },
                new Photo
                {
                   Id = 10,
                   PostId = 10,
                   Url = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg"
                },
                new Photo
                {
                   Id = 11,
                   PostId = 11,
                   Url = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg"
                },
                new Photo
                {
                   Id = 12,
                   PostId = 12,
                   Url = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg"
                },
                new Photo
                {
                   Id = 13,
                   PostId = 13,
                   Url = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg"
                },
                new Photo
                {
                   Id = 14,
                   PostId = 14,
                   Url = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg"
                },
                new Photo
                {
                   Id = 15,
                   PostId = 15,
                   Url = "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg"
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
                },
                new SocialMedia
                {
                    Id = 2,
                    Name = "LinkedIn",
                    IconUrl = "",
                    UserLink = "https://www.linkedin.com/in/ali-marekov/",
                    UserId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),    // Ali
                },
                new SocialMedia
                {
                    Id = 3,
                    Name = "Official website",
                    IconUrl = "",
                    UserLink = "https://www.telerikacademy.com/",
                    UserId = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"),    // Telerik
                }
            };
            builder.Entity<SocialMedia>().HasData(socialMedias);
        }
    }
}
