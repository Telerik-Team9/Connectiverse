using Microsoft.AspNetCore.Identity;
using SocialNetwork.Models.Contracts;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Models
{
    public class User : IdentityUser<Guid>, IEntity
    {
        public string DisplayName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string CoverPictureUrl { get; set; }
        public string Education { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<User> Friends { get; set; } = new HashSet<User>();
        public ICollection<User> FriendRequests { get; set; } = new HashSet<User>();
        public ICollection<TextPost> TextPosts { get; set; } = new HashSet<TextPost>();
        public ICollection<ImagePost> Images { get; set; } = new HashSet<ImagePost>();
        public ICollection<VideoPost> Videos { get; set; } = new HashSet<VideoPost>();
        public ICollection<SocialMedia> SocialMedias { get; set; } = new HashSet<SocialMedia>();
    }
}
