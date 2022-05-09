using ProductBrowsing.Core.Models;
using ProductBrowsing.Mvc.Models;
using System;

namespace ProductBrowsing.Mvc.Extensions
{
    public static class ProductExtensions
    {
        public static ProductViewModel ToViewModel(this Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.Category?.Id ?? 0,
                CategoryName = product.Category?.Name
            };
        }
    }
}
