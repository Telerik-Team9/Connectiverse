using Microsoft.AspNetCore.Http;
using SocialNetwork.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface IPostService
    {
        Task<PostDTO> CreateAsync(PostDTO post, IFormFile file = null, PhotoDTO photoDTO = null, VideoDTO videoDTO = null);
        Task<PostDTO> GetPostByIdAsync(int id);
        Task<bool> DeletePostAsync(int id);
        Task<PostDTO> EditPostAsync(int id, PostDTO postDTO);
        Task<IEnumerable<PostDTO>> GetUserPostsAsync(Guid userId);
        Task<IEnumerable<PostDTO>> GetUserFriendsPostsAsync(Guid userId);
        Task<IEnumerable<PostDTO>> GetByContentAsync(string searchCriteria = "", string sortOrder = "mostRecent");
        Task<IEnumerable<PostDTO>> GetAllAsync();
    }
}
