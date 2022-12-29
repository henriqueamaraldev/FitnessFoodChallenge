using MongoDB.Bson.Serialization.Attributes;
using Repository.enums;

namespace Repository.models
{
    public class Product : BaseModel
    {
        [BsonElement("Code")]
        public long Code { get; set; }

        [BsonElement("BarCode")]
        public string BarCode { get; set; } = null!;

        [BsonElement("Status")]
        public Status Status { get; set; }

        [BsonElement("Imported_at")]
        public DateTime Imported_at { get; set; }

        [BsonElement("Url")]
        public string Url { get; set; } = null!;

        [BsonElement("ProductName")]
        public string ProductName { get; set; } = null!;

        [BsonElement("Quantity")]
        public string Quantity { get; set; } = null!;

        [BsonElement("Categories")]
        public string Categories { get; set; } = null!;

        [BsonElement("Packaging")]
        public string Packaging { get; set; } = null!;

        [BsonElement("Brands")]
        public string Brands { get; set; } = null!;

        [BsonElement("ImageUrl")]
        public string ImageUrl { get; set; } = null!;

    }
}
