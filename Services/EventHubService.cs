using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Text;

namespace ST10045251_CLDV6212_POE.Services
{
    public class EventHubService
    {
        private readonly EventHubProducerClient _producerClient;

        public EventHubService(string connectionString, string eventHubName)
        {
            _producerClient = new EventHubProducerClient(connectionString, eventHubName);
        }

        public async Task SendEventAsync(string eventData)
        {
            using EventDataBatch eventBatch = await _producerClient.CreateBatchAsync();
            eventBatch.TryAdd(new Azure.Messaging.EventHubs.EventData(Encoding.UTF8.GetBytes(eventData)));
            await _producerClient.SendAsync(eventBatch);
        }
    }
}
