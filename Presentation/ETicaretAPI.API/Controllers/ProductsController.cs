using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entitites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;
            


        private readonly ICustomerWriteRepository _customerWriteRepository;
        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IOrderWriteRepository orderWriteRepository , ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
            
        }
        [HttpGet]
        public async Task Get()
        {
          Order order = await _orderReadRepository.GetByIdAsync("0194c86f-98e4-794d-bb75-e26d8466d329");
          order.Address = "İstanbul";
          await _orderWriteRepository.SaveAsync();


        }


    }
}
