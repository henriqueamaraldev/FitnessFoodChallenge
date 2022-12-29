using Repository.models;

namespace Application.Interfaces
{
    public interface IProductsServices
    {
        Task<Product> GetProductsByIdAsync(long id);
        Task<List<Product>> GetAllProductsAsync();
    }
}
