using System.Data.SqlClient;

namespace ST10045251_CLDV6212_POE.Services
{
    public class DatabaseService
    {
        private string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddCustomer(int customerId, string name, string email)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Customers (CustomerID, Name, Email) VALUES (@CustomerID, @Name, @Email)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddProduct(int productId, string productName, decimal price)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Products (ProductID, ProductName, Price) VALUES (@ProductID, @ProductName, @Price)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.Parameters.AddWithValue("@ProductName", productName);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddOrder(int orderId, int customerId, int productId, DateTime orderDate)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Orders (OrderID, CustomerID, ProductID, OrderDate) VALUES (@OrderID, @CustomerID, @ProductID, @OrderDate)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", orderId);
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    cmd.Parameters.AddWithValue("@ProductID", productId);
                    cmd.Parameters.AddWithValue("@OrderDate", orderDate);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}