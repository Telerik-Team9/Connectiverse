using System;

namespace SocialNetwork.Services.DTOs
{
    public class FriendDTO
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public Guid UserId { get; set; }
        public string UserDisplayName { get; set; }
        public string UserProfilePictureUrl { get; set; }
        public string UserEducation { get; set; }

        public Guid UserFriendId { get; set; }
        public string UserFriendDisplayName { get; set; }
        public string UserFriendProfilePictureUrl { get; set; }
        public string UserFriendEducation { get; set; }
    }
}
