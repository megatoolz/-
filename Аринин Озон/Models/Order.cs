namespace Аринин_Озон.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public bool IsDelivered { get; set; }
        public bool IsReturned { get; set; }
    }
}
