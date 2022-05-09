using ProductBrowsing.Core.Abstractions.Repositories;
using ProductBrowsing.Core.Abstractions.Services;
using ProductBrowsing.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductBrowsing.Core.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<Category>> GetAllAsync()
        {
            List<Category> allCategories = await _repository.GetAllAsync();
            return allCategories;
        }

        public async Task<Category> CreateAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Category createdCategory = await _repository.CreateAsync(name);
            return createdCategory;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            Category category = await _repository.GetByIdAsync(id);
            return category;
        }

        public async Task<bool> UpdateAsync(int id, string updatedName)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            if (string.IsNullOrEmpty(updatedName))
            {
                throw new ArgumentNullException(nameof(updatedName));
            }

            bool updateSucceeded = await _repository.UpdateAsync(id, updatedName);
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
