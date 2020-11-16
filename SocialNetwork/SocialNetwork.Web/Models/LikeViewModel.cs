using System;

namespace SocialNetwork.Web.Models
{
    public class LikeViewModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Guid UserId { get; set; }
        public string UserDisplayName { get; set; }
    }
}
