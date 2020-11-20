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
                    { new Guid("943b692d-330e-405d-a019-c3d728442143"), "8f52c751-40b0-46c7-818a-9d9033cce3bf", "Admin", "ADMIN" },
                    { new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"), "84809876-c10f-4281-b9c7-7d1de621e4b9", "User", "USER" }
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
                    { 15, new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(7790), null, false, null, 15, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 14, new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(7789), null, false, null, 14, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 13, new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(7786), null, false, null, 13, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 12, new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(7784), null, false, null, 12, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 11, new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(7782), null, false, null, 11, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 10, new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(7780), null, false, null, 10, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" },
                    { 5, new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(7766), null, false, null, 5, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/silvia_profile_pic.jpg" },
                    { 8, new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(7773), null, false, null, 8, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/pablo_profile_pic.jpg" },
                    { 7, new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(7771), null, false, null, 7, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg" },
                    { 6, new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(7769), null, false, null, 6, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/alexandra_profile_pic.jpg" },
                    { 4, new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(7757), null, false, null, 4, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/viktor_profile_pic.jpg" },
                    { 3, new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(7754), null, false, null, 3, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/telerik_profile_pic.jpg" },
                    { 2, new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(7715), null, false, null, 2, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/ali_profile_pic.jpg" },
                    { 1, new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(5447), null, false, null, 1, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/magi_profile_pic.jpg" },
                    { 9, new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(7778), null, false, null, 9, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "Url" },
                values: new object[] { 1, new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(9172), null, false, null, 20, "NONONONO" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 1, 1, "Sofia" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CoverPictureId", "CoverPictureUrl", "CreatedOn", "DateOfBirth", "DeletedOn", "DisplayName", "Education", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureId", "ProfilePictureUrl", "SecurityStamp", "TownId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), 0, "b4509e53-42e2-4daa-ab72-cd25c8a4d71e", null, null, new DateTime(2020, 11, 20, 16, 12, 57, 600, DateTimeKind.Utc).AddTicks(1911), new DateTime(1997, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Magi Nikolova", "Sofia University", "magi@mail.com", false, false, false, null, null, "MAGI@MAIL.COM", "MAGI@MAIL.COM", "AQAAAAEAACcQAAAAEEW1qcgHCBydEIBoUicUyBiXI3hFvoq4eUNt7SH+3BSnyG4uBLT4v/XbrsXQ1w+Hmw==", "0886868686", false, 1, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/magi_profile_pic.jpg", "489f9572-daa4-4411-8911-6554922e3a5a", 1, false, "magi@mail.com" },
                    { new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), 0, "30d64ab6-6515-4075-91ec-7b6cbff8c643", null, null, new DateTime(2020, 11, 20, 16, 12, 57, 601, DateTimeKind.Utc).AddTicks(3689), new DateTime(1999, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ali Marekov", "Technical University", "ali@mail.com", false, false, false, null, null, "ALI@MAIL.COM", "ALI@MAIL.COM", "AQAAAAEAACcQAAAAEEsBNA/hVU6Hn1p4YR5sAs2gJxf5xHuJwLvM4dW+9wv4/MXrz1alsR5R8GMI09QGIg==", "088686843", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/ali_profile_pic.jpg", "6bd4dcd7-5ad4-4ef8-b895-6347b9d7cbc1", 1, false, "ali@mail.com" },
                    { new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), 0, "b52f5ca0-c352-4c65-ae7b-8dc495b68630", null, null, new DateTime(2020, 11, 20, 16, 12, 57, 601, DateTimeKind.Utc).AddTicks(3822), new DateTime(2010, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Telerik Academy", "Telerik Academy", "telerik@mail.com", false, false, false, null, null, "TELERIK@MAIL.COM", "TELERIK@MAIL.COM", "AQAAAAEAACcQAAAAEE9y/IR5nlTiQRJhTWS1iPSaFDO/qEizHBGbrkj0GkxnA3vEff1PZ21frwynTmRRrQ==", "081111111", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/telerik_profile_pic.jpg", "3e2a093c-0c1e-4492-80a3-2c38b5110342", 1, false, "telerik@mail.com" },
                    { new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), 0, "f8e13a3d-b9af-491f-a048-cd4ea8e30291", null, null, new DateTime(2020, 11, 20, 16, 12, 57, 601, DateTimeKind.Utc).AddTicks(3846), new DateTime(2010, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C Sharp", "Alpha C# Track", "csharp@mail.com", false, false, false, null, null, "CSHARP@MAIL.COM", "CSHARP@MAIL.COM", "AQAAAAEAACcQAAAAEILNK/piDlvo3BvnCwV3E8Eja8tR1qb5hyLypMI5SZZ3xQtGDPaVcAbNgYBYlNSo9g==", "0833333333", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "3fb56dc9-7f32-4200-acc9-2ac4020306f9", 1, false, "csharp@mail.com" },
                    { new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), 0, "c5723217-9e45-45f6-9746-7dc28160f062", null, null, new DateTime(2020, 11, 20, 16, 12, 57, 601, DateTimeKind.Utc).AddTicks(3865), new DateTime(1996, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Viktor Ivanov", "Technical University", "viktor@mail.com", false, false, false, null, null, "VIKTOR@MAIL.COM", "VIKTOR@MAIL.COM", "AQAAAAEAACcQAAAAEKxKQlckVFfEIyer1qEhpSCie5LQ+JA1KX9eQKtSDvC58hGU1n28RS/6s/8U7QroZQ==", "0884444444", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/viktor_profile_pic.jpg", "696a1e85-d24e-4535-864d-9cbf3ab27945", 1, false, "viktor@mail.com" },
                    { new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), 0, "d224f7bb-00c3-477a-a682-b36d23b20264", null, null, new DateTime(2020, 11, 20, 16, 12, 57, 601, DateTimeKind.Utc).AddTicks(3896), new DateTime(2000, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Silvia Borisova", "Sofia University", "silvia@mail.com", false, false, false, null, null, "SILVIA@MAIL.COM", "SILVIA@MAIL.COM", "AQAAAAEAACcQAAAAEGsT82U6F4/ZPiJ9gmLxYUg/EbFs1x+C72mDgnM+v7/UOF1eU3SVy9V7+GTEijY8cg==", "088555555", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/silvia_profile_pic.jpg", "0095ae9e-8927-4e7b-a92d-9e894658da29", 1, false, "silvia@mail.com" },
                    { new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a"), 0, "d8de154d-9dbd-42ce-a0f1-a4c45a2ecd07", null, null, new DateTime(2020, 11, 20, 16, 12, 57, 601, DateTimeKind.Utc).AddTicks(3935), new DateTime(1997, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Maria Petrova", "Sofia University", "maria@mail.com", false, false, false, null, null, "MARIA@MAIL.COM", "MARIA@MAIL.COM", "AQAAAAEAACcQAAAAEBH7b7p+VWSOgbQiYhd2m9gvpvMSAwMP+S8TM1xFzeBlsapkVbhgPQU3lMy3zseCrQ==", "088666666", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg", "73e2e9ca-9499-4d55-ab5a-14eaad4f8310", 1, false, "maria@mail.com" },
                    { new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196"), 0, "7a7953c7-d504-4e62-9a65-808e9e0f4ad2", null, null, new DateTime(2020, 11, 20, 16, 12, 57, 601, DateTimeKind.Utc).AddTicks(3953), new DateTime(1996, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pablo Georgiev", "Technical University", "pablo@mail.com", false, false, false, null, null, "PABLO@MAIL.COM", "PABLO@MAIL.COM", "AQAAAAEAACcQAAAAEKvLfhifEra/YBEwJmro6Qo/ghKOOzf/mOIabxBJ1zCKg0sUPaufs97g8OBore7nMA==", "087777777", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/pablo_profile_pic.jpg", "6106d5ec-21bf-472f-ad18-3200b854f69f", 1, false, "pablo@mail.com" },
                    { new Guid("7f8793ff-03ab-458c-bc0e-ed4866a55b48"), 0, "303a4827-ac71-4602-930c-bcee2afc01d8", null, null, new DateTime(2020, 11, 20, 16, 12, 57, 601, DateTimeKind.Utc).AddTicks(3969), new DateTime(1976, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Georgi Georgiev", "UNWE", "georgi@mail.com", false, false, false, null, null, "GEORGI@MAIL.COM", "GEORGI@MAIL.COM", "AQAAAAEAACcQAAAAEAIER93093atBu38ULNG4/+W3MDamorzqznMy2ApVAQELNUns9FC/Fq6/7WBUBbEgA==", "0888888888", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "964127ca-39ef-4dc0-a87b-da85f2353175", 1, false, "georgi@mail.com" },
                    { new Guid("d6f66ad9-58c9-43d6-adf8-4adbc3a97d36"), 0, "0c6e8ee7-be8a-4525-ba1c-779fb7d12426", null, null, new DateTime(2020, 11, 20, 16, 12, 57, 601, DateTimeKind.Utc).AddTicks(3988), new DateTime(1999, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alexandra Kirova", "Sofia University", "alexandra@mail.com", false, false, false, null, null, "ALEXANDRA@MAIL.COM", "ALEXANDRA@MAIL.COM", "AQAAAAEAACcQAAAAEKNvwUdZsf7HlGec7N2Bp36CRspN80njYG9VZpegfKq4dNsWSPvDNbXCqjAlnjfG0w==", "088899989", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/alexandra_profile_pic.jpg", "a78a9503-ed56-4809-a7a4-30fe07bc6472", 1, false, "alexandra@mail.com" },
                    { new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6"), 0, "baceff03-fa99-4542-88a9-298966475375", null, null, new DateTime(2020, 11, 20, 16, 12, 57, 601, DateTimeKind.Utc).AddTicks(4011), new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Stanislav Pulev", "UNWE", "stanisav@mail.com", false, false, false, null, null, "STANISLAV@MAIL.COM", "STANISLAV@MAIL.COM", "AQAAAAEAACcQAAAAENBwMmKzD7k5/W3F/vt2ugdLlNNlKJAiXaWnSKrdsetEMUd+A4/iNFyRN46S6wZYsA==", "088679446", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "0731b724-0c8b-4009-9233-e47a3f624e7c", 1, false, "stanislav@mail.com" },
                    { new Guid("35547a2a-8779-416b-9fc8-7aab34e883bd"), 0, "6d8dd0b5-6a8d-470c-b07c-28e48d71c399", null, null, new DateTime(2020, 11, 20, 16, 12, 57, 601, DateTimeKind.Utc).AddTicks(4032), new DateTime(1999, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nikol Peeva", "Sofia University", "nikol@mail.com", false, false, false, null, null, "NIKOL@MAIL.COM", "NIKOL@MAIL.COM", "AQAAAAEAACcQAAAAEKYBLyhjpqvTZvYIfd97x8M6i97mU7xULvW5xn3Lrnuo5SfN1L0yHgRJ5NKOKza9UA==", "08868324", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "56b56198-3a5b-4225-aa21-77dc3ebf9257", 1, false, "nikol@mail.com" },
                    { new Guid("d93d2d61-e0ce-4a8d-9d61-93c8bc2849d7"), 0, "448e02d5-f491-4bda-b788-44e280046c05", null, null, new DateTime(2020, 11, 20, 16, 12, 57, 601, DateTimeKind.Utc).AddTicks(4047), new DateTime(1990, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Radko Stanev", "Telerik Academy", "radko@mail.com", false, false, false, null, null, "RADKO@MAIL.COM", "RADKO@MAIL.COM", "AQAAAAEAACcQAAAAEMbE+3jD8+nnJfjZig0Pkc5oD96aTPAVhvhh/dAi64Kj5L/0ye+T7IPtp0JrOqRzlg==", "545453423", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "04d7c85e-05ff-4b84-987a-8ed439b5a1e3", 1, false, "radko@mail.com" },
                    { new Guid("5acf2b77-ab0a-4a04-8a5a-9ec38ffab96b"), 0, "20e7f7cf-4241-4ed4-9ef4-47db1272a247", null, null, new DateTime(2020, 11, 20, 16, 12, 57, 601, DateTimeKind.Utc).AddTicks(4062), new DateTime(1990, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kiro Stanoev", "Telerik Academy", "kiro@mail.com", false, false, false, null, null, "KIRO@MAIL.COM", "KIRO@MAIL.COM", "AQAAAAEAACcQAAAAEGoEQ6qTVnB2hMUJElYWjjY+RSTdpEchThvTVyy+4muSbeFV8JgKloZfeGOTcdf6Cg==", "5435345345", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "c9d01f68-3492-4a53-8167-a48a63283e64", 1, false, "kiro@mail.com" },
                    { new Guid("6405b148-f626-4142-a342-0ccd2c82c30f"), 0, "57b5d185-3bad-4ae1-81ac-cc6ced70c185", null, null, new DateTime(2020, 11, 20, 16, 12, 57, 601, DateTimeKind.Utc).AddTicks(4090), new DateTime(1990, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bobi Hadzhiev", "Telerik Academy", "bobi@mail.com", false, false, false, null, null, "BOBI@MAIL.COM", "BOBI@MAIL.COM", "AQAAAAEAACcQAAAAEDold/tgpxEqa8ZLZUIFgWpcJsEDkrfHaZUmzc5/xC9hYGfLNVw+NTB6KenCdb6IZw==", "653534564", false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "bc0fe243-c610-4b92-a050-a545c109f580", 1, false, "bobi@mail.com" }
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
                    { 3, new DateTime(2020, 11, 20, 16, 12, 57, 737, DateTimeKind.Utc).AddTicks(3516), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196") },
                    { 1, new DateTime(2020, 11, 20, 16, 12, 57, 737, DateTimeKind.Utc).AddTicks(892), null, false, null, new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 4, new DateTime(2020, 11, 20, 16, 12, 57, 737, DateTimeKind.Utc).AddTicks(3527), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6") },
                    { 7, new DateTime(2020, 11, 20, 16, 12, 57, 737, DateTimeKind.Utc).AddTicks(3549), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196") },
                    { 5, new DateTime(2020, 11, 20, 16, 12, 57, 737, DateTimeKind.Utc).AddTicks(3543), null, false, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 2, new DateTime(2020, 11, 20, 16, 12, 57, 737, DateTimeKind.Utc).AddTicks(3457), null, false, null, new Guid("35547a2a-8779-416b-9fc8-7aab34e883bd"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 8, new DateTime(2020, 11, 20, 16, 12, 57, 737, DateTimeKind.Utc).AddTicks(3555), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6") }
                });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "UserFriendId", "UserId" },
                values: new object[,]
                {
                    { 2, new DateTime(2020, 11, 20, 16, 12, 57, 736, DateTimeKind.Utc).AddTicks(8006), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 10, new DateTime(2020, 11, 20, 16, 12, 57, 736, DateTimeKind.Utc).AddTicks(8141), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a") },
                    { 9, new DateTime(2020, 11, 20, 16, 12, 57, 736, DateTimeKind.Utc).AddTicks(8136), null, false, null, new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 1, new DateTime(2020, 11, 20, 16, 12, 57, 736, DateTimeKind.Utc).AddTicks(5108), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 14, new DateTime(2020, 11, 20, 16, 12, 57, 736, DateTimeKind.Utc).AddTicks(8164), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd") },
                    { 13, new DateTime(2020, 11, 20, 16, 12, 57, 736, DateTimeKind.Utc).AddTicks(8158), null, false, null, new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 8, new DateTime(2020, 11, 20, 16, 12, 57, 736, DateTimeKind.Utc).AddTicks(8126), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd") },
                    { 7, new DateTime(2020, 11, 20, 16, 12, 57, 736, DateTimeKind.Utc).AddTicks(8118), null, false, null, new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 5, new DateTime(2020, 11, 20, 16, 12, 57, 736, DateTimeKind.Utc).AddTicks(8103), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 16, new DateTime(2020, 11, 20, 16, 12, 57, 736, DateTimeKind.Utc).AddTicks(8176), null, false, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845") },
                    { 15, new DateTime(2020, 11, 20, 16, 12, 57, 736, DateTimeKind.Utc).AddTicks(8169), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { 12, new DateTime(2020, 11, 20, 16, 12, 57, 736, DateTimeKind.Utc).AddTicks(8152), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845") },
                    { 11, new DateTime(2020, 11, 20, 16, 12, 57, 736, DateTimeKind.Utc).AddTicks(8147), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 6, new DateTime(2020, 11, 20, 16, 12, 57, 736, DateTimeKind.Utc).AddTicks(8112), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845") },
                    { 3, new DateTime(2020, 11, 20, 16, 12, 57, 736, DateTimeKind.Utc).AddTicks(8074), null, false, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 4, new DateTime(2020, 11, 20, 16, 12, 57, 736, DateTimeKind.Utc).AddTicks(8084), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("3753d26b-5a35-491f-ae82-5238d243b619") }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PhotoId", "UserId", "VideoId", "Visibility" },
                values: new object[,]
                {
                    { 13, "My new profile photo", new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(3249), null, false, null, 13, new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6"), null, 0 },
                    { 14, "My new profile photo", new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(3254), null, false, null, 14, new Guid("35547a2a-8779-416b-9fc8-7aab34e883bd"), null, 0 },
                    { 8, "My new profile photo", new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(3209), null, false, null, 8, new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196"), null, 0 },
                    { 9, "My new profile photo", new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(3220), null, false, null, 9, new Guid("d93d2d61-e0ce-4a8d-9d61-93c8bc2849d7"), null, 0 },
                    { 12, "My new profile photo", new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(3242), null, false, null, 12, new Guid("7f8793ff-03ab-458c-bc0e-ed4866a55b48"), null, 0 },
                    { 6, "My new profile photo", new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(3182), null, false, null, 6, new Guid("d6f66ad9-58c9-43d6-adf8-4adbc3a97d36"), null, 0 },
                    { 4, "My new profile photo", new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(3161), null, false, null, 4, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), null, 0 },
                    { 5, "My new profile photo", new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(3174), null, false, null, 5, new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), null, 0 },
                    { 10, "My new profile photo", new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(3229), null, false, null, 10, new Guid("5acf2b77-ab0a-4a04-8a5a-9ec38ffab96b"), null, 0 },
                    { 15, "My new profile photo", new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(3260), null, false, null, 15, new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), null, 0 },
                    { 20, "Really funny video :)", new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(3266), null, false, null, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), 1, 0 },
                    { 3, "My new profile photo", new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(3152), null, false, null, 3, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), null, 0 },
                    { 2, "My new profile photo", new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(3083), null, false, null, 2, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), null, 0 },
                    { 1, "My new profile photo", new DateTime(2020, 11, 20, 16, 12, 57, 738, DateTimeKind.Utc).AddTicks(9148), null, false, null, 1, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), null, 0 },
                    { 7, "My new profile photo", new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(3190), null, false, null, 7, new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a"), null, 0 },
                    { 11, "My new profile photo", new DateTime(2020, 11, 20, 16, 12, 57, 739, DateTimeKind.Utc).AddTicks(3235), null, false, null, 11, new Guid("6405b148-f626-4142-a342-0ccd2c82c30f"), null, 0 }
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IconUrl", "IsDeleted", "ModifiedOn", "Name", "UserId", "UserLink" },
                values: new object[,]
                {
                    { 3, new DateTime(2020, 11, 20, 16, 12, 57, 741, DateTimeKind.Utc).AddTicks(19), null, "", false, null, "Official website", new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), "https://www.telerikacademy.com/" },
                    { 2, new DateTime(2020, 11, 20, 16, 12, 57, 740, DateTimeKind.Utc).AddTicks(9952), null, "", false, null, "LinkedIn", new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), "https://www.linkedin.com/in/ali-marekov/" },
                    { 1, new DateTime(2020, 11, 20, 16, 12, 57, 740, DateTimeKind.Utc).AddTicks(6287), null, "", false, null, "Instagram", new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), "https://www.instagram.com/magisnikolova" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 1, "This is Amazing!", new DateTime(2020, 11, 20, 16, 12, 57, 737, DateTimeKind.Utc).AddTicks(4953), null, false, null, 1, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 2, "This is Awful!", new DateTime(2020, 11, 20, 16, 12, 57, 737, DateTimeKind.Utc).AddTicks(7951), null, false, null, 20, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 1, new DateTime(2020, 11, 20, 16, 12, 57, 740, DateTimeKind.Utc).AddTicks(2585), null, false, null, 1, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") });

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
