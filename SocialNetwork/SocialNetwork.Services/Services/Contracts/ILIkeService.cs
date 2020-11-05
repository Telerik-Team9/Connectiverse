using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface ILIkeService
    {
        LikeDTO Create(LikeDTO comment);
        LikeDTO GetById(int id);
        // IEnumerable<LikeDTO> GetPostLikes(int postId);
        bool Delete(int id);
    }
}
