namespace IofThings.Data.Common.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public abstract class BaseDbModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}