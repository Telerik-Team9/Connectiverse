using SocialNetwork.Models.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Photo : Entity
    {
        [Key]
        public int Id { get; set; }
        // TODO: how to save image in sql database (byte[])
        public string Url { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
