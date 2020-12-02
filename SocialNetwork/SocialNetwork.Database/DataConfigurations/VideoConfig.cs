using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Models;

namespace SocialNetwork.Database.DataConfigurations
{
    internal class VideoConfig : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.Property(v => v.Url)
                .HasMaxLength(300);
        }
    }
}
