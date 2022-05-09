using ProductBrowsing.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductBrowsing.Core.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();

        Task<Category> GetByIdAsync(int id);

        Task<Category> CreateAsync(string name);

        Task<bool> UpdateAsync(int id, string updatedName);

        Task<bool> DeleteAsync(int id);
    }
}
