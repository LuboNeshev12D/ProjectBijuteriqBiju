namespace BijuteriaProject.Data
{
    public class Prilojenie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RegDate { get; set; } = DateTime.Now;
        public ICollection<Product> Products { get; set; }//1:M
    }
}