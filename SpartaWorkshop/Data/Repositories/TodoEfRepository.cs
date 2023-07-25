using SpartaWorkshop.Models;

namespace SpartaWorkshop.Data.Repositories
{
    public class TodoEfRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoEfRepository(TodoContext context)
        {
            _context = context;
        }

        public IQueryable<Todo> TodoItems => _context.TodoItems;

        public void AddTodo(Todo todo)
        {
            _context.TodoItems.Add(todo);
            _context.SaveChanges();
        }

        public Todo? GetTodoById(int id)
        {
            return _context.TodoItems.Find(id);
        }

        public void RemoveTodo(Todo todo)
        {
            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
        }

        public void UpdateTodo(Todo todo)
        {
            _context.TodoItems.Update(todo);
            _context.SaveChanges();
        }
    }
}
