using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Models
{
    public class AllPostsViewModel
    {
        ICollection<PostViewModel> posts { get; set; }
        CommentViewModel newComment { get; set; }
    }
}
