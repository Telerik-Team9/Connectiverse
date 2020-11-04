using System;

namespace SocialNetwork.Services.DTOs
{
    public class FriendRequestDTO
    {
        public int Id { get; set; }

        public Guid SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderProfilePictureUrl { get; set; }

        public Guid ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverProfilePictureUrl { get; set; }
    }
}
