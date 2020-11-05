using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Services.AutoMapperConfigurations
{
    public class SocialMediaConfig : Profile
    {
        public SocialMediaConfig()
        {
            this.CreateMap<SocialMedia, SocialMediaDTO>().ReverseMap();
        }
    }
}
