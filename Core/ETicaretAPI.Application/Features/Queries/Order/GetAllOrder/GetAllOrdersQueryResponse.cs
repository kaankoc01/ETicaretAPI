namespace ETicaretAPI.Application.Features.Queries.Order.GetAllOrder
{
    public class GetAllOrdersQueryResponse
    {
        public int TotalOrderCount { get; set; }
        public object Orders { get; set; }

    }
}