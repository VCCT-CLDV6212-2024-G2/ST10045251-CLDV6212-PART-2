using Azure.Storage.Files.Shares;
using ST10045251_CLDV6212_POE.Services;

namespace ST10045251_CLDV6212_POE
{
    public class FileShareService
    {
        private readonly ShareClient _shareClient;
        private readonly EventHubService _eventHubService;
        public FileShareService(string storageConnectionString, string shareName)
        {
            _shareClient = new ShareClient(storageConnectionString, shareName);
        }

        public async Task UploadFileAsync(IFormFile file, string fileName)
        {
            var directoryClient = _shareClient.GetDirectoryClient("");
            var fileClient = directoryClient.GetFileClient(fileName);

            using (var stream = file.OpenReadStream())
            {
                await fileClient.CreateAsync(stream.Length);
                await fileClient.UploadAsync(stream);
            }

            await _eventHubService.SendEventAsync($"File {fileName} uploaded successfully");
        }

    }
}
