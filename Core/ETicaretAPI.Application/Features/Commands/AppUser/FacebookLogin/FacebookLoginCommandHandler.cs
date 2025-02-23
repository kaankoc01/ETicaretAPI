using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.DTOs.Facebook;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace ETicaretAPI.Application.Features.Commands.AppUser.FacebookLogin
{
    public class FacebookLoginCommandHandler : IRequestHandler<FacebookLoginCommandRequest, FacebookLoginCommandResponse>
    {
        private readonly UserManager<Domain.Entitites.Identity.AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;
        private readonly HttpClient _httpClient;

        public FacebookLoginCommandHandler(UserManager<Domain.Entitites.Identity.AppUser> userManager, ITokenHandler tokenHandler, IHttpClientFactory httpClientFactory)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _httpClient = httpClientFactory.CreateClient();
        }



        public async Task<FacebookLoginCommandResponse> Handle(FacebookLoginCommandRequest request, CancellationToken cancellationToken)
        {
            string accessTokenResponse = await _httpClient.GetStringAsync($"https://graph.facebook.com/oauth/access_token?client_id=1530550920970970&client_secret=ab13d836f277151bca4cfdea905401ce&grant_type=client_credentials");

            FacebookAccessTokenResponse facebookAccessTokenResponse = JsonSerializer.Deserialize<FacebookAccessTokenResponse>(accessTokenResponse);

            string userAccessTokenValidation = await _httpClient.GetStringAsync($"https://graph.facebook.com/debug_token?input_token={request.AuthToken}&access_token={facebookAccessTokenResponse.accessToken}");

            FacebookUserAccessTokenValidation validation = JsonSerializer.Deserialize<FacebookUserAccessTokenValidation>(userAccessTokenValidation);
            if (validation.Data.IsValid)
            {
                string userInfo = await _httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=email,name&access_token={request.AuthToken}");
                FacebookUserInfo facebookUserInfo = JsonSerializer.Deserialize<FacebookUserInfo>(userInfo);

                var info = new UserLoginInfo("FACEBOOK", validation.Data.UserId, "FACEBOOK");
                var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                
                if (user == null)
                {
                    user = await _userManager.FindByEmailAsync(facebookUserInfo.Email);
                    if (user == null)
                    {
                        user = new Domain.Entitites.Identity.AppUser
                        {
                            Id = Guid.NewGuid().ToString(),
                            Email = facebookUserInfo.Email,
                            UserName = facebookUserInfo.Email,
                            NameSurname = facebookUserInfo.Name,
                        };
                        var identityResult = await _userManager.CreateAsync(user);
                        if (!identityResult.Succeeded)
                        {
                            var errors = string.Join(", ", identityResult.Errors.Select(e => e.Description));
                            throw new Exception($"Kullanıcı oluşturulamadı: {errors}");
                        }
                    }
                    var addLoginResult = await _userManager.AddLoginAsync(user, info);
                    if (!addLoginResult.Succeeded)
                    {
                        throw new Exception("AddLogin failed: " + string.Join(", ", addLoginResult.Errors));
                    }
                }
                // Token oluştur ve dön
                return new()
                {
                    Token = _tokenHandler.CreateAccessToken(5)
                };

            }

            throw new Exception("Invalid External authentication");
        }
    }


}
