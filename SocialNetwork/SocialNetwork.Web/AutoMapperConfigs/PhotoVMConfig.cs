using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.AutoMapperConfigs
{
    public class PhotoVMConfig : Profile
    {
        public PhotoVMConfig()
        {
            this.CreateMap<Photo, PhotoDTO>()
                .ReverseMap();
            this.CreateMap<PhotoDTO, PhotoViewModel>()
                .ReverseMap();
        }
    }
}
