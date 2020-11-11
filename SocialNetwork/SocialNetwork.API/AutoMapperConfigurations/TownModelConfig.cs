using AutoMapper;
using SocialNetwork.API.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Web.AutoMapperConfigurations
{
    public class TownModelConfig : Profile
    {
        public TownModelConfig()
        {
            this.CreateMap<TownDTO, TownModel>();
        }
    }
}
