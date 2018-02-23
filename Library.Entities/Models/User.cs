using Microsoft.AspNetCore.Identity;

namespace Library.Entities.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
