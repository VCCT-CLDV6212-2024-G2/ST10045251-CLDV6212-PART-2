using Azure.Data.Tables;
using Azure.Storage.Blobs;
using Azure.Storage.Files.Shares;
using Azure.Storage.Queues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ST10045251_CLDV6212_POE.Models;

namespace ST10045251_CLDV6212_POE.Controllers
{
    public class StorageController : Controller
    {
        
        private readonly string _storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=st10045251cldstorage;AccountKey=QW4sgPQj7eDfXPnPQ4PquCVW7h4SeZj9q2iMfA02b/w4kZG/9sfcbqedrMTt23HE1SIQ4DO5ghfw+ASthvgcWw==;EndpointSuffix=core.windows.net";

        
        [HttpGet]
        public IActionResult AddCustomerProfile()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetStarted()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerProfile(CustomerProfile model)
        {
            var tableClient = new TableServiceClient(_storageConnectionString).GetTableClient("CustomerProfiles");
            await tableClient.AddEntityAsync(model);
            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public IActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            var blobContainerClient = new BlobServiceClient(_storageConnectionString).GetBlobContainerClient("product-images"); //No connection, unable to deploy new function app
            var blobClient = blobContainerClient.GetBlobClient(file.FileName);
            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream);
            }
            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public IActionResult ProcessOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProcessOrder(string orderDetails)
        {
            var queueClient = new QueueClient(_storageConnectionString, "order-processing"); //No connection, unable to deploy new function app
            await queueClient.SendMessageAsync(orderDetails);
            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public IActionResult UploadContract()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadContract(IFormFile file)
        {
            var shareClient = new ShareClient(_storageConnectionString, "contracts-logs"); //No connection, unable to deploy new function app
            var directoryClient = shareClient.GetDirectoryClient("");
            var fileClient = directoryClient.GetFileClient(file.FileName);
            using (var stream = file.OpenReadStream())
            {
                await fileClient.CreateAsync(stream.Length);
                await fileClient.UploadAsync(stream);
            }
            return RedirectToAction("Index");
        }

        
        public IActionResult Index()
        {
            return View();
        }

    }
}
