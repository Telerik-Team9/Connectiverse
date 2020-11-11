using AutoMapper;
using SocialNetwork.API.Models;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Web.AutoMapperConfigurations
{
    public class SocialMediaModelConfig : Profile
    {
        public SocialMediaModelConfig()
        {
            this.CreateMap<SocialMedia, SocialMediaDTO>()
                .ReverseMap();
            this.CreateMap<SocialMediaDTO, SocialMediaModel>()
                .ReverseMap();
        }
    }
}
