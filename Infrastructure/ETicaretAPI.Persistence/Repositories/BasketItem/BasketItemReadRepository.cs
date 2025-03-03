using ETicaretAPI.Application.Repositories.BasketItem;
using ETicaretAPI.Domain.Entitites;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Repositories
{
    public class BasketItemReadRepository : ReadRepository<BasketItem>, IBasketItemReadRepository
    {
        public BasketItemReadRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
