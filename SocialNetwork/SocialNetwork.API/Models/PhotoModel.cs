using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.API.Models
{
    public class PhotoModel
    {
        [Required]
        public string Url { get; set; }
    }
}
