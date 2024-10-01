using Microsoft.AspNetCore.Mvc;
using ST10045251_CLDV6212_POE.Services;
namespace ST10045251_CLDV6212_POE.Controllers
{
    public class OrderProcessing : Controller
    {
        private readonly QueueService _queueService;
        private readonly EventHubService _eventHubService;

        public OrderProcessing()
        {
            var storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=st10045251cldstorage;AccountKey=QW4sgPQj7eDfXPnPQ4PquCVW7h4SeZj9q2iMfA02b/w4kZG/9sfcbqedrMTt23HE1SIQ4DO5ghfw+ASthvgcWw==;EndpointSuffix=core.windows.net";
            _queueService = new QueueService(storageConnectionString, "order-processing");

            var eventHubConnectionString = "<Event Hub Connection String>"; //No connection, unable to deploy new function app
            _eventHubService = new EventHubService(eventHubConnectionString, "order-events");
        }

        [HttpPost]
        public async Task<IActionResult> ProcessOrder(string orderDetails)
        {
            await _queueService.AddMessageToQueueAsync(orderDetails);

            await _eventHubService.SendEventAsync(orderDetails);

            return RedirectToAction("Index");
        }
    }
}
