using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Services.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
