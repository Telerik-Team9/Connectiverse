using SocialNetwork.Models.Common.Enums;

namespace SocialNetwork.API.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Visibility Visibility { get; set; } = Visibility.Public;

        //public Guid UserId { get; set; }
        public string UserDisplayName { get; set; }
        public string PhotoModelUrl { get; set; }
        public string VideoModelUrl { get; set; }
    }
}
