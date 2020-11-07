using AutoMapper;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.AutoMapperConfigurations
{
    public class CommentModelConfig : Profile
    {
        public CommentModelConfig()
        {
            this.CreateMap<CommentDTO, CommentModel>();
        }
    }
}
