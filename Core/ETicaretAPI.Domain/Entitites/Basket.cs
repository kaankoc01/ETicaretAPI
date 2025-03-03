using ETicaretAPI.Domain.Entitites.Common;
using ETicaretAPI.Domain.Entitites.Identity;

namespace ETicaretAPI.Domain.Entitites
{
    public class Basket : BaseEntity
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public Order Order { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
