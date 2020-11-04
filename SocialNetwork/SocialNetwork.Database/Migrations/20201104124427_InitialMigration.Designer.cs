﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialNetwork.Database;

namespace SocialNetwork.Database.Migrations
{
    [DbContext(typeof(SocialNetworkDBContext))]
    [Migration("20201104124427_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            CreatedOn = new DateTime(2020, 11, 4, 12, 44, 26, 165, DateTimeKind.Utc).AddTicks(1464),
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
                            CreatedOn = new DateTime(2020, 11, 4, 12, 44, 26, 168, DateTimeKind.Utc).AddTicks(2654),
                            IsDeleted = false,
                            PostId = 1,
                            UserId = new Guid("3753d26b-5a35-491f-ae82-5238d243b619")
                        });
                });

            modelBuilder.Entity("SocialNetwork.Models.Photo", b =>
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

                    b.Property<byte[]>("PhotoAsBytes")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Photos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2020, 11, 4, 12, 44, 26, 167, DateTimeKind.Utc).AddTicks(6569),
                            IsDeleted = false,
                            PostId = 10
                        });
                });

            modelBuilder.Entity("SocialNetwork.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PhotoId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("VideoId")
                        .HasColumnType("int");

                    b.Property<int>("Visibility")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId")
                        .IsUnique()
                        .HasFilter("[PhotoId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.HasIndex("VideoId")
                        .IsUnique()
                        .HasFilter("[VideoId] IS NOT NULL");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Does anyone know any great restaurants near by?",
                            CreatedOn = new DateTime(2020, 11, 4, 12, 44, 26, 167, DateTimeKind.Utc).AddTicks(43),
                            IsDeleted = false,
                            UserId = new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                            Visibility = 0
                        },
                        new
                        {
                            Id = 10,
                            Content = "A photo of one of my favourite things:",
                            CreatedOn = new DateTime(2020, 11, 4, 12, 44, 26, 167, DateTimeKind.Utc).AddTicks(4005),
                            IsDeleted = false,
                            PhotoId = 1,
                            UserId = new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"),
                            Visibility = 0
                        },
                        new
                        {
                            Id = 20,
                            Content = "Really funny video :)",
                            CreatedOn = new DateTime(2020, 11, 4, 12, 44, 26, 167, DateTimeKind.Utc).AddTicks(4713),
                            IsDeleted = false,
                            UserId = new Guid("3753d26b-5a35-491f-ae82-5238d243b619"),
                            VideoId = 1,
                            Visibility = 0
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
                            ConcurrencyStamp = "33f5ef65-bb6e-4dc5-a2b1-a03e19bd483c",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("07cc27fe-9ca9-4953-9a79-2c79c1e32aff"),
                            ConcurrencyStamp = "63e6a682-49f2-4322-ae94-c2b741f30474",
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
                            CreatedOn = new DateTime(2020, 11, 4, 12, 44, 26, 168, DateTimeKind.Utc).AddTicks(5696),
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

                    b.Property<int?>("CoverPictureId")
                        .HasColumnType("int");

                    b.Property<string>("CoverPictureUrl")
                        .HasColumnType("nvarchar(max)");

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

                    b.Property<int?>("ProfilePictureId")
                        .HasColumnType("int");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("nvarchar(max)");

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

                    b.HasIndex("TownId");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1d6e3bae-451f-4c01-8b43-cecc2d404270"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9786bc6a-b8c7-421e-9a3e-17d054176666",
                            CreatedOn = new DateTime(2020, 11, 4, 12, 44, 26, 117, DateTimeKind.Utc).AddTicks(1452),
                            DateOfBirth = new DateTime(1997, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DisplayName = "Magi Nikolova",
                            Education = "Sofia University",
                            Email = "magi@mail.com",
                            EmailConfirmed = false,
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "MAGI@MAIL.COM",
                            NormalizedUserName = "MAGI@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEC3j1kcjoC/3HYYI/+gxqaA6vIXp67Go5aLr6SNnEz/3ghH97EF1y02u96D5xiPRSA==",
                            PhoneNumberConfirmed = false,
                            ProfilePictureId = 1,
                            SecurityStamp = "8c0a91c4-625f-4112-bbcf-c8718030f7be",
                            TownId = 1,
                            TwoFactorEnabled = false,
                            UserName = "magi@mail.com"
                        },
                        new
                        {
                            Id = new Guid("3be6b2ff-021d-4da5-8639-31973b594cc5"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "780492ea-fc98-4567-8d4f-a24041651ef9",
                            CreatedOn = new DateTime(2020, 11, 4, 12, 44, 26, 118, DateTimeKind.Utc).AddTicks(6393),
                            DateOfBirth = new DateTime(1999, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DisplayName = "Ali Marekov",
                            Education = "Technical University",
                            Email = "ali@mail.com",
                            EmailConfirmed = false,
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ALI@MAIL.COM",
                            NormalizedUserName = "ALI@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEGEZYACzMqYQr64ZIi72xDnrwcKKeGxS+sYygR+surfrnhgYSue0OnekG7m+1YHD2w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "640e81d9-5b31-4cf3-9f70-b209e860ee5c",
                            TownId = 1,
                            TwoFactorEnabled = false,
                            UserName = "ali@mail.com"
                        },
                        new
                        {
                            Id = new Guid("3753d26b-5a35-491f-ae82-5238d243b619"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b549e5ef-6858-4770-8a0a-4cbf1382a68e",
                            CreatedOn = new DateTime(2020, 11, 4, 12, 44, 26, 118, DateTimeKind.Utc).AddTicks(6539),
                            DateOfBirth = new DateTime(2010, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DisplayName = "Telerik Academy",
                            Education = "",
                            Email = "telerik@mail.com",
                            EmailConfirmed = false,
                            IsDeleted = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "TELERIK@MAIL.COM",
                            NormalizedUserName = "TELERIK@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEOn3QGU+L4Ck+dDPyh3QsV3+s2IIQ3j9eclGLwAbyiaU9DQc7Pm0y5BlsIqIzuIusQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "66108ec2-a45d-48fc-b279-c17c4cad95bd",
                            TownId = 1,
                            TwoFactorEnabled = false,
                            UserName = "telerik@mail.com"
                        });
                });

            modelBuilder.Entity("SocialNetwork.Models.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("videoUrl")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("Videos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PostId = 20
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
                    b.HasOne("SocialNetwork.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
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
                    b.HasOne("SocialNetwork.Models.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Models.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("SocialNetwork.Models.Post", b =>
                {
                    b.HasOne("SocialNetwork.Models.Photo", "Photo")
                        .WithOne("Post")
                        .HasForeignKey("SocialNetwork.Models.Post", "PhotoId");

                    b.HasOne("SocialNetwork.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Models.Video", "Video")
                        .WithOne("Post")
                        .HasForeignKey("SocialNetwork.Models.Post", "VideoId");
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
                    b.HasOne("SocialNetwork.Models.Town", "Town")
                        .WithMany("Users")
                        .HasForeignKey("TownId");
                });
#pragma warning restore 612, 618
        }
    }
}