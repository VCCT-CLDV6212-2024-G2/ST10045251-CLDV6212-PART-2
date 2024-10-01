using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure.Data.Tables;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using Azure;


public class AzureFileService
{
    private readonly IConfiguration _configuration;


    public AzureFileService(IConfiguration configuration)
    {
        _configuration = configuration;

    }

    //Uploading a file to Azure File Share
    public async Task UploadFileAsync(string shareName, string directoryName, string fileName, Stream fileStream)
    {
        var shareClient = new ShareClient(_configuration["AzureStorageConnectionString"], shareName);  //unable to provide string, due to failed function app 

        await shareClient.CreateIfNotExistsAsync();

        ShareDirectoryClient directory = shareClient.GetDirectoryClient(directoryName);
        await directory.CreateIfNotExistsAsync();

        ShareFileClient file = directory.GetFileClient(fileName);

        await file.CreateAsync(fileStream.Length);
        await file.UploadRangeAsync(
            new HttpRange(0, fileStream.Length),
            fileStream);
    }

    public class CustomerEntity : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public string ETag { get; set; }

       
        public string Name { get; set; }
        public string Email { get; set; }
        ETag ITableEntity.ETag { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
