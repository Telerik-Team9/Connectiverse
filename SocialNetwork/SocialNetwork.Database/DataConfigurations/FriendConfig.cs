using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Models;

namespace SocialNetwork.Database.DataConfigurations
{
    internal class FriendConfig : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.HasOne(f => f.User)
                .WithMany(u => u.Friends)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f => f.UserFriend)
                .WithMany(u => u.FriendsOf)
                .HasForeignKey(f => f.UserFriendId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}