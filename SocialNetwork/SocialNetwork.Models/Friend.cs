using SocialNetwork.Models.Abstracts;
using System;

namespace SocialNetwork.Models
{
    public class Friend : Entity
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid UserFriendId { get; set; }
        public User UserFriend { get; set; }
    }
}
