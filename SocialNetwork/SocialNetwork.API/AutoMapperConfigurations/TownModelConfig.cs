using AutoMapper;
using SocialNetwork.API.Models;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Web.AutoMapperConfigurations
{
    public class TownModelConfig : Profile
    {
        public TownModelConfig()
        {
            this.CreateMap<Town, TownDTO>()
                .ReverseMap();
            this.CreateMap<TownDTO, TownModel>()
                .ReverseMap();
        }
    }
}
