using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using SocialNetwork.Services.Constants;
using SocialNetwork.Services.Services.Contracts;
using System;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services
{
    public class AzureBlobService : IAzureBlobService
    {
        private readonly IConfiguration configuration;

        public AzureBlobService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<string> UploadToBlobStorageAsync(IFormFile file)
        {
            try
            {
                string systemFileName = file.FileName;
                string blobstorageconnection = configuration.GetValue<string>("blobstorage");

                // Retrieve storage account from connection string.
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);

                // Create the blob client.
                CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();

                // Retrieve a reference to a container.
                CloudBlobContainer container = blobClient.GetContainerReference("filescontainers");

                // This also does not make a service call; it only creates a local object.
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(systemFileName);

                await using (var data = file.OpenReadStream())
                {
                    await blockBlob.UploadFromStreamAsync(data);
                }

                return blockBlob.SnapshotQualifiedUri.ToString();
                //return blockBlob.Uri.AbsoluteUri.ToString();
            }
            catch (Exception)
            {
                throw new ArgumentException(ExceptionMessages.BlobError);
            }
        }
    }
}