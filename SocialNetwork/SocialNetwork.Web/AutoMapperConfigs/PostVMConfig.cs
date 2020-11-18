using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Web.Models;
using System.Linq;

namespace SocialNetwork.Web.AutoMapperConfigs
{
    public class PostVMConfig : Profile
    {
        public PostVMConfig()
        {
            this.CreateMap<Post, PostDTO>()
                .ForMember(dest => dest.Comments,
                    opt => opt.MapFrom(src => src.Comments.Where(c => !c.IsDeleted)
                                                          .OrderByDescending(c => c.CreatedOn)))
                .ReverseMap()
                .ForMember(dest => dest.Comments,
                    opt => opt.MapFrom(src => src.Comments.OrderByDescending(c => c.CreatedOn)));

            this.CreateMap<PostDTO, PostViewModel>()
                .ReverseMap();
        }
    }
}
