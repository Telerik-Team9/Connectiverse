using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Services.AutoMapperConfigurations
{
    public class CountryConfig : Profile
    {
        public CountryConfig()
        {
            this.CreateMap<Country, CountryDTO>();
        }
    }
}
