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
                    { new Guid("943b692d-330e-405d-a019-c3d728442143"), "edb77796-adbe-4589-898a-e66aa77bbf10", "Admin", "ADMIN" },
                    { new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"), "c7fa9998-62e6-4c5e-b8c9-d6d1088d0a88", "User", "USER" }
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
                values: new object[] { 1, new DateTime(2020, 11, 18, 10, 30, 15, 120, DateTimeKind.Utc).AddTicks(797), null, false, null, 10, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/magi_profile_pic.jpg" });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "Url" },
                values: new object[] { 1, new DateTime(2020, 11, 18, 10, 30, 15, 120, DateTimeKind.Utc).AddTicks(3467), null, false, null, 20, "NONONONO" });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 1, 1, "Sofia" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CoverPictureId", "CoverPictureUrl", "CreatedOn", "DateOfBirth", "DeletedOn", "DisplayName", "Education", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureId", "ProfilePictureUrl", "SecurityStamp", "TownId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), 0, "8b60a164-0088-4936-ba0f-1ce7cf05ad52", null, null, new DateTime(2020, 11, 18, 10, 30, 14, 990, DateTimeKind.Utc).AddTicks(1674), new DateTime(1997, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Magi Nikolova", "Sofia University", "magi@mail.com", false, false, false, null, null, "MAGI@MAIL.COM", "MAGI@MAIL.COM", "AQAAAAEAACcQAAAAEEOva3JIz99tJJgI9fKCS+JF6RSYpsT5DvUIXmEJ4ROnan91DK32CqrmCwUUYs8lKg==", null, false, 1, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/magi_profile_pic.jpg", "b692d6dc-fb76-482c-b19f-87c573728d3f", 1, false, "magi@mail.com" },
                    { new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), 0, "0e77fb70-3ba7-4c4b-8025-ea8042346281", null, null, new DateTime(2020, 11, 18, 10, 30, 14, 990, DateTimeKind.Utc).AddTicks(9899), new DateTime(1999, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ali Marekov", "Technical University", "ali@mail.com", false, false, false, null, null, "ALI@MAIL.COM", "ALI@MAIL.COM", "AQAAAAEAACcQAAAAEKgy8GPAj7HXc4TpMpFw15/jUbYKSXkkXUbkhCUGulPbHmGXjz0DT3mYonmIoQVtsw==", null, false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/ali_profile_pic.jpg", "7020de6d-ee9f-417e-b272-97a2c8411696", 1, false, "ali@mail.com" },
                    { new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), 0, "c9c3838d-ea89-4ab2-a585-a29b17b00461", null, null, new DateTime(2020, 11, 18, 10, 30, 14, 990, DateTimeKind.Utc).AddTicks(9986), new DateTime(2010, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Telerik Academy", "Telerik Academy", "telerik@mail.com", false, false, false, null, null, "TELERIK@MAIL.COM", "TELERIK@MAIL.COM", "AQAAAAEAACcQAAAAEMZUTD9l7FojB2bzd0tFWOFQIFnJKaigCo5pPiKmwGVmgyAHiuYepFWLEWBLSwhNKA==", null, false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/telerik_profile_pic.jpg", "607ce7a5-96a8-463a-971b-1104888a068a", 1, false, "telerik@mail.com" },
                    { new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), 0, "d26b2b6e-3bbb-49df-a6ac-a3d9056f28a9", null, null, new DateTime(2020, 11, 18, 10, 30, 14, 991, DateTimeKind.Utc).AddTicks(9), new DateTime(2010, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "C#", "Alpha C# Track", "csharp@mail.com", false, false, false, null, null, "CSHARP@MAIL.COM", "CSHARP@MAIL.COM", "AQAAAAEAACcQAAAAEMdz8bdCGUVI58QHXI1hkE0tUUMeuW79t62xsMyh99ksSCM/m1jcg/n2icCFSdmISg==", null, false, null, "", "e56df7f2-e49c-4e66-a7e3-ceea53308844", 1, false, "csharp@mail.com" },
                    { new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), 0, "bd90af70-9a70-428a-969a-9c53c1f3292f", null, null, new DateTime(2020, 11, 18, 10, 30, 14, 991, DateTimeKind.Utc).AddTicks(25), new DateTime(1996, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Viktor Ivanov", "Technical University", "viktor@mail.com", false, false, false, null, null, "VIKTOR@MAIL.COM", "VIKTOR@MAIL.COM", "AQAAAAEAACcQAAAAEAbrUWjcpRHlNYh2HCpEihTGlpR0O0wA0Gp/v1JO/KuSLJkJPPjMY/hrVIxCtafRFg==", null, false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/viktor_profile_pic.jpg", "db185b5e-f15d-4df4-a5f9-425e524188b2", 1, false, "viktor@mail.com" },
                    { new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), 0, "62aa90a6-5846-417d-a570-b2a8770ffcb3", null, null, new DateTime(2020, 11, 18, 10, 30, 14, 991, DateTimeKind.Utc).AddTicks(41), new DateTime(2000, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Silvia Borisova", "Sofia University", "silvia@mail.com", false, false, false, null, null, "SILVIA@MAIL.COM", "SILVIA@MAIL.COM", "AQAAAAEAACcQAAAAEMeMVWsiaQe4UFU2koTFS2cWcgpZcCVHwbGgfHC2onCq0QU9XiN/O2ZQHsXVVIwc7Q==", null, false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/silvia_profile_pic.jpg", "b7d124cd-7b93-4e8e-85df-6ebde0fe9f22", 1, false, "silvia@mail.com" },
                    { new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a"), 0, "b837d742-9b2b-4ff6-8ef1-b2396f821120", null, null, new DateTime(2020, 11, 18, 10, 30, 14, 991, DateTimeKind.Utc).AddTicks(53), new DateTime(1997, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Maria Petrova", "Sofia University", "maria@mail.com", false, false, false, null, null, "MARIA@MAIL.COM", "MARIA@MAIL.COM", "AQAAAAEAACcQAAAAEL+uG1NotI9MWjIyDiplqNl+MRFuty0r7LesINip/I2GYqZeuCU/pyr8gilIRbc27A==", null, false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/maria_profile_pic.jpg", "21e4799a-a126-434b-8130-330083ef3be0", 1, false, "maria@mail.com" },
                    { new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196"), 0, "fa50285b-ab90-48ac-925c-4ddc7a82d168", null, null, new DateTime(2020, 11, 18, 10, 30, 14, 991, DateTimeKind.Utc).AddTicks(120), new DateTime(1996, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pablo Georgiev", "Technical University", "pablo@mail.com", false, false, false, null, null, "PABLO@MAIL.COM", "PABLO@MAIL.COM", "AQAAAAEAACcQAAAAEGVXryY86Og4wqp+TPtHan6qWZQguMIlN24kKo7bmGv/U9QQgz6pD2HoJC7yWdHMdw==", null, false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/pablo_profile_pic.jpg", "197b5cd2-1b70-47bf-8134-1ecd8a762626", 1, false, "pablo@mail.com" },
                    { new Guid("7f8793ff-03ab-458c-bc0e-ed4866a55b48"), 0, "6e17298e-c61c-401a-9c32-283d2f23f4ed", null, null, new DateTime(2020, 11, 18, 10, 30, 14, 991, DateTimeKind.Utc).AddTicks(136), new DateTime(1976, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Georgi Georgiev", "UNWE", "georgi@mail.com", false, false, false, null, null, "GEORGI@MAIL.COM", "GEORGI@MAIL.COM", "AQAAAAEAACcQAAAAEBak2PS35Usp54rR/YrZJaGCMaQQsxv0OmPVtc3zCzrL5O8uEsNup41+m2mOWdZD8A==", null, false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "aed3d66b-dc6b-46bb-b444-bc902c763481", 1, false, "georgi@mail.com" },
                    { new Guid("d6f66ad9-58c9-43d6-adf8-4adbc3a97d36"), 0, "76fa7543-b6be-466c-84a5-04777772a0e9", null, null, new DateTime(2020, 11, 18, 10, 30, 14, 991, DateTimeKind.Utc).AddTicks(148), new DateTime(1999, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Alexandra Kirova", "Sofia University", "alexandra@mail.com", false, false, false, null, null, "ALEXANDRA@MAIL.COM", "ALEXANDRA@MAIL.COM", "AQAAAAEAACcQAAAAECSp69Lx0tiNiZWrWhWnjHX4siBudLYZCWR3Rn4sVqHGdAK1UGISaNXG/xd/TEIj9A==", null, false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/alexandra_profile_pic.jpg", "d3675c25-66bb-42d1-abe8-82e8d6da5667", 1, false, "alexandra@mail.com" },
                    { new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6"), 0, "76eee15c-f646-4bab-833d-f274ad5467f5", null, null, new DateTime(2020, 11, 18, 10, 30, 14, 991, DateTimeKind.Utc).AddTicks(159), new DateTime(2000, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Stanislav Pulev", "UNWE", "stanisav@mail.com", false, false, false, null, null, "STANISLAV@MAIL.COM", "STANISLAV@MAIL.COM", "AQAAAAEAACcQAAAAEHARVNduormtUoYk9xO0ZIh6E4xDM7eVyuCCZeEBHG+5iMisIetM6kqSd6ZZlTW4pw==", null, false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "b8277834-1178-4d9a-95c7-4e15b7e7e100", 1, false, "stanislav@mail.com" },
                    { new Guid("35547a2a-8779-416b-9fc8-7aab34e883bd"), 0, "de80cd36-219c-4ce2-8b87-329d17b0db19", null, null, new DateTime(2020, 11, 18, 10, 30, 14, 991, DateTimeKind.Utc).AddTicks(175), new DateTime(1999, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Nikol Peeva", "Sofia University", "nikol@mail.com", false, false, false, null, null, "NIKOL@MAIL.COM", "NIKOL@MAIL.COM", "AQAAAAEAACcQAAAAEH/1sXSSAuf6F/yv7dM/IkIoxkUICCwIg7MqxVl2xcWrRG5bUrP5yYyOvziAlayeXQ==", null, false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "5811e4fc-0ab1-4adb-b3fd-79947558323f", 1, false, "nikol@mail.com" },
                    { new Guid("d93d2d61-e0ce-4a8d-9d61-93c8bc2849d7"), 0, "34c200d3-68bf-4373-b730-18817cbf8a58", null, null, new DateTime(2020, 11, 18, 10, 30, 14, 991, DateTimeKind.Utc).AddTicks(187), new DateTime(1990, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Radko Stanev", "Telerik Academy", "radko@mail.com", false, false, false, null, null, "RADKO@MAIL.COM", "RADKO@MAIL.COM", "AQAAAAEAACcQAAAAECjJBP1gNYPonNj+wnH6FsbthIhXfNPF++BE+AUyPcwTy0n1zQxnOKz5q56UIrIzdg==", null, false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "7d887b17-6b29-469b-bc0c-328f1c7eaf32", 1, false, "radko@mail.com" },
                    { new Guid("5acf2b77-ab0a-4a04-8a5a-9ec38ffab96b"), 0, "ae5997e2-0198-4ce6-ab66-8fe45d5a745f", null, null, new DateTime(2020, 11, 18, 10, 30, 14, 991, DateTimeKind.Utc).AddTicks(199), new DateTime(1990, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Kiro Stanoev", "Telerik Academy", "kiro@mail.com", false, false, false, null, null, "KIRO@MAIL.COM", "KIRO@MAIL.COM", "AQAAAAEAACcQAAAAEACnmXoU5+WLNsGUybJoTSLQZjJl+lGBZ/pEYYMge6mZ0kQME7EiDmSPs+cN+FjTig==", null, false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "3b8ac30a-b32b-425d-8b25-8d34d3c533a3", 1, false, "kiro@mail.com" },
                    { new Guid("6405b148-f626-4142-a342-0ccd2c82c30f"), 0, "e571e2d1-190a-4388-9e50-38d0758b2955", null, null, new DateTime(2020, 11, 18, 10, 30, 14, 991, DateTimeKind.Utc).AddTicks(207), new DateTime(1990, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bobi Hadzhiev", "Telerik Academy", "bobi@mail.com", false, false, false, null, null, "BOBI@MAIL.COM", "BOBI@MAIL.COM", "AQAAAAEAACcQAAAAECRXkyAtzbmaawCfeIbM0obbjOIIR5ypx6qF9zPaDzcZRTlQwjAhWwAPqLv449cWGg==", null, false, null, "https://socialnetworkstorage.blob.core.windows.net/filescontainers/no_avatar.jpg", "38f01ada-9428-499c-8df1-05c4dcd81e19", 1, false, "bobi@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("943b692d-330e-405d-a019-c3d728442143") },
                    { new Guid("d6f66ad9-58c9-43d6-adf8-4adbc3a97d36"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") },
                    { new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("943b692d-330e-405d-a019-c3d728442143") },
                    { new Guid("7f8793ff-03ab-458c-bc0e-ed4866a55b48"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") },
                    { new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") },
                    { new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") },
                    { new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") },
                    { new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") },
                    { new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") },
                    { new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") }
                });

            migrationBuilder.InsertData(
                table: "FriendRequests",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "ReceiverId", "SenderId" },
                values: new object[,]
                {
                    { 4, new DateTime(2020, 11, 18, 10, 30, 15, 118, DateTimeKind.Utc).AddTicks(3619), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6") },
                    { 7, new DateTime(2020, 11, 18, 10, 30, 15, 118, DateTimeKind.Utc).AddTicks(3635), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196") },
                    { 3, new DateTime(2020, 11, 18, 10, 30, 15, 118, DateTimeKind.Utc).AddTicks(3611), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("5d7ccf05-3080-4a9e-90ca-a4fee33aa196") },
                    { 6, new DateTime(2020, 11, 18, 10, 30, 15, 118, DateTimeKind.Utc).AddTicks(3631), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 8, new DateTime(2020, 11, 18, 10, 30, 15, 118, DateTimeKind.Utc).AddTicks(3639), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("a9e49452-8ffd-460d-9998-8f662e36a2d6") },
                    { 2, new DateTime(2020, 11, 18, 10, 30, 15, 118, DateTimeKind.Utc).AddTicks(3571), null, false, null, new Guid("35547a2a-8779-416b-9fc8-7aab34e883bd"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 1, new DateTime(2020, 11, 18, 10, 30, 15, 118, DateTimeKind.Utc).AddTicks(1525), null, false, null, new Guid("dc6788da-53ae-44e7-b53c-e53a2f77a1af"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 5, new DateTime(2020, 11, 18, 10, 30, 15, 118, DateTimeKind.Utc).AddTicks(3627), null, false, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") }
                });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "UserFriendId", "UserId" },
                values: new object[,]
                {
                    { 6, new DateTime(2020, 11, 18, 10, 30, 15, 117, DateTimeKind.Utc).AddTicks(9858), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845") },
                    { 1, new DateTime(2020, 11, 18, 10, 30, 15, 117, DateTimeKind.Utc).AddTicks(6492), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 2, new DateTime(2020, 11, 18, 10, 30, 15, 117, DateTimeKind.Utc).AddTicks(9735), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 3, new DateTime(2020, 11, 18, 10, 30, 15, 117, DateTimeKind.Utc).AddTicks(9775), null, false, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 10, new DateTime(2020, 11, 18, 10, 30, 15, 117, DateTimeKind.Utc).AddTicks(9878), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a") },
                    { 9, new DateTime(2020, 11, 18, 10, 30, 15, 117, DateTimeKind.Utc).AddTicks(9874), null, false, null, new Guid("b87071f5-b71c-45e1-91e7-6e85637ed10a"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 4, new DateTime(2020, 11, 18, 10, 30, 15, 117, DateTimeKind.Utc).AddTicks(9779), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { 5, new DateTime(2020, 11, 18, 10, 30, 15, 117, DateTimeKind.Utc).AddTicks(9850), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 14, new DateTime(2020, 11, 18, 10, 30, 15, 117, DateTimeKind.Utc).AddTicks(9893), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd") },
                    { 8, new DateTime(2020, 11, 18, 10, 30, 15, 117, DateTimeKind.Utc).AddTicks(9866), null, false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd") },
                    { 7, new DateTime(2020, 11, 18, 10, 30, 15, 117, DateTimeKind.Utc).AddTicks(9862), null, false, null, new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") },
                    { 16, new DateTime(2020, 11, 18, 10, 30, 15, 117, DateTimeKind.Utc).AddTicks(9901), null, false, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845") },
                    { 15, new DateTime(2020, 11, 18, 10, 30, 15, 117, DateTimeKind.Utc).AddTicks(9897), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("3753d26b-5a35-491f-ae82-5238d243b619") },
                    { 11, new DateTime(2020, 11, 18, 10, 30, 15, 117, DateTimeKind.Utc).AddTicks(9882), null, false, null, new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 13, new DateTime(2020, 11, 18, 10, 30, 15, 117, DateTimeKind.Utc).AddTicks(9889), null, false, null, new Guid("0d852e3a-b977-438a-9c33-7679a6e7b4cd"), new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") },
                    { 12, new DateTime(2020, 11, 18, 10, 30, 15, 117, DateTimeKind.Utc).AddTicks(9886), null, false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("71c88aa4-b6b6-45e8-9ea1-ba1912c1a845") }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PhotoId", "UserId", "VideoId", "Visibility" },
                values: new object[,]
                {
                    { 20, "Really funny video :)", new DateTime(2020, 11, 18, 10, 30, 15, 119, DateTimeKind.Utc).AddTicks(9122), null, false, null, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), 1, 0 },
                    { 1, "Does anyone know any great restaurants near by?", new DateTime(2020, 11, 18, 10, 30, 15, 119, DateTimeKind.Utc).AddTicks(5297), null, false, null, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), null, 0 },
                    { 10, "My new profile photo:", new DateTime(2020, 11, 18, 10, 30, 15, 119, DateTimeKind.Utc).AddTicks(8189), null, false, null, 1, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), null, 0 }
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IconUrl", "IsDeleted", "ModifiedOn", "Name", "UserId", "UserLink" },
                values: new object[] { 1, new DateTime(2020, 11, 18, 10, 30, 15, 120, DateTimeKind.Utc).AddTicks(9511), null, "", false, null, "Instagram", new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), "https://www.instagram.com/magisnikolova" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 1, "This is Amazing!", new DateTime(2020, 11, 18, 10, 30, 15, 118, DateTimeKind.Utc).AddTicks(4555), null, false, null, 1, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 2, "This is Awful!", new DateTime(2020, 11, 18, 10, 30, 15, 118, DateTimeKind.Utc).AddTicks(6787), null, false, null, 20, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 1, new DateTime(2020, 11, 18, 10, 30, 15, 120, DateTimeKind.Utc).AddTicks(5921), null, false, null, 1, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") });

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
