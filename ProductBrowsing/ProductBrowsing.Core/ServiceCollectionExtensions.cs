using Microsoft.Extensions.DependencyInjection;
using ProductBrowsing.Core.Abstractions.Services;
using ProductBrowsing.Core.Services;

namespace ProductBrowsing.Core
{
    public static class ServiceCollectionExtensions
    {
        public static void AddProductBrowsingServices(
            this IServiceCollection services)
        {
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();
        }
    }
}
