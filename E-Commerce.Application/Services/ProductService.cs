using AutoMapper;
using E_Commerce.Application.Common;
using E_Commerce.Application.Contracts;
using E_Commerce.Application.DTOs.Product;
using E_Commerce.Application.Params;
using E_Commerce.Application.Specifications;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<IReadOnlyList<BrandDto>>> GetBrandsAsync(CancellationToken ct = default)
        {
            var brands = await _unitOfWork.GetRepository<ProductBrand,int>().GetAllAsync(ct);
            var mappedBrands = _mapper.Map<IReadOnlyList<BrandDto>>(brands);
            return Result<IReadOnlyList<BrandDto>>.Ok(mappedBrands);
        }
        public async Task<Result<IReadOnlyList<ProductDto>>> GetProductsAsync(ProductQueryParams queryParams, CancellationToken ct = default)
        {
            ProductSpecifications spec = new ProductSpecifications(queryParams);
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllWithSpecificationAsync(spec,ct);
            var mappedProducts = _mapper.Map<IReadOnlyList<ProductDto>>(products);
            return Result<IReadOnlyList<ProductDto>>.Ok(mappedProducts);
        }

        public async Task<Result<IReadOnlyList<TypeDto>>> GetTypesAsync(CancellationToken ct = default)
        {
            var types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync(ct);
            var mappedTypes = _mapper.Map<IReadOnlyList<TypeDto>>(types);
            return Result<IReadOnlyList<TypeDto>>.Ok(mappedTypes);
        }

        public async Task<Result<ProductDto>> GetProductByIdAsync(int id, CancellationToken ct = default)
        {
            var spec = new ProductSpecifications(id);
            var product = await _unitOfWork.GetRepository<Product,int>().GetByIdWithSpecificationsAsync(spec, ct);
            if(product is null)
                return Result<ProductDto>.Fail(Error.NotFound("Product not found", $"The product with the specified Id: {id} was not found."));
            var mappedProduct = _mapper.Map<ProductDto>(product);
            return Result<ProductDto>.Ok(mappedProduct);
        }

    }
}
