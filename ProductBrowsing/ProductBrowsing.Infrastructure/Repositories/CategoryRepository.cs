using Microsoft.EntityFrameworkCore;
using ProductBrowsing.Core.Abstractions.Repositories;
using ProductBrowsing.Core.Models;
using ProductBrowsing.Infrastructure.Entities;
using ProductBrowsing.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductBrowsing.Infrastructure.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _dbContext;

        public CategoryRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext
                ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<Category>> GetAllAsync()
        {
            List<CategoryEntity> categories = await _dbContext
                .Categories
                .ToListAsync();

            return categories.Select(c => c.FromEntity()).ToList();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            CategoryEntity category = await _dbContext.Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            return category.FromEntity();
        }

        public async Task<Category> CreateAsync(string name)
        {
            CategoryEntity entity = new CategoryEntity
            {
                Name = name
            };

            _dbContext.Categories.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity.FromEntity();
        }

        public async Task<bool> UpdateAsync(int id, string updatedName)
        {
            CategoryEntity category = await _dbContext.Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category is not null)
            {
                category.Name = updatedName;

                _dbContext.Update(category);

                int affectedRows = await _dbContext.SaveChangesAsync();

                return affectedRows == 1;
            }

            return false;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            CategoryEntity category = await _dbContext.Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category is not null)
            {
                _dbContext.Remove(category);

                int affectedRows = await _dbContext.SaveChangesAsync();

                return affectedRows == 1;
            }

            return false;
        }
    }
}
