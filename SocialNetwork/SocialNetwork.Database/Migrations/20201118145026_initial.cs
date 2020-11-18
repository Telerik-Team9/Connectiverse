using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialNetwork.Database.Migrations
{
    public partial class initial : Migration
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
                    { new Guid("943b692d-330e-405d-a019-c3d728442143"), "c8e14b63-6f00-41dd-9d9b-1e80f9f775e5", "Admin", "ADMIN" },
                    { new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"), "e88629a0-8987-4e7d-b8a1-c167c3e02672", "User", "USER" }
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
                    { 15, new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(9682), null, false, null, 15, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg" },
                    { 14, new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(9665), null, false, null, 14, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg" },
                    { 13, new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(9662), null, false, null, 13, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg" },
                    { 12, new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(9660), null, false, null, 12, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg" },
                    { 11, new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(9658), null, false, null, 11, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg" },
                    { 10, new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(9656), null, false, null, 10, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg" },
                    { 5, new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(9643), null, false, null, 5, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/silvia_profile_pic.jpg" },
                    { 8, new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(9649), null, false, null, 8, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/pablo_profile_pic.jpg" },
                    { 7, new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(9647), null, false, null, 7, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg" },
                    { 6, new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(9645), null, false, null, 6, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/alexandra_profile_pic.jpg" },
                    { 4, new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(9634), null, false, null, 4, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/viktor_profile_pic.jpg" },
                    { 3, new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(9630), null, false, null, 3, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/telerik_profile_pic.jpg" },
                    { 2, new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(9549), null, false, null, 2, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/ali_profile_pic.jpg" },
                    { 1, new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(7386), null, false, null, 1, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/magi_profile_pic.jpg" },
                    { 9, new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(9654), null, false, null, 9, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "Url" },
                values: new object[] { 1, new DateTime(2020, 11, 18, 14, 50, 25, 976, DateTimeKind.Utc).AddTicks(1110), null, false, null, 20, "NONONONO" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 1, 1, "Sofia" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CoverPictureId", "CoverPictureUrl", "CreatedOn", "DateOfBirth", "DeletedOn", "DisplayName", "Education", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureId", "ProfilePictureUrl", "SecurityStamp", "TownId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), 0, "6266bef7-1c09-41f5-a02d-caba29749749", null, null, new DateTime(2020, 11, 18, 14, 50, 25, 830, DateTimeKind.Utc).AddTicks(1929), new DateTime(1997, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Magi Nikolova", "Sofia University", "magi@mail.com", false, false, false, null, null, "MAGI@MAIL.COM", "MAGI@MAIL.COM", "AQAAAAEAACcQAAAAEEGcGaA4zCbMCrhKNPBxWOfOr0jiYeLwwAsA/yl3PiJ+bAkITDjovDpScXYdTubKKQ==", "0886868686", false, 1, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/magi_profile_pic.jpg", "53a964e4-450e-4c06-9f13-b18509f241bb", 1, false, "magi@mail.com" },
                    { new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), 0, "b9b7f531-9196-46d5-9fae-8d80980ffed9", null, null, new DateTime(2020, 11, 18, 14, 50, 25, 831, DateTimeKind.Utc).AddTicks(3525), new DateTime(1999, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ali Marekov", "Technical University", "ali@mail.com", false, false, false, null, null, "ALI@MAIL.COM", "ALI@MAIL.COM", "AQAAAAEAACcQAAAAEO10bKc4LXcvyF6+dKzvJmLBcDrLHE+4Kcg1ovA5cAdmnfjjvzcWPDr1B7AVUbPYLA==", "088686843", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/ali_profile_pic.jpg", "bc033675-ea9c-45c9-8a48-cefa6426a25c", 1, false, "ali@mail.com" },
                    { new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), 0, "ddfcbe8a-ff4e-4b52-9c70-0cb953378498", null, null, new DateTime(2020, 11, 18, 14, 50, 25, 831, DateTimeKind.Utc).AddTicks(3630), new DateTime(2010, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Telerik Academy", "Telerik Academy", "telerik@mail.com", false, false, false, null, null, "TELERIK@MAIL.COM", "TELERIK@MAIL.COM", "AQAAAAEAACcQAAAAEBZjtO81n5vYTJjibH16a73v+e18FvL8CqxF4MdVvq9E6wyt+0BBDxgXSTTxwvKUMQ==", "081111111", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/telerik_profile_pic.jpg", "8539bfe4-9dc8-46cd-9e08-dac13af765ce", 1, false, "telerik@mail.com" },
                    { new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), 0, "13123e75-2f25-47b0-bc11-1ecf8d665aa0", null, null, new DateTime(2020, 11, 18, 14, 50, 25, 831, DateTimeKind.Utc).AddTicks(3656), new DateTime(2010, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Sharp", "Alpha C# Track", "csharp@mail.com", false, false, false, null, null, "CSHARP@MAIL.COM", "CSHARP@MAIL.COM", "AQAAAAEAACcQAAAAEJVnDV8WoY3B07qGMR5qm6JoevXP52R1zDHlrgGn58kmcSrlepRcJ2f/7GXEVuvNkg==", "0833333333", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "421b9b46-02e5-4a18-8095-d9f43eb3c118", 1, false, "csharp@mail.com" },
                    { new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), 0, "22199c3c-d46e-471e-9d15-9225d9d66d85", null, null, new DateTime(2020, 11, 18, 14, 50, 25, 831, DateTimeKind.Utc).AddTicks(3770), new DateTime(1996, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Viktor Ivanov", "Technical University", "viktor@mail.com", false, false, false, null, null, "VIKTOR@MAIL.COM", "VIKTOR@MAIL.COM", "AQAAAAEAACcQAAAAENPs7XlyyBjB/Fbq5dWHQUrWTGKqFQ4qFom5p1DEQvHteB2puH0uiQDqtHoT6hgLGw==", "0884444444", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/viktor_profile_pic.jpg", "30fa5b9a-3749-4145-b817-7407d1d52bb7", 1, false, "viktor@mail.com" },
                    { new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), 0, "ee461c2a-e971-41a1-8ada-d447fef303ca", null, null, new DateTime(2020, 11, 18, 14, 50, 25, 831, DateTimeKind.Utc).AddTicks(3803), new DateTime(2000, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Silvia Borisova", "Sofia University", "silvia@mail.com", false, false, false, null, null, "SILVIA@MAIL.COM", "SILVIA@MAIL.COM", "AQAAAAEAACcQAAAAEN3Vs/TNvI7ngGhmXnILyjAwUypz/+KrG2o0CqRNci4W4/jXMqVbYtulAWVa3DXKfg==", "088555555", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/silvia_profile_pic.jpg", "3c8858c0-be60-44a5-85c1-72e07a7694df", 1, false, "silvia@mail.com" },
                    { new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a"), 0, "156b044f-cf9d-4bf8-885d-1024a0d5fb16", null, null, new DateTime(2020, 11, 18, 14, 50, 25, 831, DateTimeKind.Utc).AddTicks(3822), new DateTime(1997, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Maria Petrova", "Sofia University", "maria@mail.com", false, false, false, null, null, "MARIA@MAIL.COM", "MARIA@MAIL.COM", "AQAAAAEAACcQAAAAEGGVM2Xr9zucSJvTqbTAc9iqGbM2ncXt9b6XTn7QEbXIL/YjvES67RDlGekFYMFW4Q==", "088666666", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg", "dd002872-485a-4884-a7b1-710ad0730457", 1, false, "maria@mail.com" },
                    { new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196"), 0, "6a62e2b2-15a9-4b89-b299-13f186d47f4a", null, null, new DateTime(2020, 11, 18, 14, 50, 25, 831, DateTimeKind.Utc).AddTicks(3839), new DateTime(1996, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pablo Georgiev", "Technical University", "pablo@mail.com", false, false, false, null, null, "PABLO@MAIL.COM", "PABLO@MAIL.COM", "AQAAAAEAACcQAAAAECRx4vyVKpsUS7ze9G7gSTeKqD45lDVate2jH4FM9R6d7q3g3agMsPa/NkYaj6MBBQ==", "087777777", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/pablo_profile_pic.jpg", "305a8a72-0861-4cf0-b81f-573453437217", 1, false, "pablo@mail.com" },
                    { new Guid("7f8793ff-03ab-458c-bc0e-ed4866a55b48"), 0, "b7e8559f-3b85-4ac6-9a83-9b599640f993", null, null, new DateTime(2020, 11, 18, 14, 50, 25, 831, DateTimeKind.Utc).AddTicks(3860), new DateTime(1976, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Georgi Georgiev", "UNWE", "georgi@mail.com", false, false, false, null, null, "GEORGI@MAIL.COM", "GEORGI@MAIL.COM", "AQAAAAEAACcQAAAAEDq0Ew8WthMSNgG/BexLlaqnxUcnqK7LwGLYWgpcZeay7ThSukOo2SRti2NDFnluUQ==", "0888888888", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "1c78423e-b660-42dd-8231-f62a41215180", 1, false, "georgi@mail.com" },
                    { new Guid("d6f66ad9-58c9-43d6-adf8-4adbc3a97d36"), 0, "bda41de7-31ad-4e06-8722-0383797b8b4f", null, null, new DateTime(2020, 11, 18, 14, 50, 25, 831, DateTimeKind.Utc).AddTicks(3880), new DateTime(1999, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alexandra Kirova", "Sofia University", "alexandra@mail.com", false, false, false, null, null, "ALEXANDRA@MAIL.COM", "ALEXANDRA@MAIL.COM", "AQAAAAEAACcQAAAAENSJLfHkgNpkeYb9FCTyWcosLS1FeJRF6Noa7R34q2rP0PIwzhK8zGMf0p6Akrppgg==", "088899989", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/alexandra_profile_pic.jpg", "02c60b32-bcd0-4e10-8af1-3f105297e66f", 1, false, "alexandra@mail.com" },
                    { new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6"), 0, "1f6d3cf1-3152-45b5-92bc-f7a38f376432", null, null, new DateTime(2020, 11, 18, 14, 50, 25, 831, DateTimeKind.Utc).AddTicks(3898), new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Stanislav Pulev", "UNWE", "stanisav@mail.com", false, false, false, null, null, "STANISLAV@MAIL.COM", "STANISLAV@MAIL.COM", "AQAAAAEAACcQAAAAEB7UlBZwd+m7bcQP+TmhLKPpsKdMtPOkFaoNcq9MJiOX7t5tqJSsw+mj3R19arrqAA==", "088679446", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "389a1087-6704-4b38-85a5-8fb41d91cc67", 1, false, "stanislav@mail.com" },
                    { new Guid("35547a2a-8779-416b-9fc8-7aab34e883bd"), 0, "a9db0acc-7fa5-4f83-9bb4-cfeb5af9f55d", null, null, new DateTime(2020, 11, 18, 14, 50, 25, 831, DateTimeKind.Utc).AddTicks(3913), new DateTime(1999, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nikol Peeva", "Sofia University", "nikol@mail.com", false, false, false, null, null, "NIKOL@MAIL.COM", "NIKOL@MAIL.COM", "AQAAAAEAACcQAAAAEKXAj+jDmj+TzF3tZzOeS/p4bVD55+ba6v5xpG9mA7A0PwPrchI93vOIlZEuUTgShw==", "08868324", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "e69941a2-9c01-4cec-9ac9-d12754225561", 1, false, "nikol@mail.com" },
                    { new Guid("d93d2d61-e0ce-4a8d-9d61-93c8bc2849d7"), 0, "0cb04881-bbb5-492b-8dcd-673861151482", null, null, new DateTime(2020, 11, 18, 14, 50, 25, 831, DateTimeKind.Utc).AddTicks(4050), new DateTime(1990, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Radko Stanev", "Telerik Academy", "radko@mail.com", false, false, false, null, null, "RADKO@MAIL.COM", "RADKO@MAIL.COM", "AQAAAAEAACcQAAAAEByB/4iTfpuhlHIjWv1uQnQxzVoHB26zjNbXpwrw0b39IJxUON8M6v7MRzRcMfXuAQ==", "545453423", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "5d1502bb-cef8-4f33-89cc-8f45f16b4233", 1, false, "radko@mail.com" },
                    { new Guid("5acf2b77-ab0a-4a04-8a5a-9ec38ffab96b"), 0, "4db0a324-afcf-424a-872a-cb0e823962b0", null, null, new DateTime(2020, 11, 18, 14, 50, 25, 831, DateTimeKind.Utc).AddTicks(4070), new DateTime(1990, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kiro Stanoev", "Telerik Academy", "kiro@mail.com", false, false, false, null, null, "KIRO@MAIL.COM", "KIRO@MAIL.COM", "AQAAAAEAACcQAAAAEPYSkD9xAkofXFsY+SYhCLCiXiQNalErz1hgeBeRV2rqFNaqlRVdadCYLUvxnh5Bkw==", "5435345345", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "45c1641b-8d41-4e37-a03d-def9469f0c1d", 1, false, "kiro@mail.com" },
                    { new Guid("6405b148-f626-4142-a342-0ccd2c82c30f"), 0, "de965fa4-0fcf-44ce-b73b-fbf82fb335db", null, null, new DateTime(2020, 11, 18, 14, 50, 25, 831, DateTimeKind.Utc).AddTicks(4086), new DateTime(1990, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bobi Hadzhiev", "Telerik Academy", "bobi@mail.com", false, false, false, null, null, "BOBI@MAIL.COM", "BOBI@MAIL.COM", "AQAAAAEAACcQAAAAEMR2nJzekzAuAqMnI/PqZ7b03BJCrnqcTR2ACNOkFN01Wg/IcPkKtU4TcrpmwUPxew==", "653534564", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "0bcc7b3a-cfb4-4aba-a6d9-06e944a783be", 1, false, "bobi@mail.com" }
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
                    { new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") },
                    { new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") },
                    { new Guid("d6f66ad9-58c9-43d6-adf8-4adbc3a97d36"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") },
                    { new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") }
                });

            migrationBuilder.InsertData(
                table: "FriendRequests",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "ReceiverId", "SenderId" },
                values: new object[,]
                {
                    { 6, new DateTime(2020, 11, 18, 14, 50, 25, 973, DateTimeKind.Utc).AddTicks(4964), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 3, new DateTime(2020, 11, 18, 14, 50, 25, 973, DateTimeKind.Utc).AddTicks(4929), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196") },
                    { 1, new DateTime(2020, 11, 18, 14, 50, 25, 973, DateTimeKind.Utc).AddTicks(2158), null, false, null, new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 7, new DateTime(2020, 11, 18, 14, 50, 25, 973, DateTimeKind.Utc).AddTicks(4971), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196") },
                    { 8, new DateTime(2020, 11, 18, 14, 50, 25, 973, DateTimeKind.Utc).AddTicks(4979), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6") },
                    { 5, new DateTime(2020, 11, 18, 14, 50, 25, 973, DateTimeKind.Utc).AddTicks(4957), null, false, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 4, new DateTime(2020, 11, 18, 14, 50, 25, 973, DateTimeKind.Utc).AddTicks(4940), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6") },
                    { 2, new DateTime(2020, 11, 18, 14, 50, 25, 973, DateTimeKind.Utc).AddTicks(4846), null, false, null, new Guid("35547a2a-8779-416b-9fc8-7aab34e883bd"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") }
                });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "UserFriendId", "UserId" },
                values: new object[,]
                {
                    { 5, new DateTime(2020, 11, 18, 14, 50, 25, 972, DateTimeKind.Utc).AddTicks(8876), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 1, new DateTime(2020, 11, 18, 14, 50, 25, 972, DateTimeKind.Utc).AddTicks(4567), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 14, new DateTime(2020, 11, 18, 14, 50, 25, 972, DateTimeKind.Utc).AddTicks(9030), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd") },
                    { 13, new DateTime(2020, 11, 18, 14, 50, 25, 972, DateTimeKind.Utc).AddTicks(9022), null, false, null, new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 8, new DateTime(2020, 11, 18, 14, 50, 25, 972, DateTimeKind.Utc).AddTicks(8904), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd") },
                    { 7, new DateTime(2020, 11, 18, 14, 50, 25, 972, DateTimeKind.Utc).AddTicks(8895), null, false, null, new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 2, new DateTime(2020, 11, 18, 14, 50, 25, 972, DateTimeKind.Utc).AddTicks(8757), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 16, new DateTime(2020, 11, 18, 14, 50, 25, 972, DateTimeKind.Utc).AddTicks(9045), null, false, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845") },
                    { 15, new DateTime(2020, 11, 18, 14, 50, 25, 972, DateTimeKind.Utc).AddTicks(9037), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { 12, new DateTime(2020, 11, 18, 14, 50, 25, 972, DateTimeKind.Utc).AddTicks(9015), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845") },
                    { 11, new DateTime(2020, 11, 18, 14, 50, 25, 972, DateTimeKind.Utc).AddTicks(9007), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 6, new DateTime(2020, 11, 18, 14, 50, 25, 972, DateTimeKind.Utc).AddTicks(8887), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845") },
                    { 3, new DateTime(2020, 11, 18, 14, 50, 25, 972, DateTimeKind.Utc).AddTicks(8837), null, false, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 4, new DateTime(2020, 11, 18, 14, 50, 25, 972, DateTimeKind.Utc).AddTicks(8850), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { 9, new DateTime(2020, 11, 18, 14, 50, 25, 972, DateTimeKind.Utc).AddTicks(8915), null, false, null, new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 10, new DateTime(2020, 11, 18, 14, 50, 25, 972, DateTimeKind.Utc).AddTicks(8996), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a") }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PhotoId", "UserId", "VideoId", "Visibility" },
                values: new object[,]
                {
                    { 9, "My new profile photo:", new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(5118), null, false, null, 9, new Guid("d93d2d61-e0ce-4a8d-9d61-93c8bc2849d7"), null, 0 },
                    { 8, "My new profile photo:", new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(5109), null, false, null, 8, new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196"), null, 0 },
                    { 12, "My new profile photo:", new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(5140), null, false, null, 12, new Guid("7f8793ff-03ab-458c-bc0e-ed4866a55b48"), null, 0 },
                    { 13, "My new profile photo:", new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(5148), null, false, null, 13, new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6"), null, 0 },
                    { 14, "My new profile photo:", new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(5155), null, false, null, 14, new Guid("35547a2a-8779-416b-9fc8-7aab34e883bd"), null, 0 },
                    { 6, "My new profile photo:", new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(5095), null, false, null, 6, new Guid("d6f66ad9-58c9-43d6-adf8-4adbc3a97d36"), null, 0 },
                    { 4, "My new profile photo:", new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(5071), null, false, null, 4, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), null, 0 },
                    { 5, "My new profile photo:", new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(5086), null, false, null, 5, new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), null, 0 },
                    { 10, "My new profile photo:", new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(5126), null, false, null, 10, new Guid("5acf2b77-ab0a-4a04-8a5a-9ec38ffab96b"), null, 0 },
                    { 15, "My new profile photo:", new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(5162), null, false, null, 15, new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), null, 0 },
                    { 20, "Really funny video :)", new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(5170), null, false, null, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), 1, 0 },
                    { 3, "My new profile photo:", new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(5062), null, false, null, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), null, 0 },
                    { 2, "My new profile photo:", new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(4986), null, false, null, 2, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), null, 0 },
                    { 1, "My new profile photo:", new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(855), null, false, null, 1, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), null, 0 },
                    { 7, "My new profile photo:", new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(5102), null, false, null, 7, new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a"), null, 0 },
                    { 11, "My new profile photo:", new DateTime(2020, 11, 18, 14, 50, 25, 975, DateTimeKind.Utc).AddTicks(5132), null, false, null, 11, new Guid("6405b148-f626-4142-a342-0ccd2c82c30f"), null, 0 }
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IconUrl", "IsDeleted", "ModifiedOn", "Name", "UserId", "UserLink" },
                values: new object[,]
                {
                    { 3, new DateTime(2020, 11, 18, 14, 50, 25, 977, DateTimeKind.Utc).AddTicks(1638), null, "", false, null, "Official website", new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), "https://www.telerikacademy.com/" },
                    { 2, new DateTime(2020, 11, 18, 14, 50, 25, 977, DateTimeKind.Utc).AddTicks(1568), null, "", false, null, "LinkedIn", new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), "https://www.linkedin.com/in/ali-marekov/" },
                    { 1, new DateTime(2020, 11, 18, 14, 50, 25, 976, DateTimeKind.Utc).AddTicks(7956), null, "", false, null, "Instagram", new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), "https://www.instagram.com/magisnikolova" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 1, "This is Amazing!", new DateTime(2020, 11, 18, 14, 50, 25, 973, DateTimeKind.Utc).AddTicks(6252), null, false, null, 1, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 2, "This is Awful!", new DateTime(2020, 11, 18, 14, 50, 25, 973, DateTimeKind.Utc).AddTicks(9265), null, false, null, 20, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 1, new DateTime(2020, 11, 18, 14, 50, 25, 976, DateTimeKind.Utc).AddTicks(4601), null, false, null, 1, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") });

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
