using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.AutoMapperConfigs
{
    public class TownVMConfig : Profile
    {
        public TownVMConfig()
        {
            this.CreateMap<Town, TownDTO>()
                .ReverseMap();
            this.CreateMap<TownDTO, TownViewModel>()
                .ReverseMap();
        }
    }
}
