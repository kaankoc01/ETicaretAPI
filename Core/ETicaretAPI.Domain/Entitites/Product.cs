using ETicaretAPI.Domain.Entitites.Common;

namespace ETicaretAPI.Domain.Entitites
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        // çoka çok ilişki burada order'ı , orderda productı
       // public ICollection<Order> Orders { get; set; }
        // bir ürünün birden fazla resmi olabilir ,//
        // çoktan çoğa ilişki
        public ICollection<ProductImageFile> ProductImageFiles { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }


    }
}
