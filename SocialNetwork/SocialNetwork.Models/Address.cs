using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int TownId { get; set; }
        public Town Town { get; set; }

        public ICollection<User> Users { get; set; } = new HashSet<User>();
    }
}
