using ProductBrowsing.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductBrowsing.Core.Abstractions.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);

        Task<bool> CreateAsync(int categoryId, string productName);

        Task<bool> UpdateAsync(
            int productId,
            int updatedCategoryId,
            string updatedProductName);

        Task<bool> DeleteAsync(int id);
    }
}
