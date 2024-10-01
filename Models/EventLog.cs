using Azure.Data.Tables;
using Azure;

namespace ST10045251_CLDV6212_POE.Models
{
    public class EventLog : ITableEntity
    {
        public string PartitionKey { get; set; } 
        public string RowKey { get; set; } 
        public string EventData { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public EventLog() { }
    }
}