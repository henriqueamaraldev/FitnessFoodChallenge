using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Repository.models
{
    public abstract class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public long Id { get; private set; }
    }
}
