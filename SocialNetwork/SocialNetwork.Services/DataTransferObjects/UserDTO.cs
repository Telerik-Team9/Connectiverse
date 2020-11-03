using System;
using System.Collections.Generic;

namespace SocialNetwork.Services.DataTransferObjects
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string CoverPictureUrl { get; set; }
        public string Education { get; set; }
        public DateTime CreatedOn { get; set; }

        public int? TownId { get; set; }
        public string TownName { get; set; }

        public Guid RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<FriendDTO> Friends { get; set; } = new HashSet<FriendDTO>();
        //public ICollection<FriendDTO> FriendsOf { get; set; } = new HashSet<FriendDTO>();
        public ICollection<FriendRequestDTO> FriendRequests { get; set; } = new HashSet<FriendRequestDTO>();
        //public ICollection<FriendRequestDTO> FriendRequestsOf { get; set; } = new HashSet<FriendRequestDTO>();
        public ICollection<TextPostDTO> TextPosts { get; set; } = new HashSet<TextPostDTO>();
        public ICollection<ImagePostDTO> Images { get; set; } = new HashSet<ImagePostDTO>();
        public ICollection<VideoPostDTO> Videos { get; set; } = new HashSet<VideoPostDTO>();
        public ICollection<SocialMediaDTO> SocialMedias { get; set; } = new HashSet<SocialMediaDTO>();
        public ICollection<LikeDTO> Likes { get; set; } = new HashSet<LikeDTO>();
        public ICollection<CommentDTO> Comments { get; set; } = new HashSet<CommentDTO>();
    }
}
