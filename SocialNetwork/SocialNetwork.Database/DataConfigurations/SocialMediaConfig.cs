﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Models;

namespace SocialNetwork.Database.DataConfigurations
{
    internal class SocialMediaConfig : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.Property(s => s.Name)
                .HasMaxLength(20);

            builder.Property(s => s.IconUrl)
                .HasMaxLength(300);

            builder.Property(s => s.IconUrl)
                .HasMaxLength(100);
        }
    }
}
