﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Repository.models
{
    public abstract class BaseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
    }
}
