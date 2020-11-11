using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SocialNetwork.Models.Common.Enums;

namespace SocialNetwork.Web.Models
{
    public class PostViewModel
    {
        [Required]
        public string Content { get; set; }
        public Visibility Visibility { get; set; } = Visibility.Public;

        public Guid UserId { get; set; }
        [Required]
        public string UserDisplayName { get; set; }
        public string UserProfilePictureUrl { get; set; }

        public string PhotoModelUrl { get; set; }
        public string VideoModelUrl { get; set; }

         public ICollection<LikeViewModel> Likes { get; set; } = new HashSet<LikeViewModel>();
        // public ICollection<CommentModel> Comments { get; set; } = new HashSet<CommentModel>();
    }
}
