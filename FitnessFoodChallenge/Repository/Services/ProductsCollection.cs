using MongoDB.Driver;
using Repository.models;
using Microsoft.Extensions.Options;
using Repository.settings;

namespace Repository.services
{
    public class ProductsCollection
    {
        private readonly IMongoCollection<Product> _productCollection;

        public ProductsCollection(IOptions<ProductDbConfigs> productServices)
        {
            var mongoClient = new MongoClient(productServices.Value.ConnString);
            var mongoDatabase = mongoClient.GetDatabase(productServices.Value.DatabaseName);
            _productCollection = mongoDatabase.GetCollection<Product>(productServices.Value.ProductCollectionName);
        }

        public async Task<Product> GetByIdAsync(long id)
        {
            return await _productCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<PaginatedResult<Product>> GetPaginatedAsync(PaginatedRequest request)
        {
            var result = await _productCollection.Find(x => true)
                .Skip((request.Page - 1) * request.PageSize)
                .Limit(request.PageSize)
                .ToListAsync();
            var count = _productCollection.CountDocuments(x => true);
            return new PaginatedResult<Product>(request, count, result);
        }
    }
}
