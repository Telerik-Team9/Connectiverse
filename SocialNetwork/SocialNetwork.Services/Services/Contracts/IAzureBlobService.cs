using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services.Contracts
{
    public interface IAzureBlobService
    {
        Task<string> UploadToBlobStorageAsync(IFormFile file);
        Task DownloadOrGetUrlBlobStorageAsync(IFormFile file);
        Task ListFilesFromBlobStorageAsync(IFormFile file);
    }
}
