using ETicaretAPI.Application.Repositories.BasketItem;
using ETicaretAPI.Domain.Entitites;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Repositories
{
    public class BasketItemWriteRepository : WriteRepository<BasketItem>, IBasketItemWriteRepository
    {
        public BasketItemWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
