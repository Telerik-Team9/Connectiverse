using System;
using System.Collections.Generic;

namespace SocialNetwork.Services.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Education { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsFriendshipRequested { get; set; }
        public bool IsFriend { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int? TownId { get; set; }
        public TownDTO Town { get; set; }
        public string PhoneNumber { get; set; }

        public int? ProfilePictureId { get; set; }
        public string ProfilePictureUrl { get; set; }
        public int? CoverPictureId { get; set; }
        public string CoverPictureUrl { get; set; }

        public ICollection<PostDTO> Posts { get; set; } = new HashSet<PostDTO>();
        public ICollection<FriendDTO> Friends { get; set; } = new HashSet<FriendDTO>();
        public ICollection<FriendRequestDTO> FriendRequests { get; set; }
        public ICollection<SocialMediaDTO> SocialMedias { get; set; }
        public ICollection<LikeDTO> Likes { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }
    }
}
