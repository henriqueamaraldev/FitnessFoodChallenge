using Repository.models;

namespace Repository.Models.Interfaces
{
    public interface IProductsCollection
    {
        Task<Product> GetByIdAsync(string id);

        Task<PaginatedResult<Product>> GetPaginatedAsync(PaginatedRequest request);

        Task<bool> ProductExists(string id);

        Task UpdateProductAsync(Product product);

        Task AddProductAsync(Product product);
    }
}
