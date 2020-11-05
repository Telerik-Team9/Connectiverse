﻿using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface ICommentService
    {
        CommentDTO Create(CommentDTO comment);
        CommentDTO GetById(int id);
        // IEnumerable<CommentDTO> GetPostComments(int postId);
        bool Delete(int id);

        /*IEnumerable<CommentDTO> GetAll();*/
    }
}
