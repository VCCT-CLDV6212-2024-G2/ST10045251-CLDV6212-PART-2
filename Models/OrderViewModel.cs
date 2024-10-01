namespace ST10045251_CLDV6212_POE.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; } 
        public DateTime OrderDate { get; set; } 
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
