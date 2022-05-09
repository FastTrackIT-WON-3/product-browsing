using Microsoft.Extensions.DependencyInjection;
using ProductBrowsing.Core.Abstractions.Repositories;
using ProductBrowsing.Infrastructure.Repositories;

namespace ProductBrowsing.Infrastructure
{
    public static class ServiceCollectionInfrastructureExtensions
    {
        public static void AddProductBrowsingRepositories(
                this IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
