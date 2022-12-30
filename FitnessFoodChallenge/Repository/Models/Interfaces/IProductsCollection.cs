using Repository.models;

namespace Repository.Models.Interfaces
{
    public interface IProductsCollection
    {
        Task<Product> GetByIdAsync(long id);

        Task<PaginatedResult<Product>> GetPaginatedAsync(PaginatedRequest request);

        Task<bool> ProductExists(long id);

        Task UpdateProductAsync(Product product);

        Task AddProductAsync(Product product);
    }
}
