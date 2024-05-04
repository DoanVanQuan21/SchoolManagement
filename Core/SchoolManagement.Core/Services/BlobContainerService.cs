using SchoolManagement.Core.Contracts;
using Azure.Storage.Blobs;
using System.Diagnostics;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
namespace SchoolManagement.Core.Services
{
    public class BlobContainerService : IBlobContainerService
    {
        private const string IMAGE_CONTAINER_NAME = "pictures";
        private string connectionString = "DefaultEndpointsProtocol=https;AccountName=schoolmanagement;AccountKey=Y37EPzeIicHLJI5Xtj3pyUGslmrm4BxCZ8pakQz7qWbnUwhX+V8s9gB+v85wuH+Ecs7rlITWPxyl+AStT7z7Pw==;EndpointSuffix=core.windows.net";
        private readonly BlobServiceClient _blobServiceClient;
        private BlobContainerClient blobContainerClient;
        public BlobContainerService()
        {
           // connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");
            _blobServiceClient = new BlobServiceClient(connectionString);
            GetContainer().GetAwaiter();
        }
        public Task<Uri?> GetImage(string fileName)
        {
            return Task.Factory.StartNew(() =>
            {
                var image = blobContainerClient.GetBlockBlobClient("logo.png");
                if (image == null)
                {
                    return null;
                }
                return image.Uri;
            });
        }
        public async Task GetContainer()
        {
            try
            {
                blobContainerClient = _blobServiceClient.GetBlobContainerClient(IMAGE_CONTAINER_NAME);
                bool isExist = blobContainerClient.Exists();
                if (isExist)
                {
                    return;
                }
                blobContainerClient = await _blobServiceClient.CreateBlobContainerAsync(IMAGE_CONTAINER_NAME);
                if (blobContainerClient == null)
                {
                    return;
                }
                return;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
        private Task<BlobContainerClient> GetBlobContainerClientAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                return _blobServiceClient.GetBlobContainerClient(IMAGE_CONTAINER_NAME);
            });
        }
        public Task<string> DownloadImage(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UploadImage(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}