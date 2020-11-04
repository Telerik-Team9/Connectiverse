using SocialNetwork.Services.DTOs;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface IPostService
    {
        PostDTO Create(PostDTO post);
        PostDTO GetById(int id);
        IEnumerable<PostDTO> GetUserPosts(Guid userId);
        IEnumerable<PostDTO> GetUserFriendsPosts(Guid userId);
        bool Delete(int id);

        /*IEnumerable<PostDTO> GetAll();*/
    }
}
