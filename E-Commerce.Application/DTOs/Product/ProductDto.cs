using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.DTOs.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string PictureUrl { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public string TypeName { get; set; } = null!;

    }
}
