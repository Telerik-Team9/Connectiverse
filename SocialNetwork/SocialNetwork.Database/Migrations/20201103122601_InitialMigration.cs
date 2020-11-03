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
                    ProfilePictureUrl = table.Column<string>(maxLength: 300, nullable: true),
                    CoverPictureUrl = table.Column<string>(maxLength: 300, nullable: true),
                    Education = table.Column<string>(maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    TownId = table.Column<int>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
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
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
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
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(maxLength: 500, nullable: true),
                    Visibility = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 300, nullable: true),
                    VideoUrl = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post_AspNetUsers_UserId1",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Post_AspNetUsers_UserId2",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                        name: "FK_Comments_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Likes_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("943b692d-330e-405d-a019-c3d728442143"), "0815cc56-3a0b-49bb-a011-ee2cdc5508f0", "Admin", "ADMIN" },
                    { new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"), "875dcb2c-c6f9-4eef-9225-04fd51cc7b31", "User", "USER" }
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CoverPictureUrl", "CreatedOn", "DateOfBirth", "DeletedOn", "DisplayName", "Education", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "RoleId", "SecurityStamp", "TownId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), 0, "876e2ff0-6b83-4bf7-933f-897934d3e0b1", null, new DateTime(2020, 11, 3, 12, 26, 0, 343, DateTimeKind.Utc).AddTicks(4563), null, null, null, null, "magi@mail.com", false, false, false, null, null, "MAGI@MAIL.COM", "MAGI@MAIL.COM", "AQAAAAEAACcQAAAAELFrfRb2uNphSG1sRag2GY05i3DNrFGrtqXesVFG/NPncG6a901q+8vS/84fe8BlYQ==", null, false, null, new Guid("943b692d-330e-405d-a019-c3d728442143"), "8faedaf1-476f-4683-b6d4-deb7a6ee0ff5", null, false, "magi@mail.com" },
                    { new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), 0, "d362cc11-c9c3-4b21-81cb-b66f35314427", null, new DateTime(2020, 11, 3, 12, 26, 0, 344, DateTimeKind.Utc).AddTicks(516), null, null, null, null, "ali@mail.com", false, false, false, null, null, "ALI@MAIL.COM", "ALI@MAIL.COM", "AQAAAAEAACcQAAAAEAMHI2fai81NoKgQCPFNkEZDMQh8BOvAg5IZJCdMZ8B3O5s7onwcfkpN4TErPO2ZMQ==", null, false, null, new Guid("943b692d-330e-405d-a019-c3d728442143"), "94240b92-641e-423b-bfe4-b0120493c3fe", null, false, "ali@mail.com" },
                    { new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), 0, "9fd116d6-4b02-4aae-8637-39bdbcc661b8", null, new DateTime(2020, 11, 3, 12, 26, 0, 344, DateTimeKind.Utc).AddTicks(568), null, null, null, null, "telerik@mail.com", false, false, false, null, null, "TELERIK@MAIL.COM", "TELERIK@MAIL.COM", "AQAAAAEAACcQAAAAEE5ly95Y1EtQqcdrl/n8dRJ3GTCHoC0mSXohXiGQc7gy8YeX6QzMCIf7rgLHAGHcvQ==", null, false, null, new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"), "a510333f-90a9-427d-8e31-ab34e832f5dc", null, false, "telerik@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 1, 1, "Sofia" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), new Guid("943b692d-330e-405d-a019-c3d728442143") },
                    { new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("943b692d-330e-405d-a019-c3d728442143") },
                    { new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff") }
                });

            migrationBuilder.InsertData(
                table: "FriendRequests",
                columns: new[] { "Id", "ReceiverId", "SenderId" },
                values: new object[] { 1, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") });

            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "UserFriendId", "UserId" },
                values: new object[] { 1, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270") });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "Discriminator", "IsDeleted", "ModifiedOn", "UserId", "Visibility", "ImageUrl" },
                values: new object[] { 10, "A photo of one of my favourite things:", new DateTime(2020, 11, 3, 12, 26, 0, 381, DateTimeKind.Utc).AddTicks(7828), null, "ImagePost", false, null, new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), 0, "" });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "Discriminator", "IsDeleted", "ModifiedOn", "UserId", "Visibility" },
                values: new object[] { 1, "Does anyone know any great restaurants near by?", new DateTime(2020, 11, 3, 12, 26, 0, 381, DateTimeKind.Utc).AddTicks(4261), null, "TextPost", false, null, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"), 0 });

            migrationBuilder.InsertData(
                table: "Post",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "Discriminator", "IsDeleted", "ModifiedOn", "UserId", "Visibility", "VideoUrl" },
                values: new object[] { 20, "Really funny video :)", new DateTime(2020, 11, 3, 12, 26, 0, 382, DateTimeKind.Utc).AddTicks(28), null, "VideoPost", false, null, new Guid("3753d26b-5a35-491f-ae82-5238d243b619"), 0, "" });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IconUrl", "IsDeleted", "ModifiedOn", "Name", "UserId", "UserLink" },
                values: new object[] { 1, new DateTime(2020, 11, 3, 12, 26, 0, 382, DateTimeKind.Utc).AddTicks(4465), null, "", false, null, "Instagram", new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"), "https://www.instagram.com/magisnikolova" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 1, "This is Amazing!", new DateTime(2020, 11, 3, 12, 26, 0, 379, DateTimeKind.Utc).AddTicks(5417), null, false, null, 1, new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5") });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "PostId", "UserId" },
                values: new object[] { 1, new DateTime(2020, 11, 3, 12, 26, 0, 382, DateTimeKind.Utc).AddTicks(1790), null, false, null, 1, new Guid("3753d26b-5a35-491f-ae82-5238d243b619") });

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
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

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
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId1",
                table: "Post",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId2",
                table: "Post",
                column: "UserId");

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
                name: "Post");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
