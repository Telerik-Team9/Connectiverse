using System.Collections.Generic;

namespace SocialNetwork.Web.Models
{
    public class AllPostsViewModel
    {
        public ICollection<PostViewModel> Posts { get; set; }
        public CommentViewModel NewComment { get; set; }
    }
}
