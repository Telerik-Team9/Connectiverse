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
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    When = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { new Guid("943b692d-330e-405d-a019-c3d728442143"), "bdd4ff3d-afc8-47c5-9022-b56b82f622be", "Admin", "ADMIN" },
                    { new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"), "873bd4f1-59a6-424f-b1f7-7a8923a83a13", "User", "USER" }
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
                    { 15, new DateTime(2020, 11, 25, 22, 29, 43, 6, DateTimeKind.Utc).AddTicks(2184), null, false, null, 15, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 14, new DateTime(2020, 11, 25, 22, 29, 43, 6, DateTimeKind.Utc).AddTicks(2182), null, false, null, 14, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 13, new DateTime(2020, 11, 25, 22, 29, 43, 6, DateTimeKind.Utc).AddTicks(2180), null, false, null, 13, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 12, new DateTime(2020, 11, 25, 22, 29, 43, 6, DateTimeKind.Utc).AddTicks(2178), null, false, null, 12, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 11, new DateTime(2020, 11, 25, 22, 29, 43, 6, DateTimeKind.Utc).AddTicks(2176), null, false, null, 11, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 10, new DateTime(2020, 11, 25, 22, 29, 43, 6, DateTimeKind.Utc).AddTicks(2174), null, false, null, 10, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 5, new DateTime(2020, 11, 25, 22, 29, 43, 6, DateTimeKind.Utc).AddTicks(2163), null, false, null, 5, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/silvia_profile_pic.jpg" },
                    { 8, new DateTime(2020, 11, 25, 22, 29, 43, 6, DateTimeKind.Utc).AddTicks(2168), null, false, null, 8, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/pablo_profile_pic.jpg" },
                    { 7, new DateTime(2020, 11, 25, 22, 29, 43, 6, DateTimeKind.Utc).AddTicks(2167), null, false, null, 7, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg" },
                    { 6, new DateTime(2020, 11, 25, 22, 29, 43, 6, DateTimeKind.Utc).AddTicks(2165), null, false, null, 6, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/alexandra_profile_pic.jpg" },
                    { 4, new DateTime(2020, 11, 25, 22, 29, 43, 6, DateTimeKind.Utc).AddTicks(2156), null, false, null, 4, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/viktor_profile_pic.jpg" },
                    { 3, new DateTime(2020, 11, 25, 22, 29, 43, 6, DateTimeKind.Utc).AddTicks(2153), null, false, null, 3, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/telerik_profile_pic.jpg" },
                    { 2, new DateTime(2020, 11, 25, 22, 29, 43, 6, DateTimeKind.Utc).AddTicks(2122), null, false, null, 2, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/ali_profile_pic.jpg" },
                    { 1, new DateTime(2020, 11, 25, 22, 29, 43, 6, DateTimeKind.Utc).AddTicks(323), null, false, null, 1, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/magi_profile_pic.jpg" },
                    { 9, new DateTime(2020, 11, 25, 22, 29, 43, 6, DateTimeKind.Utc).AddTicks(2172), null, false, null, 9, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "Url" },
                values: new object[] { 1, new DateTime(2020, 11, 25, 22, 29, 43, 6, DateTimeKind.Utc).AddTicks(3265), null, false, null, 20, "NONONONO" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 1, 1, "Sofia" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CoverPictureId", "CoverPictureUrl", "CreatedOn", "DateOfBirth", "DeletedOn", "DisplayName", "Education", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureId", "ProfilePictureUrl", "SecurityStamp", "TownId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), 0, "c46867ae-4e0c-45fb-9b99-c8928c5211b8", null, null, new DateTime(2020, 11, 25, 22, 29, 42, 862, DateTimeKind.Utc).AddTicks(7539), new DateTime(1997, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Magi Nikolova", "Sofia University", "magi@mail.com", false, false, false, null, null, "MAGI@MAIL.COM", "MAGI@MAIL.COM", "AQAAAAEAACcQAAAAEBzg79Jfa11LiFLtiv1IFIiAXaD257vgT6yFVLgKiIlA39BPOEztCsV9gy7sjLRJog==", "0886868686", false, 1, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/magi_profile_pic.jpg", "051e624a-fa96-422e-ae13-8c8604b316b3", 1, false, "magi@mail.com" },
                    { new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), 0, "95f3f7e3-bd47-4b29-9ab7-38e3c09bbebe", null, null, new DateTime(2020, 11, 25, 22, 29, 42, 863, DateTimeKind.Utc).AddTicks(7383), new DateTime(1999, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ali Marekov", "Technical University", "ali@mail.com", false, false, false, null, null, "ALI@MAIL.COM", "ALI@MAIL.COM", "AQAAAAEAACcQAAAAEOQ2MmuoOIMUu/Q3T1ndBkg5dRecwSvstL4xHN0s/4nw6W1SfJpXpo0SH0jh53pdFA==", "088686843", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/ali_profile_pic.jpg", "c5073369-abfd-46b1-b667-217440130478", 1, false, "ali@mail.com" },
                    { new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), 0, "29efbe1b-ea80-47f9-89fa-847b2ed90d04", null, null, new DateTime(2020, 11, 25, 22, 29, 42, 863, DateTimeKind.Utc).AddTicks(7507), new DateTime(2010, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Telerik Academy", "Telerik Academy", "telerik@mail.com", false, false, false, null, null, "TELERIK@MAIL.COM", "TELERIK@MAIL.COM", "AQAAAAEAACcQAAAAENPbGnSE6ewcXCx7hgP0Y3sL/uGa+bk4cOgi8NGfoQ8Ez8NxIiQaEldo5HsNbnc0sQ==", "081111111", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/telerik_profile_pic.jpg", "f8557f08-ff62-4c4b-afe2-5d9afd1775c1", 1, false, "telerik@mail.com" },
                    { new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), 0, "d2bb344b-6b25-47b9-8c83-be1c3e3c6fd4", null, null, new DateTime(2020, 11, 25, 22, 29, 42, 863, DateTimeKind.Utc).AddTicks(7524), new DateTime(2010, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Sharp", "Alpha C# Track", "csharp@mail.com", false, false, false, null, null, "CSHARP@MAIL.COM", "CSHARP@MAIL.COM", "AQAAAAEAACcQAAAAEJZNgVtiff+WfR9ivjEmJTjxGxqybz/jrODnbiVytuSN7wMLF0vA43msuM/7b2ox0A==", "0833333333", false, null, "/img/noavatar.jpg", "a6ba78e7-814d-47b5-ab6c-319a6884aff9", 1, false, "csharp@mail.com" },
                    { new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), 0, "410a86d1-9255-49c9-a7a9-f6f81447fe85", null, null, new DateTime(2020, 11, 25, 22, 29, 42, 863, DateTimeKind.Utc).AddTicks(7551), new DateTime(1996, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Viktor Ivanov", "Technical University", "viktor@mail.com", false, false, false, null, null, "VIKTOR@MAIL.COM", "VIKTOR@MAIL.COM", "AQAAAAEAACcQAAAAEColqMDHDe07YguDacliuC5rxb6ZT3IsMVRMkxmNUvn/mieZxs6v9jGb/RNkzfbVNg==", "0884444444", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/viktor_profile_pic.jpg", "7a230c1c-a654-4411-8799-3ddc763a7d56", 1, false, "viktor@mail.com" },
                    { new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), 0, "d61751fa-701f-4e00-a73a-45f9ab554ddc", null, null, new DateTime(2020, 11, 25, 22, 29, 42, 863, DateTimeKind.Utc).AddTicks(7570), new DateTime(2000, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Silvia Borisova", "Sofia University", "silvia@mail.com", false, false, false, null, null, "SILVIA@MAIL.COM", "SILVIA@MAIL.COM", "AQAAAAEAACcQAAAAEMfkorcnQ/ETMgDWjGud3JROocyv5sNEEPn7KpOQuXmVRukZ8LezCLpWlV+MNS7Z/A==", "088555555", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/silvia_profile_pic.jpg", "2c9f37ef-5c19-488c-b315-14a6dece576a", 1, false, "silvia@mail.com" },
                    { new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a"), 0, "b20d72d3-485d-4bb5-af97-04d84c02b370", null, null, new DateTime(2020, 11, 25, 22, 29, 42, 863, DateTimeKind.Utc).AddTicks(7656), new DateTime(1997, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Maria Petrova", "", "maria@mail.com", false, false, false, null, null, "MARIA@MAIL.COM", "MARIA@MAIL.COM", "AQAAAAEAACcQAAAAEHHStQIPNQPH5Nby0+guqRIQHjo/MtLDtwcUmoBn4aEWODw6th2C1L4w7dO58IJudA==", "088666666", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg", "bcf2dbbe-53e5-462a-bdc5-13cec27c6b4a", 1, false, "maria@mail.com" },
                    { new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196"), 0, "8b8bfdce-2541-4338-a46c-4177dbba32a3", null, null, new DateTime(2020, 11, 25, 22, 29, 42, 863, DateTimeKind.Utc).AddTicks(7672), new DateTime(1996, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pablo Georgiev", "Technical University", "pablo@mail.com", false, false, false, null, null, "PABLO@MAIL.COM", "PABLO@MAIL.COM", "AQAAAAEAACcQAAAAEIlRXBCX77wWDNSfwuN+RQQb3FesC9RKYYtaPqS/jl44ptvJ0bRmwoK8gkdMK+QvAg==", "087777777", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/pablo_profile_pic.jpg", "efa0c704-69d7-4bd6-b2a7-fbefc6439e69", 1, false, "pablo@mail.com" },
                    { new Guid("7f8793ff-03ab-458c-bc0e-ed4866a55b48"), 0, "29ac0222-312c-4c03-be03-7a2b95ae4903", null, null, new DateTime(2020, 11, 25, 22, 29, 42, 863, DateTimeKind.Utc).AddTicks(7690), new DateTime(1976, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Georgi Georgiev", "UNWE", "georgi@mail.com", false, false, false, null, null, "GEORGI@MAIL.COM", "GEORGI@MAIL.COM", "AQAAAAEAACcQAAAAELwe3ggR/D9KsIsh5FOP1HvW9CAaTGFjMQZ4gvUCnsy0tJovtMA+YlmUFNCKENI4jA==", "0888888888", false, null, "/img/noavatar.jpg", "73e7d492-d963-43d4-a7fd-ef31fcd13d06", 1, false, "georgi@mail.com" },
                    { new Guid("d6f66ad9-58c9-43d6-adf8-4adbc3a97d36"), 0, "00027d21-68be-4930-bf35-e96a0fcdf408", null, null, new DateTime(2020, 11, 25, 22, 29, 42, 863, DateTimeKind.Utc).AddTicks(7705), new DateTime(1999, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alexandra Kirova", "Sofia University", "alexandra@mail.com", false, false, false, null, null, "ALEXANDRA@MAIL.COM", "ALEXANDRA@MAIL.COM", "AQAAAAEAACcQAAAAEGtJ/a4CzTsIv0lbl55PmLlCxSJK04GEItOBDIIzNu7THnSECQ06+6O4ZKX51uJ2CA==", "088899989", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/alexandra_profile_pic.jpg", "37ca68e0-1d82-4568-8c49-b0ced312fc6c", 1, false, "alexandra@mail.com" },
                    { new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6"), 0, "6948f9d5-3229-4df6-834f-ebcbd5a87b6d", null, null, new DateTime(2020, 11, 25, 22, 29, 42, 863, DateTimeKind.Utc).AddTicks(7720), new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Stanislav Pulev", "UNWE", "stanisav@mail.com", false, false, false, null, null, "STANISLAV@MAIL.COM", "STANISLAV@MAIL.COM", "AQAAAAEAACcQAAAAECSKVFGd98yQIQwF4ljLEXQgK/ff75Q+Q9wj77PHySIYziDfsUlTN7u9V8haMNMaMQ==", "088679446", false, null, "/img/noavatar.jpg", "7d25b343-f7da-4439-b501-43701472d057", 1, false, "stanislav@mail.com" },
                    { new Guid("35547a2a-8779-416b-9fc8-7aab34e883bd"), 0, "0cd0a1d5-27f2-4ab9-b158-8fe69587b7a1", null, null, new DateTime(2020, 11, 25, 22, 29, 42, 863, DateTimeKind.Utc).AddTicks(7733), new DateTime(1999, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nikol Peeva", "", "nikol@mail.com", false, false, false, null, null, "NIKOL@MAIL.COM", "NIKOL@MAIL.COM", "AQAAAAEAACcQAAAAEBskvGkekxDu9BXEmW1iKH88UfcW66Fn6lkPhQ0EUNCYQyvgFIqChlC8DjJ6KcC5Cg==", "08868324", false, null, "/img/noavatar.jpg", "1fb3d35e-e1ac-4915-8334-378638fdc816", 1, false, "nikol@mail.com" },
                    { new Guid("d93d2d61-e0ce-4a8d-9d61-93c8bc2849d7"), 0, "5449db4a-d3ca-4e20-a6de-587c7f8c64fd", null, null, new DateTime(2020, 11, 25, 22, 29, 42, 863, DateTimeKind.Utc).AddTicks(7750), new DateTime(1990, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Radko Stanev", "Telerik Academy", "radko@mail.com", false, false, false, null, null, "RADKO@MAIL.COM", "RADKO@MAIL.COM", "AQAAAAEAACcQAAAAEHsUkfBTwNA2PA8XUAmFxMFLpeoNIfHjzn4+VVm8Nzl9rS+r5toZ//l3pWSGHjJv9w==", "545453423", false, null, "/img/noavatar.jpg", "c75b5796-f820-4970-8554-09beda22c644", 1, false, "radko@mail.com" },
                    { new Guid("5acf2b77-ab0a-4a04-8a5a-9ec38ffab96b"), 0, "95dff916-38de-4b42-a979-7758617a6f2f", null, null, new DateTime(2020, 11, 25, 22, 29, 42, 863, DateTimeKind.Utc).AddTicks(7858), new DateTime(1990, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kiril Stanoev", "Telerik Academy", "kiro@mail.com", false, false, false, null, null, "KIRO@MAIL.COM", "KIRO@MAIL.COM", "AQAAAAEAACcQAAAAECFdUO/gszsiUxcj1Lmk6QvTsZjLLBOlnsNnQGkKbVNSZEvrz9WDuiMmxSL1mIYS/w==", "", false, null, "/img/noavatar.jpg", "44ccb45a-b0a1-4ea2-9f96-a2223d44e931", 1, false, "kiro@mail.com" },
                    { new Guid("6405b148-f626-4142-a342-0ccd2c82c30f"), 0, "796ef82d-6c1c-402d-84c9-677ec41c1ec2", null, null, new DateTime(2020, 11, 25, 22, 29, 42, 863, DateTimeKind.Utc).AddTicks(7875), new DateTime(1990, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Boyan Hadzhiev", "Telerik Academy", "bobi@mail.com", false, false, false, null, null, "BOBI@MAIL.COM", "BOBI@MAIL.COM", "AQAAAAEAACcQAAAAEC8u6XMQGYrurwzw6bX0923Lq3YDAJecjkrrWg3kRvjOToTpj65jPgfT+4vwJ/1P2w==", "", false, null, "/img/noavatar.jpg", "02f980d7-ac08-4d25-84f5-3390b8ba8611", 1, false, "bobi@mail.com" }
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
                    { 3, new DateTime(2020, 11, 25, 22, 29, 43, 4, DateTimeKind.Utc).AddTicks(1171), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196") },
                    { 1, new DateTime(2020, 11, 25, 22, 29, 43, 3, DateTimeKind.Utc).AddTicks(8864), null, false, null, new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 4, new DateTime(2020, 11, 25, 22, 29, 43, 4, DateTimeKind.Utc).AddTicks(1180), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6") },
                    { 7, new DateTime(2020, 11, 25, 22, 29, 43, 4, DateTimeKind.Utc).AddTicks(1199), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196") },
                    { 5, new DateTime(2020, 11, 25, 22, 29, 43, 4, DateTimeKind.Utc).AddTicks(1193), null, false, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 2, new DateTime(2020, 11, 25, 22, 29, 43, 4, DateTimeKind.Utc).AddTicks(984), null, false, null, new Guid("35547a2a-8779-416b-9fc8-7aab34e883bd"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 8, new DateTime(2020, 11, 25, 22, 29, 43, 4, DateTimeKind.Utc).AddTicks(1204), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6") }
                });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "UserFriendId", "UserId" },
                values: new object[,]
                {
                    { 2, new DateTime(2020, 11, 25, 22, 29, 43, 3, DateTimeKind.Utc).AddTicks(7156), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 10, new DateTime(2020, 11, 25, 22, 29, 43, 3, DateTimeKind.Utc).AddTicks(7251), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a") },
                    { 9, new DateTime(2020, 11, 25, 22, 29, 43, 3, DateTimeKind.Utc).AddTicks(7247), null, false, null, new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 1, new DateTime(2020, 11, 25, 22, 29, 43, 3, DateTimeKind.Utc).AddTicks(4665), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 14, new DateTime(2020, 11, 25, 22, 29, 43, 3, DateTimeKind.Utc).AddTicks(7270), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd") },
                    { 13, new DateTime(2020, 11, 25, 22, 29, 43, 3, DateTimeKind.Utc).AddTicks(7266), null, false, null, new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 8, new DateTime(2020, 11, 25, 22, 29, 43, 3, DateTimeKind.Utc).AddTicks(7241), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd") },
                    { 7, new DateTime(2020, 11, 25, 22, 29, 43, 3, DateTimeKind.Utc).AddTicks(7235), null, false, null, new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 5, new DateTime(2020, 11, 25, 22, 29, 43, 3, DateTimeKind.Utc).AddTicks(7224), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 16, new DateTime(2020, 11, 25, 22, 29, 43, 3, DateTimeKind.Utc).AddTicks(7278), null, false, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845") },
                    { 15, new DateTime(2020, 11, 25, 22, 29, 43, 3, DateTimeKind.Utc).AddTicks(7274), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { 12, new DateTime(2020, 11, 25, 22, 29, 43, 3, DateTimeKind.Utc).AddTicks(7260), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845") },
                    { 11, new DateTime(2020, 11, 25, 22, 29, 43, 3, DateTimeKind.Utc).AddTicks(7256), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 6, new DateTime(2020, 11, 25, 22, 29, 43, 3, DateTimeKind.Utc).AddTicks(7230), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845") },
                    { 3, new DateTime(2020, 11, 25, 22, 29, 43, 3, DateTimeKind.Utc).AddTicks(7203), null, false, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 4, new DateTime(2020, 11, 25, 22, 29, 43, 3, DateTimeKind.Utc).AddTicks(7210), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("3753d26b-5a35-491f-ae82-5238d243b619") }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PhotoId", "UserId", "VideoId", "Visibility" },
                values: new object[,]
                {
                    { 13, "My new profile photo", new DateTime(2020, 11, 25, 22, 29, 43, 5, DateTimeKind.Utc).AddTicks(8532), null, false, null, 13, new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6"), null, 0 },
                    { 14, "My new profile photo", new DateTime(2020, 11, 25, 22, 29, 43, 5, DateTimeKind.Utc).AddTicks(8536), null, false, null, 14, new Guid("35547a2a-8779-416b-9fc8-7aab34e883bd"), null, 0 },
                    { 8, "My new profile photo", new DateTime(2020, 11, 25, 22, 29, 43, 5, DateTimeKind.Utc).AddTicks(8502), null, false, null, 8, new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196"), null, 0 },
                    { 9, "My new profile photo", new DateTime(2020, 11, 25, 22, 29, 43, 5, DateTimeKind.Utc).AddTicks(8509), null, false, null, 9, new Guid("d93d2d61-e0ce-4a8d-9d61-93c8bc2849d7"), null, 0 },
                    { 12, "My new profile photo", new DateTime(2020, 11, 25, 22, 29, 43, 5, DateTimeKind.Utc).AddTicks(8527), null, false, null, 12, new Guid("7f8793ff-03ab-458c-bc0e-ed4866a55b48"), null, 0 },
                    { 6, "My new profile photo", new DateTime(2020, 11, 25, 22, 29, 43, 5, DateTimeKind.Utc).AddTicks(8491), null, false, null, 6, new Guid("d6f66ad9-58c9-43d6-adf8-4adbc3a97d36"), null, 0 },
                    { 4, "My new profile photo", new DateTime(2020, 11, 25, 22, 29, 43, 5, DateTimeKind.Utc).AddTicks(8471), null, false, null, 4, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), null, 0 },
                    { 5, "My new profile photo", new DateTime(2020, 11, 25, 22, 29, 43, 5, DateTimeKind.Utc).AddTicks(8483), null, false, null, 5, new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), null, 0 },
                    { 10, "My new profile photo", new DateTime(2020, 11, 25, 22, 29, 43, 5, DateTimeKind.Utc).AddTicks(8515), null, false, null, 10, new Guid("5acf2b77-ab0a-4a04-8a5a-9ec38ffab96b"), null, 0 },
                    { 15, "My new profile photo", new DateTime(2020, 11, 25, 22, 29, 43, 5, DateTimeKind.Utc).AddTicks(8540), null, false, null, 15, new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), null, 0 },
                    { 20, "Really funny video :)", new DateTime(2020, 11, 25, 22, 29, 43, 5, DateTimeKind.Utc).AddTicks(8545), null, false, null, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), 1, 0 },
                    { 3, "My new profile photo", new DateTime(2020, 11, 25, 22, 29, 43, 5, DateTimeKind.Utc).AddTicks(8463), null, false, null, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), null, 0 },
                    { 2, "My new profile photo", new DateTime(2020, 11, 25, 22, 29, 43, 5, DateTimeKind.Utc).AddTicks(8406), null, false, null, 2, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), null, 0 },
                    { 1, "My new profile photo", new DateTime(2020, 11, 25, 22, 29, 43, 5, DateTimeKind.Utc).AddTicks(5465), null, false, null, 1, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), null, 0 },
                    { 7, "My new profile photo", new DateTime(2020, 11, 25, 22, 29, 43, 5, DateTimeKind.Utc).AddTicks(8497), null, false, null, 7, new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a"), null, 0 },
                    { 11, "My new profile photo", new DateTime(2020, 11, 25, 22, 29, 43, 5, DateTimeKind.Utc).AddTicks(8519), null, false, null, 11, new Guid("6405b148-f626-4142-a342-0ccd2c82c30f"), null, 0 }
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IconUrl", "IsDeleted", "ModifiedOn", "Name", "UserId", "UserLink" },
                values: new object[,]
                {
                    { 3, new DateTime(2020, 11, 25, 22, 29, 43, 7, DateTimeKind.Utc).AddTicks(1528), null, "", false, null, "Official website", new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), "https://www.telerikacademy.com/" },
                    { 2, new DateTime(2020, 11, 25, 22, 29, 43, 7, DateTimeKind.Utc).AddTicks(1477), null, "", false, null, "LinkedIn", new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), "https://www.linkedin.com/in/ali-marekov/" },
                    { 1, new DateTime(2020, 11, 25, 22, 29, 43, 6, DateTimeKind.Utc).AddTicks(8733), null, "", false, null, "Instagram", new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), "https://www.instagram.com/magisnikolova" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 1, "This is Amazing!", new DateTime(2020, 11, 25, 22, 29, 43, 4, DateTimeKind.Utc).AddTicks(2447), null, false, null, 1, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 2, "This is Awful!", new DateTime(2020, 11, 25, 22, 29, 43, 4, DateTimeKind.Utc).AddTicks(5685), null, false, null, 20, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 1, new DateTime(2020, 11, 25, 22, 29, 43, 6, DateTimeKind.Utc).AddTicks(6130), null, false, null, 1, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") });

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
                name: "IX_Messages_UserId",
                table: "Messages",
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
                name: "Messages");

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
