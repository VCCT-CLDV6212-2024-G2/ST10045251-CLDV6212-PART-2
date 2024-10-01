using Microsoft.Extensions.Logging;
using Azure.Storage.Blobs;
using System.Threading.Tasks;

namespace ST10045251_CLDV6212_POE
{
    public class BlobService
    {
        private readonly BlobContainerClient _blobContainerClient;

        public BlobService(string storageConnectionString, string containerName)
        {
            var serviceClient = new BlobServiceClient(storageConnectionString);
            _blobContainerClient = serviceClient.GetBlobContainerClient(containerName);
        }

        public async Task UploadImageAsync(IFormFile file, string fileName)
        {
            var blobClient = _blobContainerClient.GetBlobClient(fileName);

            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream);
            }
        }
    }
}
