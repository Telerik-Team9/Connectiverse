using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Services.AutoMapperConfigurations
{
    public class PhotoConfig : Profile
    {
        public PhotoConfig()
        {
            this.CreateMap<Photo, PhotoDTO>();
        }
    }
}
