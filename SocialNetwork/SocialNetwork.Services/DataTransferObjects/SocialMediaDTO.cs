using System;

namespace SocialNetwork.Services.DataTransferObjects
{
    public class SocialMediaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string UserLink { get; set; }

        public Guid UserId { get; set; }
    }
}
