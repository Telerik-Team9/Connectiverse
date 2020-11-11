using SocialNetwork.Services.DTOs;
using System.Collections.Generic;

namespace SocialNetwork.Web.Models
{
    public class NewsFeedViewModel
    {
        //public ICollection<PostViewModel> Posts { get; set; } = new HashSet<PostViewModel>();
        public ICollection<PostViewModel> Posts { get; set; } = new HashSet<PostViewModel>();
    }
}
