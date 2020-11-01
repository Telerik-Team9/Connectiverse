using SocialNetwork.Models.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Like : Entity
    {
        [Key]
        public int Id { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
