using System.ComponentModel.DataAnnotations.Schema;

namespace BijuteriaProject.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }//F.K M:1
        public Category Categories { get; set; }//M:1
        public int PrilojenieId { get; set; }//F.K M:1
        public Prilojenie Prilojeniq { get; set; }//M:1
        public string Description { get; set; }

        public string PhotoURL { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public DateTime RegDate { get; set; }
        public ICollection<Order> Orders { get; set; }//1:M
    }
}
