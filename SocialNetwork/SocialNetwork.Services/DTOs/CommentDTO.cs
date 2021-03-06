﻿using System;

namespace SocialNetwork.Services.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }

        public int PostId { get; set; }
        public Guid UserId { get; set; }
        public string UserDisplayName { get; set; }
        public string UserProfilePictureUrl { get; set; }
    }
}
