using SocialNetwork.Services.DTOs;
using System.Collections.Generic;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface ICountryService
    {
        CountryDTO GetByName(string name);
        IEnumerable<CountryDTO> GetAll();
        //CountryDTO GetById(int id);
    }
}
