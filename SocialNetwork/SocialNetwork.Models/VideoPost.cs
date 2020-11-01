using SocialNetwork.Models.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class VideoPost : Post
    {
        public string VideoUrl { get; set; }
    }
}
