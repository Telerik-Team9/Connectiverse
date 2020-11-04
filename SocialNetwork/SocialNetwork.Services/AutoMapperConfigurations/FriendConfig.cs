using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Services.AutoMapperConfigurations
{
    public class FriendConfig : Profile
    {
        public FriendConfig()
        {
            this.CreateMap<Friend, FriendDTO>();
        }
    }
}
