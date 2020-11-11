using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.AutoMapperConfigs
{
    public class VideoVMConfig : Profile
    {
        public VideoVMConfig()
        {
            this.CreateMap<Video, VideoDTO>()
                .ReverseMap();
            this.CreateMap<VideoDTO, VideoViewModel>()
                .ReverseMap();
        }
    }
}
