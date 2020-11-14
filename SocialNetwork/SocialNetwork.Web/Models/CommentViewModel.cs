using System;

namespace SocialNetwork.Web.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public int PostId { get; set; }
        //  public Post Post { get; set; }

        public Guid UserId { get; set; }
        public string UserDisplayName { get; set; }
        public string UserProfilePictureUrl { get; set; }
    }
}
