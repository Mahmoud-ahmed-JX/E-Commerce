using E_Commerce.Domain.Contracts;
using E_Commerce.Infrastructure.Data.Contexts;
using E_Commerce.Infrastructure.Seeding;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.API.Extensions
{
    public static class ProgramExtensions
    {
        public static async Task SeedAndMigrateAsync(this IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredKeyedService<IDataSeeder>("Catalog");

            await seeder.SeedAsync();
        }
    }
}
