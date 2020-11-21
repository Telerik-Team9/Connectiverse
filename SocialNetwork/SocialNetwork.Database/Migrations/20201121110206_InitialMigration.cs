using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    ISO = table.Column<string>(maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Url = table.Column<string>(maxLength: 300, nullable: true),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Towns_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(maxLength: 30, nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Education = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    TownId = table.Column<int>(nullable: true),
                    ProfilePictureId = table.Column<int>(nullable: true),
                    ProfilePictureUrl = table.Column<string>(nullable: true),
                    CoverPictureId = table.Column<int>(nullable: true),
                    CoverPictureUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FriendRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    SenderId = table.Column<Guid>(nullable: false),
                    ReceiverId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendRequests_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FriendRequests_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    UserFriendId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friends_AspNetUsers_UserFriendId",
                        column: x => x.UserFriendId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Friends_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Visibility = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    PhotoId = table.Column<int>(nullable: true),
                    VideoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    IconUrl = table.Column<string>(maxLength: 100, nullable: true),
                    UserLink = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMedias_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(maxLength: 500, nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    PostId = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("943b692d-330e-405d-a019-c3d728442143"), "159af138-2f80-4bdd-876c-bb3be477a6c7", "Admin", "ADMIN" },
                    { new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"), "aeef557e-fc26-4c6a-9763-de424f916f30", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ISO", "Name" },
                values: new object[,]
                {
                    { 1, "BG", "Bulgaria" },
                    { 2, "BE", "Belgium" },
                    { 3, "NL", "Netherlands" },
                    { 4, "IE", "Ireland" },
                    { 5, "MX", "Mexico" },
                    { 6, "UK", "United Kingdom" },
                    { 7, "RS", "Serbia" },
                    { 8, "DE", "Germany" }
                });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "Url" },
                values: new object[,]
                {
                    { 15, new DateTime(2020, 11, 21, 11, 2, 5, 253, DateTimeKind.Utc).AddTicks(3228), null, false, null, 15, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 14, new DateTime(2020, 11, 21, 11, 2, 5, 253, DateTimeKind.Utc).AddTicks(3226), null, false, null, 14, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 13, new DateTime(2020, 11, 21, 11, 2, 5, 253, DateTimeKind.Utc).AddTicks(3224), null, false, null, 13, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 12, new DateTime(2020, 11, 21, 11, 2, 5, 253, DateTimeKind.Utc).AddTicks(3222), null, false, null, 12, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 11, new DateTime(2020, 11, 21, 11, 2, 5, 253, DateTimeKind.Utc).AddTicks(3220), null, false, null, 11, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 10, new DateTime(2020, 11, 21, 11, 2, 5, 253, DateTimeKind.Utc).AddTicks(3219), null, false, null, 10, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 5, new DateTime(2020, 11, 21, 11, 2, 5, 253, DateTimeKind.Utc).AddTicks(3150), null, false, null, 5, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/silvia_profile_pic.jpg" },
                    { 8, new DateTime(2020, 11, 21, 11, 2, 5, 253, DateTimeKind.Utc).AddTicks(3156), null, false, null, 8, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/pablo_profile_pic.jpg" },
                    { 7, new DateTime(2020, 11, 21, 11, 2, 5, 253, DateTimeKind.Utc).AddTicks(3154), null, false, null, 7, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg" },
                    { 6, new DateTime(2020, 11, 21, 11, 2, 5, 253, DateTimeKind.Utc).AddTicks(3152), null, false, null, 6, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/alexandra_profile_pic.jpg" },
                    { 4, new DateTime(2020, 11, 21, 11, 2, 5, 253, DateTimeKind.Utc).AddTicks(3142), null, false, null, 4, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/viktor_profile_pic.jpg" },
                    { 3, new DateTime(2020, 11, 21, 11, 2, 5, 253, DateTimeKind.Utc).AddTicks(3140), null, false, null, 3, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/telerik_profile_pic.jpg" },
                    { 2, new DateTime(2020, 11, 21, 11, 2, 5, 253, DateTimeKind.Utc).AddTicks(3108), null, false, null, 2, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/ali_profile_pic.jpg" },
                    { 1, new DateTime(2020, 11, 21, 11, 2, 5, 253, DateTimeKind.Utc).AddTicks(1356), null, false, null, 1, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/magi_profile_pic.jpg" },
                    { 9, new DateTime(2020, 11, 21, 11, 2, 5, 253, DateTimeKind.Utc).AddTicks(3216), null, false, null, 9, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "Url" },
                values: new object[] { 1, new DateTime(2020, 11, 21, 11, 2, 5, 253, DateTimeKind.Utc).AddTicks(5302), null, false, null, 20, "NONONONO" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 1, 1, "Sofia" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CoverPictureId", "CoverPictureUrl", "CreatedOn", "DateOfBirth", "DeletedOn", "DisplayName", "Education", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureId", "ProfilePictureUrl", "SecurityStamp", "TownId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), 0, "588579b4-e483-4f7b-bdae-0cd90348c4d6", null, null, new DateTime(2020, 11, 21, 11, 2, 5, 108, DateTimeKind.Utc).AddTicks(5326), new DateTime(1997, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Magi Nikolova", "Sofia University", "magi@mail.com", false, false, false, null, null, "MAGI@MAIL.COM", "MAGI@MAIL.COM", "AQAAAAEAACcQAAAAEJRTaoDcT4SiCuylO5MDLW+hIUiVMCYIL1XgmnrCOtQtRZkL4qG0+v82wkay0y7BHQ==", "0886868686", false, 1, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/magi_profile_pic.jpg", "0246ef72-8748-474b-bb81-9621d9f61f0b", 1, false, "magi@mail.com" },
                    { new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), 0, "1c4f9d40-ddeb-491a-aee9-29c1b2f96fa6", null, null, new DateTime(2020, 11, 21, 11, 2, 5, 109, DateTimeKind.Utc).AddTicks(4228), new DateTime(1999, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ali Marekov", "Technical University", "ali@mail.com", false, false, false, null, null, "ALI@MAIL.COM", "ALI@MAIL.COM", "AQAAAAEAACcQAAAAEJ61kNaonDxiRE97dF25ntoOCHf5ZRrZOA7s+4lrT9NYX1tK8+Rh31iBCkiqef7IJQ==", "088686843", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/ali_profile_pic.jpg", "0f5c4e95-e299-447c-8968-d0545d029df3", 1, false, "ali@mail.com" },
                    { new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), 0, "0d2e53df-ee98-4dbf-9daf-68a985e14215", null, null, new DateTime(2020, 11, 21, 11, 2, 5, 109, DateTimeKind.Utc).AddTicks(4308), new DateTime(2010, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Telerik Academy", "Telerik Academy", "telerik@mail.com", false, false, false, null, null, "TELERIK@MAIL.COM", "TELERIK@MAIL.COM", "AQAAAAEAACcQAAAAENFjSE6iVD/DR4z/dvCEgSf1FtGtJ0mEuX5R8az/G4o5NMSI+olcSVDDKMpPLZRdnw==", "081111111", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/telerik_profile_pic.jpg", "0e58c2f7-c2c7-483c-8f14-40b55cd76ddf", 1, false, "telerik@mail.com" },
                    { new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), 0, "041cdb19-d75e-43d4-8e16-25675b4511ff", null, null, new DateTime(2020, 11, 21, 11, 2, 5, 109, DateTimeKind.Utc).AddTicks(4337), new DateTime(2010, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Sharp", "Alpha C# Track", "csharp@mail.com", false, false, false, null, null, "CSHARP@MAIL.COM", "CSHARP@MAIL.COM", "AQAAAAEAACcQAAAAEA7ys5EpD2KgfwZs0vfkrjngHYZ5FmhwXigR0kARwG/RboDX8LE9Vx92TBhISGcG8A==", "0833333333", false, null, "/img/noavatar.jpg", "6a522b16-3e98-40b7-af11-ccfb5ad8f6ae", 1, false, "csharp@mail.com" },
                    { new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), 0, "3931a57f-3c64-4958-841a-49235a9046ec", null, null, new DateTime(2020, 11, 21, 11, 2, 5, 109, DateTimeKind.Utc).AddTicks(4354), new DateTime(1996, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Viktor Ivanov", "Technical University", "viktor@mail.com", false, false, false, null, null, "VIKTOR@MAIL.COM", "VIKTOR@MAIL.COM", "AQAAAAEAACcQAAAAEIGlWpkDIiiEjYhuJl74uwN9rA3UvyfKIKAuRcyVCN69xCL0hU06as2opxiR8HTJ2A==", "0884444444", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/viktor_profile_pic.jpg", "8b433c1d-d5d8-4f21-ba02-df8577ef5b23", 1, false, "viktor@mail.com" },
                    { new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), 0, "6c92a717-f54b-4e0e-b345-6c905439d8f3", null, null, new DateTime(2020, 11, 21, 11, 2, 5, 109, DateTimeKind.Utc).AddTicks(4373), new DateTime(2000, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Silvia Borisova", "Sofia University", "silvia@mail.com", false, false, false, null, null, "SILVIA@MAIL.COM", "SILVIA@MAIL.COM", "AQAAAAEAACcQAAAAEIe1TpdLM/vsKAhKZjABpmtQjiVCxH28+6Z7OttjkpkKsJz2vGqf4sMSEqZkwHrUAw==", "088555555", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/silvia_profile_pic.jpg", "a95ee6c0-8e1b-49d9-adc8-2798d07c40a4", 1, false, "silvia@mail.com" },
                    { new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a"), 0, "21cb0055-8ac5-4761-aab4-1bf623565043", null, null, new DateTime(2020, 11, 21, 11, 2, 5, 109, DateTimeKind.Utc).AddTicks(4389), new DateTime(1997, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Maria Petrova", "", "maria@mail.com", false, false, false, null, null, "MARIA@MAIL.COM", "MARIA@MAIL.COM", "AQAAAAEAACcQAAAAEMGaDVFXXSeZXBTi37HGW3IdP5IOCiBmHpea02HW/+3HHZq4Awy2lPI+oriGuEiHHQ==", "088666666", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg", "920911d6-1405-4283-8d5e-261debfb6e9a", 1, false, "maria@mail.com" },
                    { new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196"), 0, "e8c791dc-5c20-4b59-b5ce-9ad09106c524", null, null, new DateTime(2020, 11, 21, 11, 2, 5, 109, DateTimeKind.Utc).AddTicks(4464), new DateTime(1996, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pablo Georgiev", "Technical University", "pablo@mail.com", false, false, false, null, null, "PABLO@MAIL.COM", "PABLO@MAIL.COM", "AQAAAAEAACcQAAAAEDTvzPG/vnN737Ld4T/GGk55lPp+/c0At0Y4rPirV7U5LkzAXdCWj3wFatW2eiKqGQ==", "087777777", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/pablo_profile_pic.jpg", "fb3f2fd1-0dd6-4450-9403-e6f1152a6b76", 1, false, "pablo@mail.com" },
                    { new Guid("7f8793ff-03ab-458c-bc0e-ed4866a55b48"), 0, "aef4849a-60eb-43f5-ad64-2f18725e62a1", null, null, new DateTime(2020, 11, 21, 11, 2, 5, 109, DateTimeKind.Utc).AddTicks(4483), new DateTime(1976, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Georgi Georgiev", "UNWE", "georgi@mail.com", false, false, false, null, null, "GEORGI@MAIL.COM", "GEORGI@MAIL.COM", "AQAAAAEAACcQAAAAEL6SWn6LGQFShq9p8WByU7o4eVl3u2YEfzuLQVUctMyFVfhGDMk+o6jm9KtgGbA6KA==", "0888888888", false, null, "/img/noavatar.jpg", "99bebeb8-4391-4aa5-98eb-6b829443e8ab", 1, false, "georgi@mail.com" },
                    { new Guid("d6f66ad9-58c9-43d6-adf8-4adbc3a97d36"), 0, "acb777f0-169e-4961-b1da-0024a3a07d7a", null, null, new DateTime(2020, 11, 21, 11, 2, 5, 109, DateTimeKind.Utc).AddTicks(4499), new DateTime(1999, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alexandra Kirova", "Sofia University", "alexandra@mail.com", false, false, false, null, null, "ALEXANDRA@MAIL.COM", "ALEXANDRA@MAIL.COM", "AQAAAAEAACcQAAAAEB2jzP3SIncEL8tpclpClRl5T9uEdgvAHoyy5DwOX1WeI3k9u07FURzUJcNvrwhAcA==", "088899989", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/alexandra_profile_pic.jpg", "aab8f4a9-6012-40d1-9b82-68d0db2a2199", 1, false, "alexandra@mail.com" },
                    { new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6"), 0, "bdf30ad1-a270-46ee-a662-32fe2b73851b", null, null, new DateTime(2020, 11, 21, 11, 2, 5, 109, DateTimeKind.Utc).AddTicks(4516), new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Stanislav Pulev", "UNWE", "stanisav@mail.com", false, false, false, null, null, "STANISLAV@MAIL.COM", "STANISLAV@MAIL.COM", "AQAAAAEAACcQAAAAENGRIZqHb1GrNJGXYA21nt/8BC5OzSVa/W9wENsGxAkZ3UIu/FKift3msOqonVP7OA==", "088679446", false, null, "/img/noavatar.jpg", "1f0e006b-6e64-49da-b1fb-575a9bf91104", 1, false, "stanislav@mail.com" },
                    { new Guid("35547a2a-8779-416b-9fc8-7aab34e883bd"), 0, "24f58e9d-d751-4b62-8a8d-f1ab21d10466", null, null, new DateTime(2020, 11, 21, 11, 2, 5, 109, DateTimeKind.Utc).AddTicks(4534), new DateTime(1999, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nikol Peeva", "", "nikol@mail.com", false, false, false, null, null, "NIKOL@MAIL.COM", "NIKOL@MAIL.COM", "AQAAAAEAACcQAAAAEDb4NfMgecf1GR6lahfiEumP1c23gDk14ItRwy30QJP5l7mFWKhMq7PWPmknUOw1Nw==", "08868324", false, null, "/img/noavatar.jpg", "53f45749-1edc-4795-b02a-da99db4b1f0a", 1, false, "nikol@mail.com" },
                    { new Guid("d93d2d61-e0ce-4a8d-9d61-93c8bc2849d7"), 0, "3eecb194-bb0a-4313-a86c-1e9bf3e66834", null, null, new DateTime(2020, 11, 21, 11, 2, 5, 109, DateTimeKind.Utc).AddTicks(4549), new DateTime(1990, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Radko Stanev", "Telerik Academy", "radko@mail.com", false, false, false, null, null, "RADKO@MAIL.COM", "RADKO@MAIL.COM", "AQAAAAEAACcQAAAAED9Rpm3tQrP3yYdxcckYTJAywbvonDZy/BUEGD9nGUEcbA+20Kj7CB86T4lGbnpA0g==", "545453423", false, null, "/img/noavatar.jpg", "b3c87d84-2227-4475-9d9f-0ee81f8d7a26", 1, false, "radko@mail.com" },
                    { new Guid("5acf2b77-ab0a-4a04-8a5a-9ec38ffab96b"), 0, "baa9c014-0b24-4b7b-8530-a0f3219a2725", null, null, new DateTime(2020, 11, 21, 11, 2, 5, 109, DateTimeKind.Utc).AddTicks(4563), new DateTime(1990, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kiril Stanoev", "Telerik Academy", "kiro@mail.com", false, false, false, null, null, "KIRO@MAIL.COM", "KIRO@MAIL.COM", "AQAAAAEAACcQAAAAEPmN/D9pGkJJn1NJoK4gZXpdlXi5vslb1MP0e3Wie2rfeat0lo9ljRruGuO0xByczw==", "", false, null, "/img/noavatar.jpg", "4285999f-2e39-4ccf-9aa8-90a2e2062556", 1, false, "kiro@mail.com" },
                    { new Guid("6405b148-f626-4142-a342-0ccd2c82c30f"), 0, "3056bfd9-f1af-4ab5-b48e-9a3478b288bf", null, null, new DateTime(2020, 11, 21, 11, 2, 5, 109, DateTimeKind.Utc).AddTicks(4578), new DateTime(1990, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Boyan Hadzhiev", "Telerik Academy", "bobi@mail.com", false, false, false, null, null, "BOBI@MAIL.COM", "BOBI@MAIL.COM", "AQAAAAEAACcQAAAAEDnVVt4dMzVaD7Eze2dOxFc42y8JmCxX0dfmPmETif/utSbjmfkyK8O1R9ek9ZjGBw==", "", false, null, "/img/noavatar.jpg", "56eae242-382b-4870-a05c-25004cc4f656", 1, false, "bobi@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("943b692d-330e-405d-a019-c3d728442143") },
                    { new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") },
                    { new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") },
                    { new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("943b692d-330e-405d-a019-c3d728442143") },
                    { new Guid("7f8793ff-03ab-458c-bc0e-ed4866a55b48"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") },
                    { new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") },
                    { new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") },
                    { new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") },
                    { new Guid("d6f66ad9-58c9-43d6-adf8-4adbc3a97d36"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") },
                    { new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") }
                });

            migrationBuilder.InsertData(
                table: "FriendRequests",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "ReceiverId", "SenderId" },
                values: new object[,]
                {
                    { 3, new DateTime(2020, 11, 21, 11, 2, 5, 250, DateTimeKind.Utc).AddTicks(7252), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196") },
                    { 1, new DateTime(2020, 11, 21, 11, 2, 5, 250, DateTimeKind.Utc).AddTicks(1192), null, false, null, new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 4, new DateTime(2020, 11, 21, 11, 2, 5, 250, DateTimeKind.Utc).AddTicks(7259), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6") },
                    { 7, new DateTime(2020, 11, 21, 11, 2, 5, 250, DateTimeKind.Utc).AddTicks(7275), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196") },
                    { 5, new DateTime(2020, 11, 21, 11, 2, 5, 250, DateTimeKind.Utc).AddTicks(7270), null, false, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 2, new DateTime(2020, 11, 21, 11, 2, 5, 250, DateTimeKind.Utc).AddTicks(7069), null, false, null, new Guid("35547a2a-8779-416b-9fc8-7aab34e883bd"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 8, new DateTime(2020, 11, 21, 11, 2, 5, 250, DateTimeKind.Utc).AddTicks(7279), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6") }
                });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "UserFriendId", "UserId" },
                values: new object[,]
                {
                    { 2, new DateTime(2020, 11, 21, 11, 2, 5, 249, DateTimeKind.Utc).AddTicks(6776), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 10, new DateTime(2020, 11, 21, 11, 2, 5, 249, DateTimeKind.Utc).AddTicks(7337), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a") },
                    { 9, new DateTime(2020, 11, 21, 11, 2, 5, 249, DateTimeKind.Utc).AddTicks(7332), null, false, null, new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 1, new DateTime(2020, 11, 21, 11, 2, 5, 249, DateTimeKind.Utc).AddTicks(4486), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 14, new DateTime(2020, 11, 21, 11, 2, 5, 249, DateTimeKind.Utc).AddTicks(7375), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd") },
                    { 13, new DateTime(2020, 11, 21, 11, 2, 5, 249, DateTimeKind.Utc).AddTicks(7370), null, false, null, new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 8, new DateTime(2020, 11, 21, 11, 2, 5, 249, DateTimeKind.Utc).AddTicks(7325), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd") },
                    { 7, new DateTime(2020, 11, 21, 11, 2, 5, 249, DateTimeKind.Utc).AddTicks(7316), null, false, null, new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 5, new DateTime(2020, 11, 21, 11, 2, 5, 249, DateTimeKind.Utc).AddTicks(7303), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 16, new DateTime(2020, 11, 21, 11, 2, 5, 249, DateTimeKind.Utc).AddTicks(7384), null, false, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845") },
                    { 15, new DateTime(2020, 11, 21, 11, 2, 5, 249, DateTimeKind.Utc).AddTicks(7379), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { 12, new DateTime(2020, 11, 21, 11, 2, 5, 249, DateTimeKind.Utc).AddTicks(7348), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845") },
                    { 11, new DateTime(2020, 11, 21, 11, 2, 5, 249, DateTimeKind.Utc).AddTicks(7342), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 6, new DateTime(2020, 11, 21, 11, 2, 5, 249, DateTimeKind.Utc).AddTicks(7310), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845") },
                    { 3, new DateTime(2020, 11, 21, 11, 2, 5, 249, DateTimeKind.Utc).AddTicks(7111), null, false, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 4, new DateTime(2020, 11, 21, 11, 2, 5, 249, DateTimeKind.Utc).AddTicks(7119), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("3753d26b-5a35-491f-ae82-5238d243b619") }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PhotoId", "UserId", "VideoId", "Visibility" },
                values: new object[,]
                {
                    { 13, "My new profile photo", new DateTime(2020, 11, 21, 11, 2, 5, 252, DateTimeKind.Utc).AddTicks(9608), null, false, null, 13, new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6"), null, 0 },
                    { 14, "My new profile photo", new DateTime(2020, 11, 21, 11, 2, 5, 252, DateTimeKind.Utc).AddTicks(9612), null, false, null, 14, new Guid("35547a2a-8779-416b-9fc8-7aab34e883bd"), null, 0 },
                    { 8, "My new profile photo", new DateTime(2020, 11, 21, 11, 2, 5, 252, DateTimeKind.Utc).AddTicks(9582), null, false, null, 8, new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196"), null, 0 },
                    { 9, "My new profile photo", new DateTime(2020, 11, 21, 11, 2, 5, 252, DateTimeKind.Utc).AddTicks(9589), null, false, null, 9, new Guid("d93d2d61-e0ce-4a8d-9d61-93c8bc2849d7"), null, 0 },
                    { 12, "My new profile photo", new DateTime(2020, 11, 21, 11, 2, 5, 252, DateTimeKind.Utc).AddTicks(9603), null, false, null, 12, new Guid("7f8793ff-03ab-458c-bc0e-ed4866a55b48"), null, 0 },
                    { 6, "My new profile photo", new DateTime(2020, 11, 21, 11, 2, 5, 252, DateTimeKind.Utc).AddTicks(9572), null, false, null, 6, new Guid("d6f66ad9-58c9-43d6-adf8-4adbc3a97d36"), null, 0 },
                    { 4, "My new profile photo", new DateTime(2020, 11, 21, 11, 2, 5, 252, DateTimeKind.Utc).AddTicks(9554), null, false, null, 4, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), null, 0 },
                    { 5, "My new profile photo", new DateTime(2020, 11, 21, 11, 2, 5, 252, DateTimeKind.Utc).AddTicks(9566), null, false, null, 5, new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), null, 0 },
                    { 10, "My new profile photo", new DateTime(2020, 11, 21, 11, 2, 5, 252, DateTimeKind.Utc).AddTicks(9594), null, false, null, 10, new Guid("5acf2b77-ab0a-4a04-8a5a-9ec38ffab96b"), null, 0 },
                    { 15, "My new profile photo", new DateTime(2020, 11, 21, 11, 2, 5, 252, DateTimeKind.Utc).AddTicks(9617), null, false, null, 15, new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), null, 0 },
                    { 20, "Really funny video :)", new DateTime(2020, 11, 21, 11, 2, 5, 252, DateTimeKind.Utc).AddTicks(9621), null, false, null, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), 1, 0 },
                    { 3, "My new profile photo", new DateTime(2020, 11, 21, 11, 2, 5, 252, DateTimeKind.Utc).AddTicks(9545), null, false, null, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), null, 0 },
                    { 2, "My new profile photo", new DateTime(2020, 11, 21, 11, 2, 5, 252, DateTimeKind.Utc).AddTicks(9483), null, false, null, 2, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), null, 0 },
                    { 1, "My new profile photo", new DateTime(2020, 11, 21, 11, 2, 5, 252, DateTimeKind.Utc).AddTicks(6427), null, false, null, 1, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), null, 0 },
                    { 7, "My new profile photo", new DateTime(2020, 11, 21, 11, 2, 5, 252, DateTimeKind.Utc).AddTicks(9578), null, false, null, 7, new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a"), null, 0 },
                    { 11, "My new profile photo", new DateTime(2020, 11, 21, 11, 2, 5, 252, DateTimeKind.Utc).AddTicks(9599), null, false, null, 11, new Guid("6405b148-f626-4142-a342-0ccd2c82c30f"), null, 0 }
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IconUrl", "IsDeleted", "ModifiedOn", "Name", "UserId", "UserLink" },
                values: new object[,]
                {
                    { 3, new DateTime(2020, 11, 21, 11, 2, 5, 254, DateTimeKind.Utc).AddTicks(4512), null, "", false, null, "Official website", new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), "https://www.telerikacademy.com/" },
                    { 2, new DateTime(2020, 11, 21, 11, 2, 5, 254, DateTimeKind.Utc).AddTicks(4460), null, "", false, null, "LinkedIn", new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), "https://www.linkedin.com/in/ali-marekov/" },
                    { 1, new DateTime(2020, 11, 21, 11, 2, 5, 254, DateTimeKind.Utc).AddTicks(1398), null, "", false, null, "Instagram", new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), "https://www.instagram.com/magisnikolova" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 1, "This is Amazing!", new DateTime(2020, 11, 21, 11, 2, 5, 250, DateTimeKind.Utc).AddTicks(9850), null, false, null, 1, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 2, "This is Awful!", new DateTime(2020, 11, 21, 11, 2, 5, 251, DateTimeKind.Utc).AddTicks(4989), null, false, null, 20, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 1, new DateTime(2020, 11, 21, 11, 2, 5, 253, DateTimeKind.Utc).AddTicks(8764), null, false, null, 1, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TownId",
                table: "AspNetUsers",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_ReceiverId",
                table: "FriendRequests",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendRequests_SenderId",
                table: "FriendRequests",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserFriendId",
                table: "Friends",
                column: "UserFriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserId",
                table: "Friends",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PhotoId",
                table: "Posts",
                column: "PhotoId",
                unique: true,
                filter: "[PhotoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_VideoId",
                table: "Posts",
                column: "VideoId",
                unique: true,
                filter: "[VideoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_UserId",
                table: "SocialMedias",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Towns_CountryId",
                table: "Towns",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "FriendRequests");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
