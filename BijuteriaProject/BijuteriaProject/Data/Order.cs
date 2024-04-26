namespace BijuteriaProject.Data
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductID { get; set; }//F.K M:1
        public Product Products { get; set; }//M:1
        public string ClientID { get; set; }//F.K M:1
        public Client Clients { get; set; }//M:1 
        public int Quantity { get; set; }
        public DateTime RegDate { get; set; } = DateTime.Now;
    }
}