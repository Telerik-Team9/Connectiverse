using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;

namespace SocialNetwork.Web.AutoMapperConfigs
{
    public class CommentVMConfig : Profile
    {
        public CommentVMConfig()
        {
            this.CreateMap<Comment, CommentDTO>()
                .ReverseMap();

            this.CreateMap<CommentDTO, CommentViewModel>()
                .ReverseMap();
        }
    }
}
