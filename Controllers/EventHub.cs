using Microsoft.AspNetCore.Mvc;
using ST10045251_CLDV6212_POE.Services;

namespace ST10045251_CLDV6212_POE.Controllers
{
    public class EventHubController : Controller
    {
        private readonly EventHubService _eventHubService;

        public EventHubController()
        {
            var connectionString = "<Event Hub Connection String>";
            var eventHubName = "order-events";
            _eventHubService = new EventHubService(connectionString, eventHubName);
        }

        [HttpPost]
        public async Task<IActionResult> SendOrderEvent(string orderDetails)
        {
            await _eventHubService.SendEventAsync(orderDetails);
            return RedirectToAction("Index");
        }
    }
}
