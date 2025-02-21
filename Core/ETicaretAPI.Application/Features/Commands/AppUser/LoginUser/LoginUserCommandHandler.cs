using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<Domain.Entitites.Identity.AppUser> _userManager;
        private readonly SignInManager<Domain.Entitites.Identity.AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;


        public LoginUserCommandHandler(UserManager<Domain.Entitites.Identity.AppUser> userManager, SignInManager<Domain.Entitites.Identity.AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }
        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entitites.Identity.AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);

            if(user == null)
                throw new NotFoundUserException();

           SignInResult result =  await _signInManager.CheckPasswordSignInAsync(user,request.Password,false);
            if (result.Succeeded) // eğer burası başarılıysa , authentication başarılı oldu demek.
            {
                // .. yetkiler burada belirlenir

              Token token  = _tokenHandler.CreateAccessToken(250);
                return new LoginUserSuccessCommandResponse()
                {
                    Token = token
                };

            }
            //return new LoginUserErrorCommandResponse()
            //{
            //    Message = "Kullanıcı adı veya şifre hatalı"
            //};
            throw new AuthenticationExceptionError();
        }
    }

}
