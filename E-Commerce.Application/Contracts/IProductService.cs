using E_Commerce.Application.Common;
using E_Commerce.Application.DTOs.Product;
using E_Commerce.Application.Params;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Contracts
{
    public interface IProductService
    {
        Task<Result<IReadOnlyList<ProductDto>>> GetProductsAsync(ProductQueryParams queryParams, CancellationToken ct = default);
        Task<Result<IReadOnlyList<BrandDto>>> GetBrandsAsync(CancellationToken ct = default);
        Task<Result<IReadOnlyList<TypeDto>>> GetTypesAsync(CancellationToken ct = default);
        Task<Result<ProductDto>> GetProductByIdAsync(int id, CancellationToken ct = default);

    }
}
