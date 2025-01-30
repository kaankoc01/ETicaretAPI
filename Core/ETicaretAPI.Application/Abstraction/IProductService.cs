using ETicaretAPI.Domain.Entitites;

namespace ETicaretAPI.Application.Abstraction
{
    public interface IProductService
    {
       List<Product> GetProducts();
        
    }
}
