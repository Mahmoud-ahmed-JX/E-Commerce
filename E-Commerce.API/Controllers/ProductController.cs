using E_Commerce.Application.Common;
using E_Commerce.Application.Contracts;
using E_Commerce.Application.DTOs.Product;
using E_Commerce.Application.Params;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    
    public class ProductController : ApiBaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductDto>>> GetProducts([FromQuery]ProductQueryParams queryParams,CancellationToken ct = default)
        {
            var result = await _productService.GetProductsAsync(queryParams,ct);
            return ToActionResult(result);
        }
        [HttpGet("Brands")]
        public async Task<ActionResult<IReadOnlyList<BrandDto>>> GetBrands(CancellationToken ct = default)
        {
            var result = await _productService.GetBrandsAsync(ct);
            return ToActionResult(result);
        }
        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<TypeDto>>> GetTypes(CancellationToken ct = default)
        {
            var result = await _productService.GetTypesAsync(ct);
            return ToActionResult(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id,CancellationToken ct)
        {
            var result = await _productService.GetProductByIdAsync(id, ct);
            return ToActionResult(result);
        }
    }
}
