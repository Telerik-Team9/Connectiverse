using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface ICountryService
    {
        CountryDTO Get(int id);
    }
}
