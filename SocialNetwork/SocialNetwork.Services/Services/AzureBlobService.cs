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

/*public async Task DownloadOrGetUrlBlobStorageAsync(IFormFile file)
{
    if (file == null)
    {
        throw new ArgumentException(ExceptionMessages.InvalidFile);
    }

    //string blobName = "110336295_185673349649304_1995275544731972721_o.jpg"; // Existing file in storage
    string blobName = file.FileName; // Existing file in storage

    CloudBlockBlob blockBlob;
    await using (MemoryStream memoryStream = new MemoryStream())
    {
        string blobstorageconnection = configuration.GetValue<string>("blobstorage");

        CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
        CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
        CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("filescontainers");

        blockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);

        //string imgUrl = blockBlob.SnapshotQualifiedUri.ToString();
        await blockBlob.DownloadToStreamAsync(memoryStream);
    }

    Stream blobStream = blockBlob.OpenReadAsync().Result;
    //return File(blobStream, blockBlob.Properties.ContentType, blockBlob.Name);

}*/

/*public async Task ListFilesFromBlobStorageAsync(IFormFile file)
{
    if (file == null)
    {
        throw new ArgumentException(ExceptionMessages.InvalidFile);
    }

    string blobstorageconnection = configuration.GetValue<string>("blobstorage");
    CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);

    // Create the blob client.
    CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();

    CloudBlobContainer container = blobClient.GetContainerReference("filescontainers");
    CloudBlobDirectory dirb = container.GetDirectoryReference("filescontainers");

    BlobResultSegment resultSegment = await container.ListBlobsSegmentedAsync(string.Empty,
        true, BlobListingDetails.Metadata, 100, null, null, null);

    List<FileData> fileList = new List<FileData>();

    foreach (var blobItem in resultSegment.Results)
    {
        // A flat listing operation returns only blobs, not virtual directories.
        var blob = (CloudBlob)blobItem;
        fileList.Add(new FileData()
        {
            FileName = blob.Name,
            FileSize = Math.Round((blob.Properties.Length / 1024f) / 1024f, 2).ToString(),
            ModifiedOn = DateTime.Parse(blob.Properties.LastModified.ToString()).ToLocalTime().ToString()
        });
    }
}*/
