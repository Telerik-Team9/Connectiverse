using System.Collections.Generic;

namespace SocialNetwork.Web.Models
{
    public class SearchViewModel
    {
        public ICollection<UserProfileViewModel> Users { get; set; }
        public ICollection<PostViewModel> Posts { get; set; }
    }
}
