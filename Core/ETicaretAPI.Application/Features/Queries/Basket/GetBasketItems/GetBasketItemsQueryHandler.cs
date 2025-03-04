using ETicaretAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Application.Features.Queries.Basket.GetBasketItems
{
    public class GetBasketItemsQueryHandler : IRequestHandler<GetBasketItemsQueryRequest, List<GetBasketItemsQueryResponse>>
    {
        private readonly IBasketService _basketService;


        public GetBasketItemsQueryHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<List<GetBasketItemsQueryResponse>> Handle(GetBasketItemsQueryRequest request, CancellationToken cancellationToken)
        {
            var basketItems = await _basketService.GetBasketItemsAsync();
            return basketItems.Select(bi => new GetBasketItemsQueryResponse
            {
                BasketItemId = bi.Id.ToString(),
                Name = bi.Product.Name,
                Price = bi.Product.Price,
                Quantity = bi.Quantity
            }).ToList();
        }
    }
}
