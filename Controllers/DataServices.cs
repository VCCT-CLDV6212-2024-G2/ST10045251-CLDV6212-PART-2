using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ST10045251_CLDV6212_POE.Controllers
{
    public class DataServices : Controller
    {
        private string _connectionString;

        public DataServices(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool TestConnection()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Database connection successful!");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Connection failed: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
