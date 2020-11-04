using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Video
    {
        [Key]
        public int Id { get; set; }
        public string videoUrl { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
