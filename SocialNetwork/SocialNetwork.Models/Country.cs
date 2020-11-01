using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISO { get; set; }

        public ICollection<Town> Towns { get; set; } = new List<Town>();
        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}
