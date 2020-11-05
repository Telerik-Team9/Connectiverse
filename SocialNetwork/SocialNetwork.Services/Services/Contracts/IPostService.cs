using SocialNetwork.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface IPostService
    {
        Task<PostDTO> CreateAsync(PostDTO post);
        Task<PostDTO> GetByIdAsync(int id);
        Task<IEnumerable<PostDTO>> GetUserPostsAsync(Guid userId);
        Task<IEnumerable<PostDTO>> GetUserFriendsPostsAsync(Guid userId);
        Task<bool> DeleteAsync(int id);

        /*Task<IEnumerable<PostDTO>> GetAllAsync();*/
    }
}
