using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entitites;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Repositories
{
    public class BasketWriteRepository : WriteRepository<Basket>, IBasketWriteRepository
    {
        public BasketWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
