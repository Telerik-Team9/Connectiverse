using SocialNetwork.Models;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
