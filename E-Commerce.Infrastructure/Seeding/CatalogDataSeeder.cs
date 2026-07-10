using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.ProductEntities;
using E_Commerce.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace E_Commerce.Infrastructure.Seeding
{
    public class CatalogDataSeeder(StoreDbContext _context, ILogger<CatalogDataSeeder> _logger) : IDataSeeder
    {
        public async Task SeedAsync(CancellationToken ct = default)
        {
            try
            {
                var pending = _context.Database.GetPendingMigrations();
                if (pending.Any())
                {
                    _logger.LogInformation("Applying {Count} pending migrations.", pending.Count());
                    await _context.Database.MigrateAsync();
                    _logger.LogInformation("Migrations applied successfully.");

                }
                else
                {
                    _logger.LogInformation("No pending migrations found.");
                }
                var path = Path.Combine(AppContext.BaseDirectory, "DataSeed");
                await SeedIfEmptyAsync<ProductBrand>(path, "brands.json", ct);
                await SeedIfEmptyAsync<ProductType>(path, "types.json", ct);
                await SeedIfEmptyAsync<Product>(path, "products.json", ct);
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        private async Task SeedIfEmptyAsync<T>(string path, string fileName, CancellationToken ct) where T : class
        {
            if (await _context.Set<T>().AnyAsync())
                return;
            var filePath = Path.Combine(path, fileName);
            if (!File.Exists(filePath))
            {
                _logger.LogWarning("File {FilePath} does not exist. Skipping seeding for {EntityType}.", filePath, typeof(T).Name);
                return;
            }
            await using var stream = File.OpenRead(filePath);
            var items = await JsonSerializer.DeserializeAsync<List<T>>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }, cancellationToken: ct);
            if(items?.Count() > 0)
            {
                await _context.Set<T>().AddRangeAsync(items, ct);
                await _context.SaveChangesAsync(ct);
                _logger.LogInformation("Seeded {Count} items for {EntityType}.", items.Count, typeof(T).Name);
            }

        }
    }
}
