using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.AutoMapperConfigs
{
    public class LikeVMConfig : Profile
    {
        public LikeVMConfig()
        {
            this.CreateMap<Like, LikeDTO>()
                .ReverseMap();
            this.CreateMap<LikeDTO, LikeViewModel>()
                .ReverseMap();
        }
    }
}
