using SocialNetwork.Services.DTOs;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface ILikeService
    {
        Task<PostDTO> Check(PostDTO postDTO);
        Task<bool> LikeAsync(PostDTO likeDTO);
        Task<bool> DislikeAsync(PostDTO likeDTO);
        Task<LikeDTO> GetByIdAsync(int id);
        // IEnumerable<LikeDTO> GetPostLikes(int postId);
        Task<bool> DeleteAsync(int id);
    }
}
