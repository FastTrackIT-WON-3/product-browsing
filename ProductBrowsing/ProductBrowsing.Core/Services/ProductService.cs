using ProductBrowsing.Core.Abstractions.Repositories;
using ProductBrowsing.Core.Abstractions.Services;
using ProductBrowsing.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductBrowsing.Core.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<Product>> GetAllAsync()
        {
            List<Product> allProducts = await _repository.GetAllAsync();
            return allProducts;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            Product product = await _repository.GetByIdAsync(id);
            return product;
        }

        public async Task<bool> CreateAsync(
            int categoryId,
            string productName)
        {
            if (categoryId <= 0)
            {
                throw new ArgumentException(nameof(categoryId));
            }

            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentNullException(nameof(productName));
            }

            bool createdSuccesfully = await _repository.CreateAsync(categoryId, productName);
            return createdSuccesfully;
        }

        public async Task<bool> UpdateAsync(
            int productId,
            int updatedCategoryId,
            string updatedProductName)
        {
            if (productId <= 0)
            {
                throw new ArgumentException(nameof(productId));
            }

            if (updatedCategoryId <= 0)
            {
                throw new ArgumentException(nameof(updatedCategoryId));
            }

            if (string.IsNullOrEmpty(updatedProductName))
            {
                throw new ArgumentNullException(nameof(updatedProductName));
            }

            bool updateSucceeded = await _repository.UpdateAsync(
                productId,
                updatedCategoryId,
                updatedProductName);

            return updateSucceeded;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            bool deleteSucceeded = await _repository.DeleteAsync(id);
            return deleteSucceeded;
        }
    }
}
