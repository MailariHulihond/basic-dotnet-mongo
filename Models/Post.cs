
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Post {

    [BsonElement("_id")]
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public ObjectId ?Id {set; get;} = null!;

    public string title {set; get;} = null!;

    public List<Comment> ?comments {set;get;}

}