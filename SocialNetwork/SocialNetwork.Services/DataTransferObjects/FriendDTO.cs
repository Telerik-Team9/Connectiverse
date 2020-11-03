using System;

namespace SocialNetwork.Services.DataTransferObjects
{
    public class FriendDTO
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserProfilePictureUrl { get; set; }

        public Guid UserFriendId { get; set; }
        public string UserFriendName { get; set; }
        public string UserFriendProfilePictureUrl { get; set; }
    }
}
