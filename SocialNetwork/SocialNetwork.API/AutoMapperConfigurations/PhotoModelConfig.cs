using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Web.AutoMapperConfigurations
{
    public class PhotoModelConfig : Profile
    {
        public PhotoModelConfig()
        {
            this.CreateMap<Photo, PhotoDTO>()
                .ReverseMap();
        }
    }
}
