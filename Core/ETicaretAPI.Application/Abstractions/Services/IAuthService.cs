using ETicaretAPI.Application.Abstractions.Services.Authentication;

namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface IAuthService : IInternalAuthentication, IExternalAuthentication
    {
        Task PasswordResetAsync(string email);
        Task<bool> VerifyResetTokenAsync(string resetToken , string userId);
    }
}
