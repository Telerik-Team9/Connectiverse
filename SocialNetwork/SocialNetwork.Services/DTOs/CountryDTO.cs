using System.Collections.Generic;

namespace SocialNetwork.Services.DTOs
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISO { get; set; }

        public ICollection<TownDTO> Towns { get; set; } = new HashSet<TownDTO>();
    }
}
