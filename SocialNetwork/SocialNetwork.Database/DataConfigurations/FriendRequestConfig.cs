using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Models;

namespace SocialNetwork.Database.DataConfigurations
{
    internal class FriendRequestConfig : IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> builder)
        {
            builder.HasOne(f => f.Sender)
                .WithMany(u => u.FriendRequests)
                .HasForeignKey(f => f.SenderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(f => f.Receiver)
                .WithMany(u => u.FriendRequestsOf)
                .HasForeignKey(f => f.ReceiverId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
