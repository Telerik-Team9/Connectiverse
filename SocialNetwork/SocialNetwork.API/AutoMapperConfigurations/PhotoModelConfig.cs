using AutoMapper;
using SocialNetwork.API.Models;
using SocialNetwork.Services.DTOs;

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
