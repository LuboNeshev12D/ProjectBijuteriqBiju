using Microsoft.AspNetCore.Identity;

namespace BijuteriaProject.Data
{
    public class Client:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public DateTime RegDate { get; set; } = DateTime.Now;
        public ICollection<Order> Orders { get; set; }
    }
}