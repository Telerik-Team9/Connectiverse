using Microsoft.AspNetCore.Http;
using SocialNetwork.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface IPostService
    {
        Task<PostDTO> CreatePostAsync(IFormFile file, PostDTO post, PhotoDTO photoDTO = null, VideoDTO videoDTO = null);
        Task<CommentDTO> CreateCommentAsync(int postId, CommentDTO comment);
        Task<PostDTO> GetByIdAsync(int id);
        Task<IEnumerable<PostDTO>> GetUserPostsAsync(Guid userId);
        Task<IEnumerable<PostDTO>> GetUserFriendsPostsAsync(Guid userId);
        Task<bool> DeleteAsync(int id);

        /*Task<IEnumerable<PostDTO>> GetAllAsync();*/
    }
}
