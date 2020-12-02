using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Models;

namespace SocialNetwork.Database.DataConfigurations
{
    internal class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(50);

            builder.Property(c => c.ISO)
                .HasMaxLength(3);
        }
    }
}
