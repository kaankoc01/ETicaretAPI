namespace ETicaretAPI.Domain.Entitites
{
    public class ProductImageFile : File
    {
       
        // çoktan çoğa ilişki
        public ICollection<Product> Products { get; set; }
    }
}
