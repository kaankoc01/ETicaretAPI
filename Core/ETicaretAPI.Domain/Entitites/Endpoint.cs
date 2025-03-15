using ETicaretAPI.Domain.Entitites.Common;
using ETicaretAPI.Domain.Entitites.Identity;

namespace ETicaretAPI.Domain.Entitites
{
    public class Endpoint : BaseEntity
    {
        public Endpoint()
        {
            Roles = new HashSet<AppRole>();
        }

        public string ActionType { get; set; }
        public string HttpType { get; set; }
        public string Definition { get; set; }
        public string Code { get; set; }

        public Menu Menu { get; set; }
        public ICollection<AppRole> Roles { get; set; }

    }
}
