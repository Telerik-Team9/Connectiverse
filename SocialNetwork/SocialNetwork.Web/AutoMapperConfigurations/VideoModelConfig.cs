using AutoMapper;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.AutoMapperConfigurations
{
    public class VideoModelConfig : Profile
    {
        public VideoModelConfig()
        {
            this.CreateMap<VideoDTO, VideoModel>()
                .ReverseMap();
        }
    }
}
