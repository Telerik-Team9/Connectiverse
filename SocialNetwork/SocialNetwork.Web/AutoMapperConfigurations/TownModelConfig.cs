using AutoMapper;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

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
