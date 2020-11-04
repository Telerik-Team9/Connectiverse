using SocialNetwork.Services.DTOs;
using System.Collections.Generic;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface IPostService
    {
        PostDTO GetById(int id);
        IEnumerable<PostDTO> GetAll();
    }
}
