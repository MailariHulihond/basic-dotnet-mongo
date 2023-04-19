using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("[controller]")]
public class PostController: ControllerBase {
    private readonly PostRepository _repository;

    public PostController(IConfiguration config){
        _repository = new PostRepository(config.GetConnectionString("MyDb") ?? "mongodb://localhost:27017/MyDb");
    }

[HttpGet]
    public async Task<IEnumerable<Post>> Get(){
        return await _repository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Post> Get(string id)
    {
        return await _repository.GetById(id);
    }

    [HttpPost]
    public async Task<Post> Post([FromBody] Post item)
    {
        return await _repository.Create(item);
    }

    [HttpPut("{id}")]
    public async Task<Post> Put(string id, [FromBody] Post item)
    {
        return await _repository.Update(id, item );
    }

    [HttpDelete("{id}")]
    public async void Delete(string id)
    {
        await _repository.Delete(id);
    }

}