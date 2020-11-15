using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SocialNetwork.Web.Models
{
    public class SearchViewModel
    {
        public string SearchWord { get; set; }
        public string SearchCriteria { get; set; }
        public string SortOrder { get; set; }
        public ICollection<UserProfileViewModel> Users { get; set; } = new HashSet<UserProfileViewModel>();
        public ICollection<PostViewModel> Posts { get; set; } = new HashSet<PostViewModel>();
    }
}
