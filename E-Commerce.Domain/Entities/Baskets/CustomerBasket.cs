using E_Commerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Domain.Entities.Baskets
{
    public class CustomerBasket : BaseEntity<string>
    {
        public ICollection<BasketItems> Items { get; set; } = [];
    }
}
