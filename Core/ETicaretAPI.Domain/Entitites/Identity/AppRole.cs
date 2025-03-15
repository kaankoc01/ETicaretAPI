using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Domain.Entitites.Identity
{
    public class AppRole : IdentityRole<string>
    {
        public ICollection<Endpoint> Endpoints { get; set; }
    }
}
