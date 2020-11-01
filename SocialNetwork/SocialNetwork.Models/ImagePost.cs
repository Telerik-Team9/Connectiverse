using SocialNetwork.Models.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class ImagePost : Post
    {
        public string ImageUrl { get; set; }
    }
}
