using AutoMapper;
using SocialNetwork.API.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Web.AutoMapperConfigurations
{
    public class LikeModelConfig : Profile
    {
        public LikeModelConfig()
        {
            this.CreateMap<LikeDTO, LikeModel>();
        }
    }
}
