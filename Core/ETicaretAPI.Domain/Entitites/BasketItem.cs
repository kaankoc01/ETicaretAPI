using ETicaretAPI.Domain.Entitites.Common;

namespace ETicaretAPI.Domain.Entitites
{
    public class BasketItem : BaseEntity
    {
        public int Quantity { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid BasketId { get; set; }
        public Basket Basket { get; set; }
    }
}
