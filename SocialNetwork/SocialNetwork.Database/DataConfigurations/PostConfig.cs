using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Models;

namespace SocialNetwork.Database.DataConfigurations
{
    internal class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            /*builder.HasKey(p => p.Id);

            builder.HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId);*/

            builder.HasOne(p => p.Photo)
                .WithOne(ph => ph.Post)
                .HasForeignKey<Post>(p => p.PhotoId);

            builder.HasOne(p => p.Video)
                .WithOne(v => v.Post)
                .HasForeignKey<Post>(p => p.VideoId);
        }
    }
}
