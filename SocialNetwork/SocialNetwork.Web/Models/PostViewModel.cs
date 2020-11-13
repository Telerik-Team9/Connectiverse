using Microsoft.AspNetCore.Http;
using SocialNetwork.Models.Common.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Web.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public Visibility Visibility { get; set; } = Visibility.Public;

        //public Guid UserId { get; set; }
        //[Required]
        public string UserDisplayName { get; set; }
        //public string UserProfilePictureUrl { get; set; }

        public string PhotoUrl { get; set; }
        // public string VideoModelUrl { get; set; }
        public IFormFile file { get; set; }
        public ICollection<LikeViewModel> Likes { get; set; } = new HashSet<LikeViewModel>();
        public ICollection<CommentViewModel> Comments { get; set; } = new HashSet<CommentViewModel>();
    }
}
