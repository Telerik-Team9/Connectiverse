using SocialNetwork.Models.Common.Enums;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Services.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Visibility Visibility { get; set; }
        public string ImageUrl { get; set; }

        public bool IsLiked { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }

        public Guid UserId { get; set; }
        public string UserDisplayName { get; set; }
        public string UserProfilePictureUrl { get; set; }

        public int? PhotoId { get; set; }
        public string PhotoUrl { get; set; }

        public int? VideoId { get; set; }
        public string VideoUrl { get; set; }

        public ICollection<LikeDTO> Likes { get; set; } = new HashSet<LikeDTO>();
        public ICollection<CommentDTO> Comments { get; set; } = new HashSet<CommentDTO>();
    }
}
