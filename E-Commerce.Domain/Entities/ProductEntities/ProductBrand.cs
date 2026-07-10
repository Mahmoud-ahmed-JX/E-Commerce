using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Domain.Entities.ProductEntities
{
    public class ProductBrand : BaseEntity<int>
    {
        public string Name { get; set; } = null!;
    }
}
