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
                .IsRequired(false);

            builder.Property(u => u.Education)
                .HasMaxLength(50);

/*            builder.HasOne(u => u.ProfilePicture)
                .WithOne(p => p.User)
                .HasForeignKey<User>(u => u.ProfilePictureId);

            builder.HasOne(u => u.CoverPicture)
                .WithOne(p => p.User)
                .HasForeignKey<User>(u => u.ProfilePictureId);*/

/*            builder.HasOne(u => u.Town)
                .WithMany(t => t.Users)
                .HasForeignKey(u => u.TownId);

            builder.HasOne(u => u.Role)
                .WithMany(a => a.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.NoAction);*/
        }
    }
}
