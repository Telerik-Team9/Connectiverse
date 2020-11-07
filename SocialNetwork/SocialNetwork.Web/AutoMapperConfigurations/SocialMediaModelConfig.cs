using AutoMapper;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.AutoMapperConfigurations
{
    public class SocialMediaModelConfig : Profile
    {
        public SocialMediaModelConfig()
        {
            this.CreateMap<SocialMediaDTO, SocialMediaModel>();
        }
    }
}
