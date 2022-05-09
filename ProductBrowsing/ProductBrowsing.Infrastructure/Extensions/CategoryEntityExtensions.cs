using ProductBrowsing.Core.Models;
using ProductBrowsing.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBrowsing.Infrastructure.Extensions
{
    public static class CategoryEntityExtensions
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
