using Microsoft.AspNetCore.Identity;
using SocialNetwork.Models.Contracts;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Models
{
    public class User : IdentityUser<Guid>, IEntity
    {
        public string DisplayName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Education { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        public int? TownId { get; set; }
        public Town Town { get; set; }

        public int? ProfilePictureId { get; set; }
        public string ProfilePictureUrl { get; set; }
        public int? CoverPictureId { get; set; }
        public string CoverPictureUrl { get; set; }

        public ICollection<Friend> Friends { get; set; } = new HashSet<Friend>();
        public ICollection<Friend> FriendsOf { get; set; } = new HashSet<Friend>();
        public ICollection<FriendRequest> FriendRequests { get; set; } = new HashSet<FriendRequest>();
        public ICollection<FriendRequest> FriendRequestsOf { get; set; } = new HashSet<FriendRequest>();
        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();
        public ICollection<SocialMedia> SocialMedias { get; set; } = new HashSet<SocialMedia>();
        public ICollection<Like> Likes { get; set; } = new HashSet<Like>();
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
