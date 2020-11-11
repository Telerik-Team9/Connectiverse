using System;

namespace SocialNetwork.Services.DTOs
{
    public class LikeDTO
    {
        public int Id { get; set; }

        public int PostId { get; set; }
        // public Post Post { get; set; }

        public Guid UserId { get; set; }
        public string UserDisplayName { get; set; }
    }
}
