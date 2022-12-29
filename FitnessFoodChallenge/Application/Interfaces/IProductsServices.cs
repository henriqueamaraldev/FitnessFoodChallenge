using Repository.models;

namespace Application.Interfaces
{
    public interface IProductsServices
    {
        Task<Product> GetProductsByIdAsync(long id);
        Task<PaginatedResult<Product>> GetPaginatedProductsAsync(PaginatedRequest request);
    }
}
