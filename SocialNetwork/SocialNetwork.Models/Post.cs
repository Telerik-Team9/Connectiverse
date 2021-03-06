﻿using SocialNetwork.Models.Abstracts;
using SocialNetwork.Models.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Post : Entity
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public Visibility Visibility { get; set; } = Visibility.Public;

        public Guid UserId { get; set; }
        public User User { get; set; }

        public int? PhotoId { get; set; }
        public Photo Photo { get; set; }

        public int? VideoId { get; set; }
        public Video Video { get; set; }

        public ICollection<Like> Likes { get; set; } = new HashSet<Like>();
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
