using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class TodoItem
{
    [BsonElement("_id")]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId ?Id { get; set; }
    public string ?Name { get; set; }
    public bool IsComplete { get; set; }
}