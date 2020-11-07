using AutoMapper;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

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
