using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Models;

namespace SocialNetwork.Database.DataConfigurations
{
    internal class ImagePostConfig : IEntityTypeConfiguration<ImagePost>
    {
        public void Configure(EntityTypeBuilder<ImagePost> builder)
        {
            //builder.HasKey(i => i.Id);

            builder.Property(i => i.ImageUrl)
                .HasMaxLength(300);

            // Post:
            builder.Property(i => i.Content)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.HasOne(i => i.User)
                .WithMany(u => u.Images)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            /*
            .IsRequired(true);*/ //TODO
        }
    }
}
