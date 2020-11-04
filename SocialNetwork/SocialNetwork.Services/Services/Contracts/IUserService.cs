using SocialNetwork.Services.DTOs;
using System.Collections.Generic;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAll();
    }
}
