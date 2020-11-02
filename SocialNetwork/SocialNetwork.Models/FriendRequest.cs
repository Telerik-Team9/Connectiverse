using System;

namespace SocialNetwork.Models
{
    public class FriendRequest
    {
        public int Id { get; set; }

        public Guid SenderId { get; set; }
        public User Sender { get; set; }

        public Guid ReceiverId { get; set; }
        public User Receiver { get; set; }
    }
}
