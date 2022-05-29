using Microsoft.AspNetCore.Identity;

namespace LetsEat.API.Models
{
    public class User : IdentityUser
    {
        public ICollection<Order> Orders { get; set; }
        public FoodPrint FoodPrint { get; set; }
        public string FrichtiEmail { get; set; }
        public string FrichtiPassword { get; set; }
    }
}