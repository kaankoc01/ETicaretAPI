namespace ETicaretAPI.Domain.Entitites
{
    public class ProductImageFile : File
    {
        public bool Showcase { get; set; }
        // çoktan çoğa ilişki
        public ICollection<Product> Products { get; set; }
    }
}
