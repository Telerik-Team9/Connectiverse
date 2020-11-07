using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;

namespace SocialNetwork.Services.AutoMapperConfigurations
{
    public class CommentConfig : Profile
    {
        public CommentConfig()
        {
            this.CreateMap<Comment, CommentDTO>().ReverseMap();
        }
    }
}
