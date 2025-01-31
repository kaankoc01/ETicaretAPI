using ETicaretAPI.Domain.Entitites.Common;

namespace ETicaretAPI.Domain.Entitites
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        // 1 sipariş 1 müşteriye ait olabilir , 1 müşterinin n tane siparişi olabilir 1 e çok müşteri - orders ilişkisi
        public ICollection<Order> Orders { get; set; }
    }
}
