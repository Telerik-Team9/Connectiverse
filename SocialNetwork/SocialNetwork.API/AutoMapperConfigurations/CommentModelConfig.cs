using AutoMapper;
using SocialNetwork.API.Models;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Web.AutoMapperConfigurations
{
    public class CommentModelConfig : Profile
    {
        public CommentModelConfig()
        {
            this.CreateMap<Comment, CommentDTO>()
                .ReverseMap();
            this.CreateMap<CommentDTO, CommentModel>()
                .ReverseMap();
        }
    }
}
