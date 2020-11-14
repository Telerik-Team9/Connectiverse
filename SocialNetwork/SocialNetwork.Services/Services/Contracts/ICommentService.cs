using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface ICommentService
    {
        Task<CommentDTO> CreateAsync(CommentDTO comment);
/*        Task<CommentDTO> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);*/
    }
}