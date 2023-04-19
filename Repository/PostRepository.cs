using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

public class PostRepository
{
    private readonly IMongoCollection<Post> _collection;

    public PostRepository(string connectionString)
    {
         var client = new MongoClient(connectionString);
        var database = client.GetDatabase("MyDb");
        _collection = database.GetCollection<Post>("posts");
    }

    public async Task<Post> Create(dynamic post)
    {
        await _collection.InsertOneAsync(post);
        return post;
    }

    public async Task<Post> GetById(string id)
    {
        var filter = Builders<Post>.Filter.Eq("_id", ObjectId.Parse(id));
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Post>> GetAll()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<Post> Update(string id, Post post)
    {
        post.Id = ObjectId.Parse(id);
        var filter = Builders<Post>.Filter.Eq("_id", ObjectId.Parse(id));
        await _collection.ReplaceOneAsync(filter, post);
        return post;
    }

    public async Task Delete(string id)
    {
        var filter = Builders<Post>.Filter.Eq("_id", ObjectId.Parse(id));
        await _collection.DeleteOneAsync(filter);
    }
}