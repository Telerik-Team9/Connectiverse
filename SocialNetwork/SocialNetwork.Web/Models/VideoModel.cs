using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Web.Models
{
    public class VideoModel
    {
        [Required]
        public string Url { get; set; }
    }
}
