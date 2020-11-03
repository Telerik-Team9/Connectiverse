using System.Collections.Generic;

namespace SocialNetwork.Services.DataTransferObjects
{
    public class TownDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public ICollection<UserDTO> Users { get; set; } = new HashSet<UserDTO>();
    }
}
