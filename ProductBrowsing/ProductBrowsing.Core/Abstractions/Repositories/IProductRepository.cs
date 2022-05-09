using ProductBrowsing.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductBrowsing.Core.Abstractions.Repositories
{
    public interface IProductRepository
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
