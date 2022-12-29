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

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productCollection.Find(x => true).ToListAsync();
        }
    }
}
