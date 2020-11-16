namespace SocialNetwork.Web.Models
{
    public class PostCommentViewModel
    {
        public int PostId { get; set; }
        public PostViewModel Post { get; set; }
        public CommentViewModel NewComment { get; set; }
    }
}
