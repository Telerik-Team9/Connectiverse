using System;

namespace SocialNetwork.Services.DTOs
{
    public class FriendRequestDTO
    {
        public int Id { get; set; }

        public Guid SenderId { get; set; }
        public string SenderDisplayName { get; set; }
        public string SenderProfilePictureUrl { get; set; }

        public Guid ReceiverId { get; set; }
        public string ReceiverDisplayName { get; set; }
        public string ReceiverProfilePictureUrl { get; set; }
    }
}
