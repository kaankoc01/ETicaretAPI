using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entitites.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;

        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();
        public IQueryable<T> GetAll() => Table;


        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method) => Table.Where(method);


        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method) => await Table.SingleOrDefaultAsync(method);

        // marker işaretleyeciyi base türler. 
        public async Task<T> GetByIdAsync(string id) => await Table.SingleOrDefaultAsync(x => x.Id == Guid.Parse(id));


    }
}
