using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Web.Models
{
    public class PhotoModel
    {
        [Required]
        public string Url { get; set; }
    }
}
