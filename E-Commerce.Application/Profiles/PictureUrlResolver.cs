using AutoMapper;
using E_Commerce.Application.DTOs.Product;
using E_Commerce.Domain.Entities.ProductEntities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Profiles
{
    public class PictureUrlResolver(IOptions<UrlSettings> options) : IValueResolver<Product, ProductDto, string?>
    {
        private readonly UrlSettings _urlSettings = options.Value;
        public string? Resolve(Product source, ProductDto destination, string? destMember, ResolutionContext context)
        {
            if(string.IsNullOrEmpty(source.PictureUrl))
            {
                return null;
            }
            var BaseUrl = _urlSettings.BaseUrl.TrimEnd("/");
            var path = source.PictureUrl.TrimStart("/");
            
            return $"{BaseUrl}/Files/{path}";
        }
    }

    public class UrlSettings
    {
        public string BaseUrl { get; set; } = string.Empty;
    }
}
