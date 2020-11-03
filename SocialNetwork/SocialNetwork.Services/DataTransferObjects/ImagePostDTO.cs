using SocialNetwork.Models.Common.Enums;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Services.DataTransferObjects
{
    public class ImagePostDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Visibility Visibility { get; set; }
        public string ImageUrl { get; set; }

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserProfilePictureUrl { get; set; }

        public ICollection<LikeDTO> Likes { get; set; } = new HashSet<LikeDTO>();
        public ICollection<CommentDTO> Comments { get; set; } = new HashSet<CommentDTO>();
    }
}
