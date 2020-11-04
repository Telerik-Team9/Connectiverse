namespace SocialNetwork.Services.DTOs
{
    public class PhotoDTO
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public int PostId { get; set; }
        public PostDTO Post { get; set; }
    }
}
