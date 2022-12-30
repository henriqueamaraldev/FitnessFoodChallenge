using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Repository.enums;

namespace Repository.models
{
    public class Product : BaseModel
    {
        [BsonElement("code")]
        public long Code { get; set; }

        [BsonElement("barcode")]
        public string BarCode { get; set; } = null!;

        [BsonElement("status")]
        public Status Status { get; set; }

        [BsonElement("imported_t")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Imported_at { get; set; }

        [BsonElement("url")]
        public string Url { get; set; } = null!;

        [BsonElement("product_name")]
        public string ProductName { get; set; } = null!;

        [BsonElement("quantity")]
        public string Quantity { get; set; } = null!;

        [BsonElement("categories")]
        public string Categories { get; set; } = null!;

        [BsonElement("packaging")]
        public string Packaging { get; set; } = null!;

        [BsonElement("brands")]
        public string Brands { get; set; } = null!;

        [BsonElement("image_url")]
        public string ImageUrl { get; set; } = null!;

    }
}
