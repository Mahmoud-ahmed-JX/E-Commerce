using AutoMapper;
using E_Commerce.Application.Common;
using E_Commerce.Application.Contracts;
using E_Commerce.Application.DTOs.Baskets;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.Baskets;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public BasketService(IBasketRepository basketRepository,IMapper mapper )
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }
        public async Task<Result<BasketDto>> CreateOrUpdateBasketAsync(BasketDto basket, CancellationToken ct = default)
        {
            var mappedBasket = mapper.Map<CustomerBasket>(basket);
            var result = await basketRepository.CreateOrUpdateAsync(mappedBasket);
            return result is not null ? Result<BasketDto>.Ok(basket) :
                Result<BasketDto>.Fail(new Error("Failure","Basket could not be created or updated."));
        }

        public async Task<Result> DeleteBasketAsync(string id, CancellationToken ct = default)
        {
            var result = await basketRepository.DeleteBasketAsync(id, ct);
            if(!result)
            {
                return Result.Fail(new Error("Failure", "Basket could not be deleted."));
            }
            return Result.Ok();
        }

        public async Task<Result<BasketDto>> GetBasketAsync(string id, CancellationToken ct = default)
        {
            var basket = await basketRepository.GetBasketAsync(id, ct);
            if(basket is null)
            {
                return Result<BasketDto>.Fail(new Error("NotFound", "Basket not found."));
            }
            return Result<BasketDto>.Ok(mapper.Map<BasketDto>(basket));
        }
    }
}
