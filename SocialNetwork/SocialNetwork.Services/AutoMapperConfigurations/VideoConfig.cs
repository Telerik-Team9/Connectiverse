using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Services.AutoMapperConfigurations
{
    public class VideoConfig : Profile
    {
        public VideoConfig()
        {
            this.CreateMap<Video, VideoDTO>().ReverseMap();
        }
    }
}
