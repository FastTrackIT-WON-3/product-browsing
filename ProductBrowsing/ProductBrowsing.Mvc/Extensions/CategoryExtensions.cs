using ProductBrowsing.Core.Models;
using ProductBrowsing.Mvc.Models;
using System;

namespace ProductBrowsing.Mvc.Extensions
{
    public static class CategoryExtensions
    {
        public static CategoryViewModel ToViewModel(this Category category)
        {
            if (category is null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            return new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
