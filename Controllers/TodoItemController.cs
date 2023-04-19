using Microsoft.AspNetCore.Mvc;

public class UpdateBody {
    public string Name {set;get;} = "Name example";
    public bool IsComplete {set;get;} = true;
}

[ApiController]
[Route("[controller]")]
public class TodoItemsController : ControllerBase
{
    private readonly TodoItemRepository _repository;

    public TodoItemsController(IConfiguration config)
    {
        _repository = new TodoItemRepository(config.GetConnectionString("MyDb") ?? "mongodb://localhost:27017/MyDb");
    }

    [HttpGet]
    public IEnumerable<TodoItem> Get()
    {
        return _repository.GetAll();
    }

    [HttpGet("{id}")]
    public TodoItem Get(string id)
    {
        return _repository.GetById(id);
    }

    [HttpPost]
    public TodoItem Post([FromBody] TodoItem item)
    {
        return _repository.Add(item);
    }

    [HttpPut("{id}")]
    public dynamic Put(string id, [FromBody] TodoItem item)
    {
        return _repository.Update(id, item );
    }

    [HttpDelete("{id}")]
    public void Delete(string id)
    {
        _repository.Delete(id);
    }
}
