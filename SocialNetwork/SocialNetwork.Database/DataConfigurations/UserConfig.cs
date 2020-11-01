﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Models;

namespace SocialNetwork.Database.DataConfigurations
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.DisplayName)
                .HasMaxLength(30);

            builder.Property(u => u.DateOfBirth)
                .IsRequired(true);

            builder.Property(u => u.ProfilePictureUrl)
                .HasMaxLength(300);

            builder.Property(u => u.CoverPictureUrl)
                .HasMaxLength(300);

            builder.Property(u => u.Education)
                .HasMaxLength(50);

            builder.Property(u => u.ProfilePictureUrl)
                .HasMaxLength(300);

            builder.HasOne(u => u.Address)
                .WithMany(a => a.Users)
                .HasForeignKey(u => u.AddressId);

            builder.HasOne(u => u.Role)
                .WithMany(a => a.Users)
                .HasForeignKey(u => u.RoleId);

            builder.HasMany(u => u.Friends);

            builder.HasMany(u => u.FriendRequests);
        }
    }
}
