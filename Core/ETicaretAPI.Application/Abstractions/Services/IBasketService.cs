﻿using ETicaretAPI.Application.ViewModels.Baskets;
using ETicaretAPI.Domain.Entitites;

namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface IBasketService
    {
        public Task<List<BasketItem>> GetBasketItemsAsync();
        public Task AddItemToBasketAsync(VM_Create_BasketItem basketItem);
        public Task UpdateQuantityAsync(VM_Update_BasketItem basketItem);
        public Task RemoveBasketItemAsync(string basketItemId);
        public Basket? GetUserActiveBasket { get; }

    }
}
