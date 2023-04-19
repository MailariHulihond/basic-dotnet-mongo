using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

public class TodoItemRepository
{
    private readonly IMongoCollection<TodoItem> _collection;

    public TodoItemRepository(string connectionString)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("MyDb");
        _collection = database.GetCollection<TodoItem>("TodoItems");
    }

    public IEnumerable<TodoItem> GetAll()
    {
        return _collection.Find(_ => true).ToList();
    }

    public TodoItem GetById(string id)
    {
        return _collection.Find(item => item.Id == ObjectId.Parse(id)).FirstOrDefault();
    }

    public TodoItem Add(TodoItem item)
    {
        _collection.InsertOne(item);
        return item;
    }

   public TodoItem Update(string id, TodoItem item)
{
    var filter = Builders<TodoItem>.Filter.Eq("_id", ObjectId.Parse(id));
    var update = Builders<TodoItem>.Update
        .Set("Name", item.Name)
        .Set("IsComplete", item.IsComplete);
    var options = new FindOneAndUpdateOptions<TodoItem>{ReturnDocument = ReturnDocument.After};
    return _collection.FindOneAndUpdate(filter, update, options);
}
    public void Delete(string id)
    {
        _collection.DeleteOne(item => item.Id == ObjectId.Parse(id));
    }
}
