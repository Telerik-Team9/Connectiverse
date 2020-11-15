using System;

namespace SocialNetwork.Web.Models
{
    public class UserProfileViewModel
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string Education { get; set; }
        public string Email { get; set; }
        public bool IsFriendshipRequested { get; set; }
        public bool IsFriend { get; set; }
        public int? ProfilePictureId { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
