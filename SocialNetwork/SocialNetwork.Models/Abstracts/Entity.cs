using SocialNetwork.Models.Contracts;
using System;

namespace SocialNetwork.Models.Abstracts
{
    public abstract class Entity : IEntity
    {
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
