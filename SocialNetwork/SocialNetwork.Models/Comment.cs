using SocialNetwork.Models.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Comment : Entity
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        //TODO: ADD emoji/sticker

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
