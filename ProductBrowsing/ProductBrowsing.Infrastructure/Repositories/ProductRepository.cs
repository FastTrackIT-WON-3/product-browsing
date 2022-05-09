using Microsoft.EntityFrameworkCore;
using ProductBrowsing.Core.Abstractions.Repositories;
using ProductBrowsing.Core.Models;
using ProductBrowsing.Infrastructure.Entities;
using ProductBrowsing.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBrowsing.Infrastructure.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _dbContext;

        public ProductRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext
                ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<List<Product>> GetAllAsync()
        {
            List<ProductEntity> products = await _dbContext
                .Products.Include(p => p.Category)
                .ToListAsync();

            return products.Select(c => c.FromEntity()).ToList();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            ProductEntity product = await _dbContext
                .Products.Include(p => p.Category)
                .FirstOrDefaultAsync(c => c.Id == id);

            return product.FromEntity();
        }

        public async Task<bool> CreateAsync(int categoryId, string productName)
        {
            CategoryEntity category = await _dbContext.Categories
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category is null)
            {
                return false;
            }

            ProductEntity entity = new ProductEntity
            {
                Name = productName,
                Category = category
            };

            _dbContext.Products.Add(entity);

            int rowsAffected = await _dbContext.SaveChangesAsync();

            return rowsAffected == 1;
        }

        public async Task<bool> UpdateAsync(int productId, int updatedCategoryId, string updatedProductName)
        {
            ProductEntity productEntity = await _dbContext.Products
                .FirstOrDefaultAsync(c => c.Id == productId);

            if (productEntity is null)
            {
                return false;
            }

            CategoryEntity updatedCategory = await _dbContext.Categories
                .FirstOrDefaultAsync(c => c.Id == updatedCategoryId);

            if (updatedCategory is null)
            {
                return false;
            }

            productEntity.Name = updatedProductName;
            productEntity.Category = updatedCategory;

            _dbContext.Update(productEntity);

            int affectedRows = await _dbContext.SaveChangesAsync();

            return affectedRows == 1;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            ProductEntity product = await _dbContext.Products
                .FirstOrDefaultAsync(c => c.Id == id);

            if (product is not null)
            {
                _dbContext.Remove(product);

                int affectedRows = await _dbContext.SaveChangesAsync();

                return affectedRows == 1;
            }

            return false;
        }
    }
}
