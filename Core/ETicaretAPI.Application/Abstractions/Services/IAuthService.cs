using ETicaretAPI.Application.Abstractions.Services.Authentication;

namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface IAuthService : IInternalAuthentication, IExternalAuthentication
    {
        
    }
}
