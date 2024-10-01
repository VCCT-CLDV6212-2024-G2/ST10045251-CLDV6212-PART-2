using Azure.Data.Tables;
using static AzureFileService;


namespace ST10045251_CLDV6212_POE.Services
{
    public class AzureTableService
    {
        private readonly TableClient _tableClient;

        public AzureTableService(string connectionString, string tableName)
        {
            _tableClient = new TableClient(connectionString, tableName);

        }

        public async Task AddEntityAsync<T>(T entity) where T : class, ITableEntity, new()
        {
            await _tableClient.AddEntityAsync(entity);
        }
    }
}
