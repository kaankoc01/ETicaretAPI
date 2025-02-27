﻿using ETicaretAPI.Domain.Entitites.Identity;

namespace ETicaretAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken(int second, AppUser appUser);
        string CreateRefreshToken();

    }
}
