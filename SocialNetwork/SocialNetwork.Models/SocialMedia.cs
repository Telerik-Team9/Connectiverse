using SocialNetwork.Models.Abstracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class SocialMedia : Entity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string UserLink { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
