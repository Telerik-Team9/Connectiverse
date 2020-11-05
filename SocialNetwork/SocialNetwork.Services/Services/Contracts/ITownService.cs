using SocialNetwork.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface ITownService
    {
        Task<TownDTO> GetByNameAsync(string name);
        Task<IEnumerable<TownDTO>> GetAllAsync();
        //CountryDTO GetById(int id);
    }
}
