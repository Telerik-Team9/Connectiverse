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
                    { new Guid("943b692d-330e-405d-a019-c3d728442143"), "49cb0b9e-e83d-40e3-a6cd-e6298578a1d6", "Admin", "ADMIN" },
                    { new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"), "f563cf4b-3bbc-45bd-8fe9-871642ae5b9f", "User", "USER" }
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
                    { 15, new DateTime(2020, 11, 19, 11, 42, 36, 435, DateTimeKind.Utc).AddTicks(63), null, false, null, 15, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 14, new DateTime(2020, 11, 19, 11, 42, 36, 435, DateTimeKind.Utc).AddTicks(59), null, false, null, 14, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 13, new DateTime(2020, 11, 19, 11, 42, 36, 435, DateTimeKind.Utc).AddTicks(56), null, false, null, 13, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 12, new DateTime(2020, 11, 19, 11, 42, 36, 435, DateTimeKind.Utc).AddTicks(52), null, false, null, 12, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 11, new DateTime(2020, 11, 19, 11, 42, 36, 435, DateTimeKind.Utc).AddTicks(48), null, false, null, 11, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 10, new DateTime(2020, 11, 19, 11, 42, 36, 435, DateTimeKind.Utc).AddTicks(44), null, false, null, 10, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 5, new DateTime(2020, 11, 19, 11, 42, 36, 435, DateTimeKind.Utc).AddTicks(18), null, false, null, 5, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/silvia_profile_pic.jpg" },
                    { 8, new DateTime(2020, 11, 19, 11, 42, 36, 435, DateTimeKind.Utc).AddTicks(31), null, false, null, 8, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/pablo_profile_pic.jpg" },
                    { 7, new DateTime(2020, 11, 19, 11, 42, 36, 435, DateTimeKind.Utc).AddTicks(27), null, false, null, 7, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg" },
                    { 6, new DateTime(2020, 11, 19, 11, 42, 36, 435, DateTimeKind.Utc).AddTicks(23), null, false, null, 6, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/alexandra_profile_pic.jpg" },
                    { 4, new DateTime(2020, 11, 19, 11, 42, 36, 434, DateTimeKind.Utc).AddTicks(9998), null, false, null, 4, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/viktor_profile_pic.jpg" },
                    { 3, new DateTime(2020, 11, 19, 11, 42, 36, 434, DateTimeKind.Utc).AddTicks(9990), null, false, null, 3, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/telerik_profile_pic.jpg" },
                    { 2, new DateTime(2020, 11, 19, 11, 42, 36, 434, DateTimeKind.Utc).AddTicks(9838), null, false, null, 2, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/ali_profile_pic.jpg" },
                    { 1, new DateTime(2020, 11, 19, 11, 42, 36, 434, DateTimeKind.Utc).AddTicks(5858), null, false, null, 1, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/magi_profile_pic.jpg" },
                    { 9, new DateTime(2020, 11, 19, 11, 42, 36, 435, DateTimeKind.Utc).AddTicks(40), null, false, null, 9, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "Url" },
                values: new object[] { 1, new DateTime(2020, 11, 19, 11, 42, 36, 435, DateTimeKind.Utc).AddTicks(2766), null, false, null, 20, "NONONONO" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 1, 1, "Sofia" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CoverPictureId", "CoverPictureUrl", "CreatedOn", "DateOfBirth", "DeletedOn", "DisplayName", "Education", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureId", "ProfilePictureUrl", "SecurityStamp", "TownId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), 0, "b14077c7-7da6-4cf4-9d17-10e2af179d96", null, null, new DateTime(2020, 11, 19, 11, 42, 36, 204, DateTimeKind.Utc).AddTicks(8296), new DateTime(1997, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Magi Nikolova", "Sofia University", "magi@mail.com", false, false, false, null, null, "MAGI@MAIL.COM", "MAGI@MAIL.COM", "AQAAAAEAACcQAAAAEBMX8Xo4lvm/AAtj8DIBxGBUmlhPhH2cKWmRdjapgbRlzJ2Z8yy/C0rs2W0xDBvX/A==", "0886868686", false, 1, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/magi_profile_pic.jpg", "5d6c1977-e121-499a-b690-9562f3b726e5", 1, false, "magi@mail.com" },
                    { new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), 0, "304a76c4-307b-4461-9c32-7f86155e172c", null, null, new DateTime(2020, 11, 19, 11, 42, 36, 206, DateTimeKind.Utc).AddTicks(1146), new DateTime(1999, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ali Marekov", "Technical University", "ali@mail.com", false, false, false, null, null, "ALI@MAIL.COM", "ALI@MAIL.COM", "AQAAAAEAACcQAAAAEM2Y6sgGFJtrY+SK8jekXFbIfKpTI/4WxNPUxOS3EF2n/JcK8ID0RENz7mQJ0HA4MQ==", "088686843", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/ali_profile_pic.jpg", "9bb9fc13-1b62-4e27-a750-55087c928950", 1, false, "ali@mail.com" },
                    { new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), 0, "b58d8779-94fd-4318-a6fa-1b4b33f30724", null, null, new DateTime(2020, 11, 19, 11, 42, 36, 206, DateTimeKind.Utc).AddTicks(1250), new DateTime(2010, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Telerik Academy", "Telerik Academy", "telerik@mail.com", false, false, false, null, null, "TELERIK@MAIL.COM", "TELERIK@MAIL.COM", "AQAAAAEAACcQAAAAEOKJzrX9uR0uQ74wTxjeyBQT82XNwBYSHvWkoefpn7PSqIFnYdJPebrbiKS2L08RSw==", "081111111", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/telerik_profile_pic.jpg", "5351e853-efeb-4514-8c6e-c4cb34633a36", 1, false, "telerik@mail.com" },
                    { new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), 0, "1f915ac8-8c36-45bd-87b3-2693d1dd2015", null, null, new DateTime(2020, 11, 19, 11, 42, 36, 206, DateTimeKind.Utc).AddTicks(1295), new DateTime(2010, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Sharp", "Alpha C# Track", "csharp@mail.com", false, false, false, null, null, "CSHARP@MAIL.COM", "CSHARP@MAIL.COM", "AQAAAAEAACcQAAAAEBffm+0DqDaG5p7KDck+O+vhZjtC7OuA1nnfx/o4WczAuPapmdiDhqMXIdNan34N+g==", "0833333333", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "cbe68ec8-fcbf-4ff7-86d6-06c51d4979b5", 1, false, "csharp@mail.com" },
                    { new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), 0, "7dc2bbc3-406c-49fc-91f8-f00a8f2c2f91", null, null, new DateTime(2020, 11, 19, 11, 42, 36, 206, DateTimeKind.Utc).AddTicks(1313), new DateTime(1996, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Viktor Ivanov", "Technical University", "viktor@mail.com", false, false, false, null, null, "VIKTOR@MAIL.COM", "VIKTOR@MAIL.COM", "AQAAAAEAACcQAAAAEDS5wsg6iX+RdLTErAoHOr/4a6pz9IsNfpismqOzjuCNgHysi2c6GLWbC8SDDV7oVg==", "0884444444", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/viktor_profile_pic.jpg", "868b793c-3762-499d-868a-562912a98d3d", 1, false, "viktor@mail.com" },
                    { new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), 0, "9d9e0b79-5ccf-4662-8a71-d358b5a259a0", null, null, new DateTime(2020, 11, 19, 11, 42, 36, 206, DateTimeKind.Utc).AddTicks(1343), new DateTime(2000, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Silvia Borisova", "Sofia University", "silvia@mail.com", false, false, false, null, null, "SILVIA@MAIL.COM", "SILVIA@MAIL.COM", "AQAAAAEAACcQAAAAELS4RJin51mTaeB6AnYb9CspXbu0+qB4va3GGGoEM99SmC8Y/PnmumwwgxETEzrI9w==", "088555555", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/silvia_profile_pic.jpg", "64cd09fb-c227-479c-bdf4-5d48df40a6e9", 1, false, "silvia@mail.com" },
                    { new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a"), 0, "7d485cc2-6395-4acf-941d-18b15f714169", null, null, new DateTime(2020, 11, 19, 11, 42, 36, 206, DateTimeKind.Utc).AddTicks(1361), new DateTime(1997, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Maria Petrova", "Sofia University", "maria@mail.com", false, false, false, null, null, "MARIA@MAIL.COM", "MARIA@MAIL.COM", "AQAAAAEAACcQAAAAEOgjqVSIGV+q+C55TRj+smRf2ax5Bux4JCjdVNehrM48bPjYpSGbJVfBWWIZtpSY9A==", "088666666", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg", "3e0773cf-7c38-45ec-b9e5-64f04183dd72", 1, false, "maria@mail.com" },
                    { new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196"), 0, "cca9abb8-2aae-4aad-89a0-7a89d1b02c19", null, null, new DateTime(2020, 11, 19, 11, 42, 36, 206, DateTimeKind.Utc).AddTicks(1397), new DateTime(1996, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pablo Georgiev", "Technical University", "pablo@mail.com", false, false, false, null, null, "PABLO@MAIL.COM", "PABLO@MAIL.COM", "AQAAAAEAACcQAAAAEN+kHNmIlMoiKzCxlWnWGM4M9AH6OjcDeGwmmPAaf+eeORDEpoWI09pqu1BNIXulcw==", "087777777", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/pablo_profile_pic.jpg", "944b09e6-de0e-4e48-abf7-79ec5c808d21", 1, false, "pablo@mail.com" },
                    { new Guid("7f8793ff-03ab-458c-bc0e-ed4866a55b48"), 0, "f66c338d-a845-4acc-8e4a-fceba60f19d3", null, null, new DateTime(2020, 11, 19, 11, 42, 36, 206, DateTimeKind.Utc).AddTicks(1416), new DateTime(1976, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Georgi Georgiev", "UNWE", "georgi@mail.com", false, false, false, null, null, "GEORGI@MAIL.COM", "GEORGI@MAIL.COM", "AQAAAAEAACcQAAAAEIkXn1kOw3uOeTZ74mC3HE7E0RU1+GhsFURTC+fEZL8lj3FEmFek6i7KHIf5fT31GA==", "0888888888", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "d57c5e92-1615-492e-b777-ba71d8bf9954", 1, false, "georgi@mail.com" },
                    { new Guid("d6f66ad9-58c9-43d6-adf8-4adbc3a97d36"), 0, "e3fc1cf2-8c7b-4e0b-8dcc-1f78174f1467", null, null, new DateTime(2020, 11, 19, 11, 42, 36, 206, DateTimeKind.Utc).AddTicks(1436), new DateTime(1999, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alexandra Kirova", "Sofia University", "alexandra@mail.com", false, false, false, null, null, "ALEXANDRA@MAIL.COM", "ALEXANDRA@MAIL.COM", "AQAAAAEAACcQAAAAEL4Vf1/5gzH/PDft9I5NlXjkX9eDb9JucH2syUWU7Ns2LvDOpZ4fEOizkI6MqFj1fQ==", "088899989", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/alexandra_profile_pic.jpg", "5d8c9935-48af-4954-a10a-cc686e8cc00f", 1, false, "alexandra@mail.com" },
                    { new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6"), 0, "2267d863-2378-4308-83e4-da67806a94e7", null, null, new DateTime(2020, 11, 19, 11, 42, 36, 206, DateTimeKind.Utc).AddTicks(1452), new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Stanislav Pulev", "UNWE", "stanisav@mail.com", false, false, false, null, null, "STANISLAV@MAIL.COM", "STANISLAV@MAIL.COM", "AQAAAAEAACcQAAAAEDM6ieA8H9FbSSHlieS0DwYnXuIzx+ed0NaVmcamzVXfzfCFvlRU6leHL+Hxbr9wuw==", "088679446", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "ab66fd64-126d-42d8-b431-7ab0b72d38db", 1, false, "stanislav@mail.com" },
                    { new Guid("35547a2a-8779-416b-9fc8-7aab34e883bd"), 0, "5dc597cf-6cd6-4628-b217-4f71870b634a", null, null, new DateTime(2020, 11, 19, 11, 42, 36, 206, DateTimeKind.Utc).AddTicks(1472), new DateTime(1999, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nikol Peeva", "Sofia University", "nikol@mail.com", false, false, false, null, null, "NIKOL@MAIL.COM", "NIKOL@MAIL.COM", "AQAAAAEAACcQAAAAECT2hiNpghne0gJg50T0DfrORykz4pvMOz0Q2TqQFhyIMl/QnpNgqqAKx8BgsEhYAg==", "08868324", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "50d4b914-3f75-4383-9a31-e90a562b23e3", 1, false, "nikol@mail.com" },
                    { new Guid("d93d2d61-e0ce-4a8d-9d61-93c8bc2849d7"), 0, "65fcebee-cf17-48a2-9810-69f269862819", null, null, new DateTime(2020, 11, 19, 11, 42, 36, 206, DateTimeKind.Utc).AddTicks(1489), new DateTime(1990, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Radko Stanev", "Telerik Academy", "radko@mail.com", false, false, false, null, null, "RADKO@MAIL.COM", "RADKO@MAIL.COM", "AQAAAAEAACcQAAAAEJdgJdezjxUtdKDuug81spBSs+o+ErTQJjiHamCueulSO8plN9oNYOwdguJlJeRv3w==", "545453423", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "1fc1dee1-2251-46cd-9e9f-15274f4fdbc6", 1, false, "radko@mail.com" },
                    { new Guid("5acf2b77-ab0a-4a04-8a5a-9ec38ffab96b"), 0, "aee09411-0609-4341-8cfd-e5f4702ffd30", null, null, new DateTime(2020, 11, 19, 11, 42, 36, 206, DateTimeKind.Utc).AddTicks(1505), new DateTime(1990, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kiro Stanoev", "Telerik Academy", "kiro@mail.com", false, false, false, null, null, "KIRO@MAIL.COM", "KIRO@MAIL.COM", "AQAAAAEAACcQAAAAEDdOtJKYl/YXVg+MVgBHeclEpED0qKAkLPh3WK+kBWAyWu8AmtI16PgizS79mo4lNA==", "5435345345", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "cf104f61-41a8-4d86-a1c6-21b91ae970b9", 1, false, "kiro@mail.com" },
                    { new Guid("6405b148-f626-4142-a342-0ccd2c82c30f"), 0, "4e85810c-074e-49a5-8d25-6d59acf0f261", null, null, new DateTime(2020, 11, 19, 11, 42, 36, 206, DateTimeKind.Utc).AddTicks(1520), new DateTime(1990, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bobi Hadzhiev", "Telerik Academy", "bobi@mail.com", false, false, false, null, null, "BOBI@MAIL.COM", "BOBI@MAIL.COM", "AQAAAAEAACcQAAAAEBKaloKQG1m0oWZudMFHI/qmOQipW4X1M/7U1rlfuLHcN3ViT6ZddFwkRPxYnG9eNA==", "653534564", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "7ada1108-169f-4b0f-b87c-4bef0ec0ae90", 1, false, "bobi@mail.com" }
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
                    { 6, new DateTime(2020, 11, 19, 11, 42, 36, 431, DateTimeKind.Utc).AddTicks(3291), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 3, new DateTime(2020, 11, 19, 11, 42, 36, 431, DateTimeKind.Utc).AddTicks(3220), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196") },
                    { 1, new DateTime(2020, 11, 19, 11, 42, 36, 430, DateTimeKind.Utc).AddTicks(8188), null, false, null, new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 7, new DateTime(2020, 11, 19, 11, 42, 36, 431, DateTimeKind.Utc).AddTicks(3308), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196") },
                    { 8, new DateTime(2020, 11, 19, 11, 42, 36, 431, DateTimeKind.Utc).AddTicks(3319), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6") },
                    { 5, new DateTime(2020, 11, 19, 11, 42, 36, 431, DateTimeKind.Utc).AddTicks(3275), null, false, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 4, new DateTime(2020, 11, 19, 11, 42, 36, 431, DateTimeKind.Utc).AddTicks(3242), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6") },
                    { 2, new DateTime(2020, 11, 19, 11, 42, 36, 431, DateTimeKind.Utc).AddTicks(3088), null, false, null, new Guid("35547a2a-8779-416b-9fc8-7aab34e883bd"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") }
                });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "UserFriendId", "UserId" },
                values: new object[,]
                {
                    { 5, new DateTime(2020, 11, 19, 11, 42, 36, 430, DateTimeKind.Utc).AddTicks(3655), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 1, new DateTime(2020, 11, 19, 11, 42, 36, 428, DateTimeKind.Utc).AddTicks(8475), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 14, new DateTime(2020, 11, 19, 11, 42, 36, 430, DateTimeKind.Utc).AddTicks(3788), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd") },
                    { 13, new DateTime(2020, 11, 19, 11, 42, 36, 430, DateTimeKind.Utc).AddTicks(3776), null, false, null, new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 8, new DateTime(2020, 11, 19, 11, 42, 36, 430, DateTimeKind.Utc).AddTicks(3704), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd") },
                    { 7, new DateTime(2020, 11, 19, 11, 42, 36, 430, DateTimeKind.Utc).AddTicks(3690), null, false, null, new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 2, new DateTime(2020, 11, 19, 11, 42, 36, 430, DateTimeKind.Utc).AddTicks(3377), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 16, new DateTime(2020, 11, 19, 11, 42, 36, 430, DateTimeKind.Utc).AddTicks(3811), null, false, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845") },
                    { 15, new DateTime(2020, 11, 19, 11, 42, 36, 430, DateTimeKind.Utc).AddTicks(3801), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { 12, new DateTime(2020, 11, 19, 11, 42, 36, 430, DateTimeKind.Utc).AddTicks(3763), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845") },
                    { 11, new DateTime(2020, 11, 19, 11, 42, 36, 430, DateTimeKind.Utc).AddTicks(3751), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 6, new DateTime(2020, 11, 19, 11, 42, 36, 430, DateTimeKind.Utc).AddTicks(3674), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845") },
                    { 3, new DateTime(2020, 11, 19, 11, 42, 36, 430, DateTimeKind.Utc).AddTicks(3513), null, false, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 4, new DateTime(2020, 11, 19, 11, 42, 36, 430, DateTimeKind.Utc).AddTicks(3533), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { 9, new DateTime(2020, 11, 19, 11, 42, 36, 430, DateTimeKind.Utc).AddTicks(3723), null, false, null, new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 10, new DateTime(2020, 11, 19, 11, 42, 36, 430, DateTimeKind.Utc).AddTicks(3738), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a") }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PhotoId", "UserId", "VideoId", "Visibility" },
                values: new object[,]
                {
                    { 9, "My new profile photo", new DateTime(2020, 11, 19, 11, 42, 36, 434, DateTimeKind.Utc).AddTicks(1457), null, false, null, 9, new Guid("d93d2d61-e0ce-4a8d-9d61-93c8bc2849d7"), null, 0 },
                    { 8, "My new profile photo", new DateTime(2020, 11, 19, 11, 42, 36, 434, DateTimeKind.Utc).AddTicks(1438), null, false, null, 8, new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196"), null, 0 },
                    { 12, "My new profile photo", new DateTime(2020, 11, 19, 11, 42, 36, 434, DateTimeKind.Utc).AddTicks(1538), null, false, null, 12, new Guid("7f8793ff-03ab-458c-bc0e-ed4866a55b48"), null, 0 },
                    { 13, "My new profile photo", new DateTime(2020, 11, 19, 11, 42, 36, 434, DateTimeKind.Utc).AddTicks(1553), null, false, null, 13, new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6"), null, 0 },
                    { 14, "My new profile photo", new DateTime(2020, 11, 19, 11, 42, 36, 434, DateTimeKind.Utc).AddTicks(1567), null, false, null, 14, new Guid("35547a2a-8779-416b-9fc8-7aab34e883bd"), null, 0 },
                    { 6, "My new profile photo", new DateTime(2020, 11, 19, 11, 42, 36, 434, DateTimeKind.Utc).AddTicks(1407), null, false, null, 6, new Guid("d6f66ad9-58c9-43d6-adf8-4adbc3a97d36"), null, 0 },
                    { 4, "My new profile photo", new DateTime(2020, 11, 19, 11, 42, 36, 434, DateTimeKind.Utc).AddTicks(1354), null, false, null, 4, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), null, 0 },
                    { 5, "My new profile photo", new DateTime(2020, 11, 19, 11, 42, 36, 434, DateTimeKind.Utc).AddTicks(1390), null, false, null, 5, new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), null, 0 },
                    { 10, "My new profile photo", new DateTime(2020, 11, 19, 11, 42, 36, 434, DateTimeKind.Utc).AddTicks(1503), null, false, null, 10, new Guid("5acf2b77-ab0a-4a04-8a5a-9ec38ffab96b"), null, 0 },
                    { 15, "My new profile photo", new DateTime(2020, 11, 19, 11, 42, 36, 434, DateTimeKind.Utc).AddTicks(1580), null, false, null, 15, new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), null, 0 },
                    { 20, "Really funny video :)", new DateTime(2020, 11, 19, 11, 42, 36, 434, DateTimeKind.Utc).AddTicks(1596), null, false, null, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), 1, 0 },
                    { 3, "My new profile photo", new DateTime(2020, 11, 19, 11, 42, 36, 434, DateTimeKind.Utc).AddTicks(1332), null, false, null, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), null, 0 },
                    { 2, "My new profile photo", new DateTime(2020, 11, 19, 11, 42, 36, 434, DateTimeKind.Utc).AddTicks(1179), null, false, null, 2, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), null, 0 },
                    { 1, "My new profile photo", new DateTime(2020, 11, 19, 11, 42, 36, 433, DateTimeKind.Utc).AddTicks(4318), null, false, null, 1, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), null, 0 },
                    { 7, "My new profile photo", new DateTime(2020, 11, 19, 11, 42, 36, 434, DateTimeKind.Utc).AddTicks(1420), null, false, null, 7, new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a"), null, 0 },
                    { 11, "My new profile photo", new DateTime(2020, 11, 19, 11, 42, 36, 434, DateTimeKind.Utc).AddTicks(1522), null, false, null, 11, new Guid("6405b148-f626-4142-a342-0ccd2c82c30f"), null, 0 }
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IconUrl", "IsDeleted", "ModifiedOn", "Name", "UserId", "UserLink" },
                values: new object[,]
                {
                    { 3, new DateTime(2020, 11, 19, 11, 42, 36, 436, DateTimeKind.Utc).AddTicks(9732), null, "", false, null, "Official website", new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), "https://www.telerikacademy.com/" },
                    { 2, new DateTime(2020, 11, 19, 11, 42, 36, 436, DateTimeKind.Utc).AddTicks(9603), null, "", false, null, "LinkedIn", new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), "https://www.linkedin.com/in/ali-marekov/" },
                    { 1, new DateTime(2020, 11, 19, 11, 42, 36, 436, DateTimeKind.Utc).AddTicks(3870), null, "", false, null, "Instagram", new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), "https://www.instagram.com/magisnikolova" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 1, "This is Amazing!", new DateTime(2020, 11, 19, 11, 42, 36, 431, DateTimeKind.Utc).AddTicks(6364), null, false, null, 1, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 2, "This is Awful!", new DateTime(2020, 11, 19, 11, 42, 36, 432, DateTimeKind.Utc).AddTicks(1464), null, false, null, 20, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 1, new DateTime(2020, 11, 19, 11, 42, 36, 435, DateTimeKind.Utc).AddTicks(8563), null, false, null, 1, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") });

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
