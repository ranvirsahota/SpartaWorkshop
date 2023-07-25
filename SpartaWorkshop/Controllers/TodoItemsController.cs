using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpartaWorkshop.Data.Repositories;
using SpartaWorkshop.Models;

namespace SpartaWorkshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodoItemsController(ITodoRepository repository)
        {
            _repository = repository;        
        }



        [HttpGet]
        public ActionResult<List<Todo>> GetTodoList()
        {
            return _repository.TodoItems.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Todo> GetTodo(int id)
        {
            var todo = _repository.GetTodoById(id);
            if (todo == null) { return NotFound(); }
            return todo;
        }

        [HttpPost]
        public ActionResult<Todo> PostTodo(Todo todo)
        {
            _repository.AddTodo(todo);
            return CreatedAtAction(nameof(GetTodo), new {id = todo.Id}, todo);
        }

        [HttpPut("{id}")]
        public IActionResult PutTodo(int id, Todo todo)     
        {
            if (id != todo.Id) return BadRequest();
            _repository.UpdateTodo(todo);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteTodo(int id)
        {
            var todo = _repository.GetTodoById(id);
            if (todo == null) return NotFound();
            _repository.RemoveTodo(todo);
            return NoContent();

        }
    }
}