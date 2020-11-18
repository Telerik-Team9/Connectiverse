using System;

namespace SocialNetwork.Web.Models
{
    public class SocialMediaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string UserLink { get; set; }

        public Guid UserId { get; set; }
    }
}
