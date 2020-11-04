using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Services.AutoMapperConfigurations
{
    public class TownConfig : Profile
    {
        public TownConfig()
        {
            this.CreateMap<Town, TownDTO>();
        }
    }
}
