using E_Commerce.Application.Params;
using E_Commerce.Domain.Common;
using E_Commerce.Domain.Entities.ProductEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Specifications
{
    public class ProductCountSpecifications : BaseSpecifications<Product,int>
      
    {
        public ProductCountSpecifications(ProductQueryParams queryParams)
            :base(p=>(!queryParams.brandId.HasValue || p.BrandId == queryParams.brandId) && (!queryParams.typeId.HasValue || p.TypeId == queryParams.typeId)
            && (string.IsNullOrEmpty(queryParams.searchValue) || p.Name.ToLower().Contains(queryParams.searchValue.ToLower()) ) )
        {
            
        }
    }
}
