﻿using SocialNetwork.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface ICommentService
    {
        Task<CommentDTO> CreateAsync(CommentDTO comment);
        Task<bool> DeleteAsync(int id);
        Task<CommentDTO> EditAsync(CommentDTO commentDTO);
        Task<IEnumerable<CommentDTO>> GetAllAsync();
    }
}