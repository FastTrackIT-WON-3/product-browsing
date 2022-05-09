using ProductBrowsing.Core.Models;
using ProductBrowsing.Infrastructure.Entities;

namespace ProductBrowsing.Infrastructure.Extensions
{
    internal static class ProductEntityExtensions
    {
        public static Product FromEntity(this ProductEntity entity)
        {
            if (entity is not null)
            {
                return new Product
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Category = new Category
                    {
                        Id = entity.Category?.Id ?? 0,
                        Name = entity.Category?.Name
                    }
                };
            }

            return null;
        }
    }
}
