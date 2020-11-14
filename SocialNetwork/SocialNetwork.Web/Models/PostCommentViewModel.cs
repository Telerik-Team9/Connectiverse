using System.Collections.Generic;

namespace SocialNetwork.Web.Models
{
    public class PostCommentViewModel
    {
        public PostViewModel Post { get; set; }
        public CommentViewModel NewComment { get; set; }
    }
}
