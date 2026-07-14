using E_Commerce.Application.Params;
using E_Commerce.Domain.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Specifications
{
    public class ProductSpecifications : BaseSpecifications<Product, int>
    {
        public ProductSpecifications(ProductQueryParams queryParams) 
            :base(p=>(!queryParams.brandId.HasValue || p.BrandId == queryParams.brandId) && (!queryParams.typeId.HasValue || p.TypeId == queryParams.typeId)
            && (string.IsNullOrEmpty(queryParams.searchValue) || p.Name.ToLower().Contains(queryParams.searchValue.ToLower()) ) )
        {
            AddInclude(p => p.Brand);
            AddInclude(p => p.Type);
            // Sorting
            switch(queryParams.sort)
            {
                case ProductSortingOptions.NameAsc:AddOrderBy(p => p.Name); break;
                case ProductSortingOptions.NameDesc: AddOrderByDesc(p => p.Name); break;
                case ProductSortingOptions.PriceAsc: AddOrderBy(p => p.Price); break;
                case ProductSortingOptions.PriceDesc: AddOrderByDesc(p => p.Price); break;
                default: /*AddOrderBy(p => p.Name);*/ break;
            }
            ApplyPagination(queryParams.PageSize,queryParams.PageIndex);
        }
        public ProductSpecifications(int id):base(p=>p.Id == id)
        {
            AddInclude(p => p.Brand);
            AddInclude(p => p.Type);
        }
    }
}
