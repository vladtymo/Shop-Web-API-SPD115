using Microsoft.AspNetCore.Identity;

namespace BusinessLogic.Entities
{
    public class User : IdentityUser
    {
        public DateTime Birthdate { get; set; }
    }
}
