namespace SocialNetwork.Web.Models
{
    public class HomeIndexViewModel
    {
        public HomeIndexViewModel((int usersCount, int connectionsCount, int postsCount, int commentsCount) statistics)
        {
            this.usersCount = statistics.usersCount;
            this.connectionsCount = statistics.connectionsCount;
            this.postsCount = statistics.postsCount;
            this.commentsCount = statistics.commentsCount;
        }

        public int usersCount { get; set; }
        public int connectionsCount { get; set; }
        public int postsCount { get; set; }
        public int commentsCount { get; set; }
    }
}
