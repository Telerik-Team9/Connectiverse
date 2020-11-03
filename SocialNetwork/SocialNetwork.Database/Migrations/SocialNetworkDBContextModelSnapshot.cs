﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialNetwork.Database;

namespace SocialNetwork.Database.Migrations
{
    [DbContext(typeof(SocialNetworkDBContext))]
    partial class SocialNetworkDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"),
                            RoleId = new Guid("943b692d-330e-405d-a019-c3d728442143")
                        },
                        new
                        {
                            UserId = new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                            RoleId = new Guid("943b692d-330e-405d-a019-c3d728442143")
                        },
                        new
                        {
                            UserId = new Guid("3753d26b-5a35-491f-ae82-5238d243b619"),
                            RoleId = new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SocialNetwork.Models.Abstracts.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Visibility")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Post");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Post");
                });

            modelBuilder.Entity("SocialNetwork.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "This is Amazing!",
                            CreatedOn = new DateTime(2020, 11, 3, 12, 26, 0, 379, DateTimeKind.Utc).AddTicks(5417),
                            IsDeleted = false,
                            PostId = 1,
                            UserId = new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5")
                        });
                });

            modelBuilder.Entity("SocialNetwork.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ISO")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ISO = "BG",
                            Name = "Bulgaria"
                        },
                        new
                        {
                            Id = 2,
                            ISO = "BE",
                            Name = "Belgium"
                        },
                        new
                        {
                            Id = 3,
                            ISO = "NL",
                            Name = "Netherlands"
                        },
                        new
                        {
                            Id = 4,
                            ISO = "IE",
                            Name = "Ireland"
                        },
                        new
                        {
                            Id = 5,
                            ISO = "MX",
                            Name = "Mexico"
                        },
                        new
                        {
                            Id = 6,
                            ISO = "UK",
                            Name = "United Kingdom"
                        },
                        new
                        {
                            Id = 7,
                            ISO = "RS",
                            Name = "Serbia"
                        },
                        new
                        {
                            Id = 8,
                            ISO = "DE",
                            Name = "Germany"
                        });
                });

            modelBuilder.Entity("SocialNetwork.Models.Friend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("UserFriendId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserFriendId");

                    b.HasIndex("UserId");

                    b.ToTable("Friends");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserFriendId = new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                            UserId = new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270")
                        });
                });

            modelBuilder.Entity("SocialNetwork.Models.FriendRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("ReceiverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SenderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("FriendRequests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ReceiverId = new Guid("3753d26b-5a35-491f-ae82-5238d243b619"),
                            SenderId = new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270")
                        });
                });

            modelBuilder.Entity("SocialNetwork.Models.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2020, 11, 3, 12, 26, 0, 382, DateTimeKind.Utc).AddTicks(1790),
                            IsDeleted = false,
                            PostId = 1,
                            UserId = new Guid("3753d26b-5a35-491f-ae82-5238d243b619")
                        });
                });

            modelBuilder.Entity("SocialNetwork.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("943b692d-330e-405d-a019-c3d728442143"),
                            ConcurrencyStamp = "0815cc56-3a0b-49bb-a011-ee2cdc5508f0",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"),
                            ConcurrencyStamp = "875dcb2c-c6f9-4eef-9225-04fd51cc7b31",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("SocialNetwork.Models.SocialMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("IconUrl")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SocialMedias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2020, 11, 3, 12, 26, 0, 382, DateTimeKind.Utc).AddTicks(4465),
                            IconUrl = "",
                            IsDeleted = false,
                            Name = "Instagram",
                            UserId = new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"),
                            UserLink = "https://www.instagram.com/magisnikolova"
                        });
                });

            modelBuilder.Entity("SocialNetwork.Models.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Towns");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Sofia"
                        });
                });

            modelBuilder.Entity("SocialNetwork.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoverPictureUrl")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TownId")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.HasIndex("TownId");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "876e2ff0-6b83-4bf7-933f-897934d3e0b1",
                            CreatedOn = new DateTime(2020, 11, 3, 12, 26, 0, 343, DateTimeKind.Utc).AddTicks(4563),
                            Email = "magi@mail.com",
                            EmailConfirmed = false,
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "MAGI@MAIL.COM",
                            NormalizedUserName = "MAGI@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAELFrfRb2uNphSG1sRag2GY05i3DNrFGrtqXesVFG/NPncG6a901q+8vS/84fe8BlYQ==",
                            PhoneNumberConfirmed = false,
                            RoleId = new Guid("943b692d-330e-405d-a019-c3d728442143"),
                            SecurityStamp = "8faedaf1-476f-4683-b6d4-deb7a6ee0ff5",
                            TwoFactorEnabled = false,
                            UserName = "magi@mail.com"
                        },
                        new
                        {
                            Id = new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d362cc11-c9c3-4b21-81cb-b66f35314427",
                            CreatedOn = new DateTime(2020, 11, 3, 12, 26, 0, 344, DateTimeKind.Utc).AddTicks(516),
                            Email = "ali@mail.com",
                            EmailConfirmed = false,
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ALI@MAIL.COM",
                            NormalizedUserName = "ALI@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEAMHI2fai81NoKgQCPFNkEZDMQh8BOvAg5IZJCdMZ8B3O5s7onwcfkpN4TErPO2ZMQ==",
                            PhoneNumberConfirmed = false,
                            RoleId = new Guid("943b692d-330e-405d-a019-c3d728442143"),
                            SecurityStamp = "94240b92-641e-423b-bfe4-b0120493c3fe",
                            TwoFactorEnabled = false,
                            UserName = "ali@mail.com"
                        },
                        new
                        {
                            Id = new Guid("3753d26b-5a35-491f-ae82-5238d243b619"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9fd116d6-4b02-4aae-8637-39bdbcc661b8",
                            CreatedOn = new DateTime(2020, 11, 3, 12, 26, 0, 344, DateTimeKind.Utc).AddTicks(568),
                            Email = "telerik@mail.com",
                            EmailConfirmed = false,
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "TELERIK@MAIL.COM",
                            NormalizedUserName = "TELERIK@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEE5ly95Y1EtQqcdrl/n8dRJ3GTCHoC0mSXohXiGQc7gy8YeX6QzMCIf7rgLHAGHcvQ==",
                            PhoneNumberConfirmed = false,
                            RoleId = new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"),
                            SecurityStamp = "a510333f-90a9-427d-8e31-ab34e832f5dc",
                            TwoFactorEnabled = false,
                            UserName = "telerik@mail.com"
                        });
                });

            modelBuilder.Entity("SocialNetwork.Models.ImagePost", b =>
                {
                    b.HasBaseType("SocialNetwork.Models.Abstracts.Post");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasIndex("UserId");

                    b.HasDiscriminator().HasValue("ImagePost");

                    b.HasData(
                        new
                        {
                            Id = 10,
                            Content = "A photo of one of my favourite things:",
                            CreatedOn = new DateTime(2020, 11, 3, 12, 26, 0, 381, DateTimeKind.Utc).AddTicks(7828),
                            IsDeleted = false,
                            UserId = new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"),
                            Visibility = 0,
                            ImageUrl = ""
                        });
                });

            modelBuilder.Entity("SocialNetwork.Models.TextPost", b =>
                {
                    b.HasBaseType("SocialNetwork.Models.Abstracts.Post");

                    b.HasIndex("UserId")
                        .HasName("IX_Post_UserId1");

                    b.HasDiscriminator().HasValue("TextPost");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Does anyone know any great restaurants near by?",
                            CreatedOn = new DateTime(2020, 11, 3, 12, 26, 0, 381, DateTimeKind.Utc).AddTicks(4261),
                            IsDeleted = false,
                            UserId = new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                            Visibility = 0
                        });
                });

            modelBuilder.Entity("SocialNetwork.Models.VideoPost", b =>
                {
                    b.HasBaseType("SocialNetwork.Models.Abstracts.Post");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasIndex("UserId")
                        .HasName("IX_Post_UserId2");

                    b.HasDiscriminator().HasValue("VideoPost");

                    b.HasData(
                        new
                        {
                            Id = 20,
                            Content = "Really funny video :)",
                            CreatedOn = new DateTime(2020, 11, 3, 12, 26, 0, 382, DateTimeKind.Utc).AddTicks(28),
                            IsDeleted = false,
                            UserId = new Guid("3753d26b-5a35-491f-ae82-5238d243b619"),
                            Visibility = 0,
                            VideoUrl = ""
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("SocialNetwork.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("SocialNetwork.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("SocialNetwork.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("SocialNetwork.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("SocialNetwork.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SocialNetwork.Models.Comment", b =>
                {
                    b.HasOne("SocialNetwork.Models.Abstracts.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SocialNetwork.Models.Friend", b =>
                {
                    b.HasOne("SocialNetwork.Models.User", "UserFriend")
                        .WithMany("FriendsOf")
                        .HasForeignKey("UserFriendId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Models.User", "User")
                        .WithMany("Friends")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("SocialNetwork.Models.FriendRequest", b =>
                {
                    b.HasOne("SocialNetwork.Models.User", "Receiver")
                        .WithMany("FriendRequestsOf")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Models.User", "Sender")
                        .WithMany("FriendRequests")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("SocialNetwork.Models.Like", b =>
                {
                    b.HasOne("SocialNetwork.Models.Abstracts.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Models.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SocialNetwork.Models.SocialMedia", b =>
                {
                    b.HasOne("SocialNetwork.Models.User", "User")
                        .WithMany("SocialMedias")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SocialNetwork.Models.Town", b =>
                {
                    b.HasOne("SocialNetwork.Models.Country", "Country")
                        .WithMany("Towns")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SocialNetwork.Models.User", b =>
                {
                    b.HasOne("SocialNetwork.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Models.Town", "Town")
                        .WithMany("Users")
                        .HasForeignKey("TownId");
                });

            modelBuilder.Entity("SocialNetwork.Models.ImagePost", b =>
                {
                    b.HasOne("SocialNetwork.Models.User", "User")
                        .WithMany("Images")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("SocialNetwork.Models.TextPost", b =>
                {
                    b.HasOne("SocialNetwork.Models.User", "User")
                        .WithMany("TextPosts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Post_AspNetUsers_UserId1")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("SocialNetwork.Models.VideoPost", b =>
                {
                    b.HasOne("SocialNetwork.Models.User", "User")
                        .WithMany("Videos")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Post_AspNetUsers_UserId2")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
