using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface IAzureBlobService
    {
        Task<string> UploadToBlobStorageAsync(IFormFile file);
    }
}
