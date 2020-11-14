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
                .ForMember(dest => dest.UserDisplayName,
                    opt => opt.MapFrom(src => src.Post.User.DisplayName))
                .ReverseMap();

            this.CreateMap<CommentDTO, CommentViewModel>()
                .ReverseMap();
        }
    }
}
