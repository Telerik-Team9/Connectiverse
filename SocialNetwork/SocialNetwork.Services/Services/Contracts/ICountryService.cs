using SocialNetwork.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface ICountryService
    {
        Task<CountryDTO> GetByNameAsync(string name);
        Task<IEnumerable<CountryDTO>> GetAllAsync();
        //CountryDTO GetById(int id);
    }
}