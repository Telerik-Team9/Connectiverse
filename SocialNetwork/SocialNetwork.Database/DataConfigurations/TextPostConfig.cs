using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Models;

namespace SocialNetwork.Database.DataConfigurations
{
    internal class TextPostConfig : IEntityTypeConfiguration<TextPost>
    {
        public void Configure(EntityTypeBuilder<TextPost> builder)
        {
            // Post:
            builder.Property(t => t.Content)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.HasOne(t => t.User)
                .WithMany(u => u.TextPosts)
                .HasForeignKey(t => t.UserId);/*
                .IsRequired(true);*/ //TODO
        }
    }
}
