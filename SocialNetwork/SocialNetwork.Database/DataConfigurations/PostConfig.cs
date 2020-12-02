using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Models;

namespace SocialNetwork.Database.DataConfigurations
{
    internal class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasOne(p => p.Photo)
                .WithOne(ph => ph.Post)
                .HasForeignKey<Post>(p => p.PhotoId);

            builder.HasOne(p => p.Video)
                .WithOne(v => v.Post)
                .HasForeignKey<Post>(p => p.VideoId);
        }
    }
}
