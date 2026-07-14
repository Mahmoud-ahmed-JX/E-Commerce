using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.Baskets;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace E_Commerce.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer connection)
        {
            _database = connection.GetDatabase();
        }
        public async Task<CustomerBasket?> CreateOrUpdateAsync(CustomerBasket basket, TimeSpan? TimeToLive = null, CancellationToken ct = default)
        {
            var json = JsonSerializer.Serialize(basket);
            Console.WriteLine($"Serialized basket: {json}");
            var success = await _database.StringSetAsync(basket.Id, json, TimeToLive ?? TimeSpan.FromDays(30));
            return success ? basket : null;
        }

        public async Task<bool> DeleteBasketAsync(string basketId, CancellationToken ct = default)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<CustomerBasket?> GetBasketAsync(string basketId, CancellationToken ct = default)
        {
            var basket = await _database.StringGetAsync(basketId);
            if (string.IsNullOrEmpty(basket)) return null;
            return JsonSerializer.Deserialize<CustomerBasket>(basket.ToString());
        }
    }
}
