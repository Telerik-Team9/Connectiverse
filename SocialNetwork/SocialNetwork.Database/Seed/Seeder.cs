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
                    /*RoleId = Guid.Parse("943b692d-330e-405d-a019-c3d728442143"),    // Admin*/

                    DisplayName = "Magi Nikolova",
                    DateOfBirth = new DateTime(1997,02,12),
                    Education = "Sofia University",
                    TownId = 1,
                    ProfilePictureId = 1,
                    ProfilePictureUrl = "ProfilePicUrl//"
                },
                new User()  // Admin
                {
                    Id = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                    UserName = "ali@mail.com",
                    NormalizedUserName = "ALI@MAIL.COM",
                    Email = "ali@mail.com",
                    NormalizedEmail = "ALI@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    /*RoleId = Guid.Parse("943b692d-330e-405d-a019-c3d728442143"),    // Admin*/

                    DisplayName = "Ali Marekov",
                    DateOfBirth = new DateTime(1999, 09, 23),
                    Education = "Technical University",
                    TownId = 1,
                    //ProfilePictureId = 1
                },
                new User()
                {
                    Id = Guid.Parse("3753d26b-5a35-491f-ae82-5238d243b619"),
                    UserName = "telerik@mail.com",
                    NormalizedUserName = "TELERIK@MAIL.COM",
                    Email = "telerik@mail.com",
                    NormalizedEmail = "TELERIK@MAIL.COM",
                    SecurityStamp = Guid.NewGuid().ToString(),
                   /* RoleId = Guid.Parse("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"),     // User*/

                    DisplayName = "Telerik Academy",
                    DateOfBirth = new DateTime(2010, 11, 1),
                    Education = "",
                    TownId = 1,
                    //ProfilePictureId = 1
                },
            };
            var hasher = new PasswordHasher<User>();
            users[0].PasswordHash = hasher.HashPassword(users[0], "magi123");
            users[1].PasswordHash = hasher.HashPassword(users[1], "ali123");
            users[2].PasswordHash = hasher.HashPassword(users[2], "telerik123");
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
                    UserId = Guid.Parse("1d6e3bae-451f-4c01-8b43-cecc2d404270"),    // Magi
                    UserFriendId = Guid.Parse("3be6b2ff-021d-4da5-8639-31973b594cc5"),    // Ali
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
