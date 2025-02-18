using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Domain.Entitites.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string NameSurname { get; set; }
    }
}
