using ProductBrowsing.Core.Models;
using ProductBrowsing.Infrastructure.Entities;

namespace ProductBrowsing.Infrastructure.Extensions
{
    internal static class CategoryEntityExtensions
    {
        public static Category FromEntity(this CategoryEntity entity)
        {
            if (entity is not null)
            {
                return new Category
                {
                    Id = entity.Id,
                    Name = entity.Name
                };
            }

            return null;
        }
    }
}
