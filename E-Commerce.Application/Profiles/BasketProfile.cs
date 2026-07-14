using AutoMapper;
using E_Commerce.Application.DTOs.Baskets;
using E_Commerce.Domain.Entities.Baskets;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Application.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketItems, BasketItemDto>().ReverseMap();
            CreateMap<CustomerBasket, BasketDto>().ReverseMap();
        }
    }
}
