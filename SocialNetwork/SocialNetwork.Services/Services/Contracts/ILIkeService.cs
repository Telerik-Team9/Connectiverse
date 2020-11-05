using SocialNetwork.Services.DTOs;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface ILikeService
    {
        Task<LikeDTO> CreateAsync(LikeDTO like);
        Task<LikeDTO> GetByIdAsync(int id);
        // IEnumerable<LikeDTO> GetPostLikes(int postId);
        Task<bool> DeleteAsync(int id);
    }
}
