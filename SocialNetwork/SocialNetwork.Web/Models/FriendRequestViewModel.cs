using System;

namespace SocialNetwork.Web.Models
{
    public class FriendRequestViewModel
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
