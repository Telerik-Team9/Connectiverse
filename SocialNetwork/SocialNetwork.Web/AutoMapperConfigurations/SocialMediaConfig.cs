using AutoMapper;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.AutoMapperConfigurations
{
    public class SocialMediaConfig : Profile
    {
        public SocialMediaConfig()
        {
            this.CreateMap<SocialMediaDTO, SocialMediaModel>();
        }
    }
}
