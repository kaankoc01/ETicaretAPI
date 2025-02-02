using ETicaretAPI.Domain.Entitites.Common;

namespace ETicaretAPI.Domain.Entitites
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        // 1 siparişte n tane ürün olabilir , 1 ürünün n tane siparişi olabilir çoktan çoğa ürün - orders ilişkisi
        public string Description { get; set; }
        public string Address { get; set; }
        // çoka çok ilişki burada product'ı , productta orderı
        public ICollection<Product> Products { get; set; }
       // 1 e çok ilişki
        public Customer Customer { get; set; }
        
    }
}
