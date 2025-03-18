namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<byte[]> QrCodeToProductAsync(string productId);
    }
}
