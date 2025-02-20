using ETicaretAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<Domain.Entitites.Identity.AppUser> _userManager;
        private readonly SignInManager<Domain.Entitites.Identity.AppUser> _signInManager;

        public LoginUserCommandHandler(UserManager<Domain.Entitites.Identity.AppUser> userManager, SignInManager<Domain.Entitites.Identity.AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entitites.Identity.AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);

            if(user == null)
                throw new NotFoundUserException("Kullanıcı veya şifre hatalı.");

           SignInResult result =  await _signInManager.CheckPasswordSignInAsync(user,request.Password,false);
            if (result.Succeeded) // eğer burası başarılıysa , authentication başarılı oldu demek.
            {
                // .. yetkilerburada belirlenecek.
            }

            return new();
        }
    }

}
