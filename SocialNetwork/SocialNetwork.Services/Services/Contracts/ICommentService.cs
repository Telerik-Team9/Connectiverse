using SocialNetwork.Services.DTOs;
using System.Collections.Generic;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface ICommentService
    {
        CommentDTO GetById(int id);
        IEnumerable<CommentDTO> GetAll();
    }
}
