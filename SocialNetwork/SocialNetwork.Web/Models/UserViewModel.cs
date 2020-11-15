using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Education { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsFriendshipRequested { get; set; }
        public bool IsFriend { get; set; }
        public string Token { get; set; }
        public int? ProfilePictureId { get; set; }
        public string ProfilePictureUrl { get; set; }
        public int? CoverPictureId { get; set; }
        public string CoverPictureUrl { get; set; }
        public ICollection<PostViewModel> Posts { get; set; }// = new HashSet<PostDTO>();
        public ICollection<FriendViewModel> Friends { get; set; }
        /*public ICollection<FriendDTO> FriendsOf { get; set; } = new HashSet<FriendDTO>();*/
        public ICollection<FriendRequestViewModel> FriendRequests { get; set; } 
        //public ICollection<FriendRequestDTO> FriendRequestsOf { get; set; } = new HashSet<FriendRequestDTO>();
        public ICollection<SocialMediaViewModel> SocialMedias { get; set; }
        public ICollection<LikeViewModel> Likes { get; set; } 
        public ICollection<CommentViewModel> Comments { get; set; } 

    }
}
