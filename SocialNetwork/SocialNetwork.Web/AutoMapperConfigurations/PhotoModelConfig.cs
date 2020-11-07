using AutoMapper;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.AutoMapperConfigurations
{
    public class PhotoModelConfig : Profile
    {
        public PhotoModelConfig()
        {
            this.CreateMap<PhotoDTO, PhotoModel>()
                .ReverseMap();
        }
    }
}
