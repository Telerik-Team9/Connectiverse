using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.AutoMapperConfigs
{
    public class SocialMediaVMConfig : Profile
    {
        public SocialMediaVMConfig()
        {
            this.CreateMap<SocialMedia, SocialMediaDTO>()
                .ReverseMap();
            this.CreateMap<SocialMediaDTO, SocialMediaViewModel>()
                .ReverseMap();
        }
    }
}
