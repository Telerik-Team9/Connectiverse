using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Models;

namespace SocialNetwork.Database.DataConfigurations
{
    internal class TownConfig : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.Property(t => t.Name)
                .HasMaxLength(50);
        }
    }
}
