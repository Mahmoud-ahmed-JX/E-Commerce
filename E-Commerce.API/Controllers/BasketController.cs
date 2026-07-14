using E_Commerce.Application.Contracts;
using E_Commerce.Application.DTOs.Baskets;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    public class BasketController : ApiBaseController
    {
        private readonly IBasketService basketService;

        public BasketController(IBasketService basketService)
        {
            this.basketService = basketService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BasketDto>> GetBasket(string id, CancellationToken ct = default)
        {
            var result = await basketService.GetBasketAsync(id, ct);
            return ToActionResult(result);
        }

        [HttpPost]
        public async Task<ActionResult<BasketDto>> CreateOrUpdateBasket(BasketDto basket,CancellationToken ct = default)
        {
            var result = await basketService.CreateOrUpdateBasketAsync(basket, ct);
            return ToActionResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBasket(string id, CancellationToken ct = default)
        {
            var result = await basketService.DeleteBasketAsync(id, ct);
            return ToActionResult(result);
        }
    }
}
