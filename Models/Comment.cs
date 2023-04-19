using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Comment {

    [BsonElement("_id")]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId ?Id {get;set;} = null!;

    public string Text {get; set;} = null!;

}