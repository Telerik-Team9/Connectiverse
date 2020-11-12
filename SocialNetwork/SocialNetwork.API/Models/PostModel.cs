using SocialNetwork.Models.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.API.Models
{
    public class PostModel
    {
        [Required]
        public string Content { get; set; }
        public Visibility Visibility { get; set; } = Visibility.Public;

        public Guid UserId { get; set; }
        [Required]
        public string UserDisplayName { get; set; }
        public string PhotoModelUrl { get; set; }
        public string VideoModelUrl { get; set; }

    }
}
