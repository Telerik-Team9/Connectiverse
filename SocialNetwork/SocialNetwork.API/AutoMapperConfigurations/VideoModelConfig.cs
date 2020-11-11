using AutoMapper;
using SocialNetwork.API.Models;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Web.AutoMapperConfigurations
{
    public class VideoModelConfig : Profile
    {
        public VideoModelConfig()
        {
            this.CreateMap<Video, VideoDTO>()
                .ReverseMap();
            this.CreateMap<VideoDTO, VideoModel>()
                .ReverseMap();
        }
    }
}
