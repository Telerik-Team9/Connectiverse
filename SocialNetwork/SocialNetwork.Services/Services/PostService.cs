using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Database;
using SocialNetwork.Models;
using SocialNetwork.Services.Constants;
using SocialNetwork.Services.DTOs;
using SocialNetwork.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services
{
    public class PostService : IPostService
    {
        private readonly SocialNetworkDBContext context;
        private readonly IAzureBlobService blobService;
        private readonly IMapper mapper;

        public PostService(SocialNetworkDBContext context, IAzureBlobService blobService, IMapper mapper)
        {
            this.context = context;
            this.blobService = blobService;
            this.mapper = mapper;
        }

        public async Task<PostDTO> CreateAsync(PostDTO postDTO, IFormFile file = null, PhotoDTO photoDTO = null, VideoDTO videoDTO = null)
        {
            if (postDTO == null)
            {
                throw new ArgumentNullException(ExceptionMessages.InvalidModel);
            }

            // Create the post
            var user = await this.context.Users
               .FirstOrDefaultAsync(u => u.Id == postDTO.UserId)
               ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

            var post = this.mapper.Map<Post>(postDTO);

            post.UserId = postDTO.UserId;
            post.User = user;

            await this.context.Posts.AddAsync(post);
            await this.context.SaveChangesAsync();

            // Create the media
            await this.AddMediaToPost(file, photoDTO, videoDTO, post);

            // Save the changes
            await this.context.SaveChangesAsync();

            return this.mapper.Map<PostDTO>(post); // TODO: QUestion
        }       //upload IFormFile
        /*
                public async Task<CommentDTO> CreateCommentAsync(CommentDTO commentDTO)
                {
                    if (commentDTO.PostId == 0 || commentDTO == null)
                    {
                        throw new ArgumentNullException(ExceptionMessages.EntityNotFound);
                    }

                    // Create the comment and add it to the DB
                    var comment = this.mapper.Map<Comment>(commentDTO);
                    await this.context.Comments.AddAsync(comment);
                    await this.context.SaveChangesAsync();

                    return commentDTO;
                }*/

        public async Task<bool> DeletePostAsync(int id) // Still not used
        {
            try
            {
                var post = await this.context.Posts
                               .FirstOrDefaultAsync(p => p.Id == id);

                post.IsDeleted = true;
                post.DeletedOn = DateTime.UtcNow;
                await this.context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }   //delete

        public async Task<PostDTO> GetPostByIdAsync(int id)
        {
            var post = await this.context.Posts.Where(p => !p.IsDeleted && p.Id == id)
                .ProjectTo<PostDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync()
                ?? throw new ArgumentException(ExceptionMessages.EntityNotFound);

            return this.mapper.Map<PostDTO>(post);
        }

        public async Task<IEnumerable<PostDTO>> GetUserFriendsPostsAsync(Guid userId)   //TODO: Add algorythm, rename
        {
            var friendships = await this.context.Friends
                .Where(f => f.UserId == userId && !f.IsDeleted)
                .ToListAsync();

            var friendsPosts = new List<PostDTO>();

            foreach (var fs in friendships)
            {
                var currFriendsPosts = await this.context.Posts
                    .Where(p => !p.IsDeleted && p.UserId == fs.UserFriendId)
                    .ProjectTo<PostDTO>(mapper.ConfigurationProvider)
                    .ToListAsync();

                friendsPosts.AddRange(currFriendsPosts);
            }

            if (!friendsPosts.Any())
            {
                throw new ArgumentException(ExceptionMessages.EntitiesNotFound);
            }

            return friendsPosts;
        }

        public async Task<IEnumerable<PostDTO>> GetUserPostsAsync(Guid userId)
        {
            var posts = await this.context.Posts
                .Where(p => !p.IsDeleted && p.UserId == userId)
                .ProjectTo<PostDTO>(mapper.ConfigurationProvider)
                .ToListAsync();

            if (!posts.Any())
            {
                throw new ArgumentException(ExceptionMessages.EntitiesNotFound);
            }

            return posts;
        }

        public async Task<IEnumerable<PostDTO>> GetByContentAsync(string searchCriteria = "", string sortOrder = "mostRecent")
        {
            if (string.IsNullOrWhiteSpace(searchCriteria))
            {
                throw new ArgumentException(ExceptionMessages.InvalidCriteria);
            }

            var result = await this.context.Posts
                            .Where(p => !p.IsDeleted && p.Content.Contains(searchCriteria))
                            .ProjectTo<PostDTO>(this.mapper.ConfigurationProvider)
                            .ToListAsync()
                        ?? throw new ArgumentException(ExceptionMessages.EntitiesNotFound);

            if (sortOrder == "nameAsc")
            {
                return result.OrderBy(p => p.Content);
            }
            else if (sortOrder == "nameDesc")
            {
                return result.OrderByDescending(p => p.Content);
            }
            return result.OrderByDescending(p => p.CreatedOn);
        }

        private async Task AddMediaToPost(IFormFile file, PhotoDTO photoDTO, VideoDTO videoDTO, Post post)
        {
            if (file != null)
            {
                var url = await this.blobService.UploadToBlobStorageAsync(file);
                photoDTO = new PhotoDTO { Url = url };

                var photo = this.mapper.Map<Photo>(photoDTO);
                photo.PostId = post.Id;

                post.Photo = photo;
                post.Video = null;
            }
            else if (photoDTO != null)
            {
                var photo = this.mapper.Map<Photo>(photoDTO);
                photo.PostId = post.Id;

                post.Photo = photo;
                post.Video = null;
            }
            else if (videoDTO != null)
            {
                var video = this.mapper.Map<Video>(videoDTO);
                video.PostId = post.Id;

                post.Video = video;
                post.Photo = null;
            }
            else
            {
                post.Photo = null;
                post.Video = null;
            }
        }
    }
}

// AzureBlob methods:



//public async Task<ActionResult> UploadToBlobStorage(IFormFile files)
//{
//    if (files == null)
//        return View();

//    string systemFileName = files.FileName;
//    string blobstorageconnection = configuration.GetValue<string>("blobstorage");

//    // Retrieve storage account from connection string.
//    CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
//    // Create the blob client.
//    CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
//    // Retrieve a reference to a container.
//    CloudBlobContainer container = blobClient.GetContainerReference("filescontainers");
//    // This also does not make a service call; it only creates a local object.
//    CloudBlockBlob blockBlob = container.GetBlockBlobReference(systemFileName);

//    await using (var data = files.OpenReadStream())
//    {
//        await blockBlob.UploadFromStreamAsync(data);
//    }


//                // Another way - UploadFromByteArrayAsync

//                           byte[] dataFiles;
//                            BlobContainerPermissions permissions = new BlobContainerPermissions
//                            {
//                                PublicAccess = BlobContainerPublicAccessType.Blob
//                            };

//                            await container.SetPermissionsAsync(permissions);
//                            await using (var target = new MemoryStream())
//                            {
//                                files.CopyTo(target);
//                                dataFiles = target.ToArray();
//                            }

//                            await blockBlob.UploadFromByteArrayAsync(dataFiles, 0, dataFiles.Length);*//*

//    return View();
//}

//public async Task<ActionResult> ListFilesFromBlobStorage(IFormFile files)
//{
//    string blobstorageconnection = configuration.GetValue<string>("blobstorage");
//    CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
//    // Create the blob client.
//    CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
//    CloudBlobContainer container = blobClient.GetContainerReference("filescontainers");
//    CloudBlobDirectory dirb = container.GetDirectoryReference("filescontainers");

//    BlobResultSegment resultSegment = await container.ListBlobsSegmentedAsync(string.Empty,
//        true, BlobListingDetails.Metadata, 100, null, null, null);

//    List<FileData> fileList = new List<FileData>();

//    foreach (var blobItem in resultSegment.Results)
//    {
//        // A flat listing operation returns only blobs, not virtual directories.
//        var blob = (CloudBlob)blobItem;
//        fileList.Add(new FileData()
//        {
//            FileName = blob.Name,
//            FileSize = Math.Round((blob.Properties.Length / 1024f) / 1024f, 2).ToString(),
//            ModifiedOn = DateTime.Parse(blob.Properties.LastModified.ToString()).ToLocalTime().ToString()
//        });
//    }

//    return View();
//}

//public async Task<ActionResult> DownloadOrGetUrlBlobStorage(IFormFile files)
//{
//    string blobName = "110336295_185673349649304_1995275544731972721_o.jpg"; // Existing file in storage
//    //string blobName = files.FileName; // Existing file in storage

//    CloudBlockBlob blockBlob;
//    await using (MemoryStream memoryStream = new MemoryStream())
//    {
//        string blobstorageconnection = configuration.GetValue<string>("blobstorage");
//        CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
//        CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
//        CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference("filescontainers");
//        blockBlob = cloudBlobContainer.GetBlockBlobReference(blobName);

//        //string imgUrl = blockBlob.SnapshotQualifiedUri.ToString();
//        await blockBlob.DownloadToStreamAsync(memoryStream);
//    }

//    Stream blobStream = blockBlob.OpenReadAsync().Result;
//    //return File(blobStream, blockBlob.Properties.ContentType, blockBlob.Name);
//    return View();
//}