using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Models;

namespace SocialNetwork.Database.DataConfigurations
{
    internal class VideoConfig : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
        /*    builder.HasKey(v => v.Id);*/

            builder.Property(v => v.Url)
                .HasMaxLength(300);
            // TODO: Make videoUrl required
        }
    }
}
