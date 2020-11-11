using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.API.Models
{
    public class VideoModel
    {
        [Required]
        public string Url { get; set; }
    }
}
