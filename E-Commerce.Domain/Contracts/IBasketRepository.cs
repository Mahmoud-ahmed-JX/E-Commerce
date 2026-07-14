using E_Commerce.Domain.Entities.Baskets;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace E_Commerce.Domain.Contracts
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetBasketAsync(string basketId, CancellationToken ct = default);
        Task<CustomerBasket?> CreateOrUpdateAsync(CustomerBasket basket,TimeSpan? TimeToLive = null , CancellationToken ct = default);
        Task<bool> DeleteBasketAsync(string basketId, CancellationToken ct = default);
    }
}
