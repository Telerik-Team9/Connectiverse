using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Models;

namespace SocialNetwork.Database.DataConfigurations
{
    internal class VideoPostConfig : IEntityTypeConfiguration<VideoPost>
    {
        public void Configure(EntityTypeBuilder<VideoPost> builder)
        {
           /* builder.HasKey(v => v.Id);*/

            builder.Property(v => v.VideoUrl)
                .HasMaxLength(300);

            // Post:
            builder.Property(v => v.Content)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.HasOne(v => v.User)
                .WithMany(u => u.Videos)
                .HasForeignKey(v => v.UserId);/*
                .IsRequired(true);*/ //TODO
        }
    }
}
