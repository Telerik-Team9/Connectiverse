namespace SocialNetwork.Services.DTOs
{
    public class TownDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        //public ICollection<UserDTO> Users { get; set; } = new HashSet<UserDTO>();
        //TODO: Recover after mapping is done.
    }
}
