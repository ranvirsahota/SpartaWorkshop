using SpartaWorkshop.Models;

namespace SpartaWorkshop.Data.Repositories
{
    public class TodoListRepository : ITodoRepository
    {

        private static List<Todo> _todoItems = new List<Todo>
        {
            new Todo {
                Id = 1,
                Title = "Update Profile",
                Description = "Add neccessary info and a picutre"
            },
            new Todo
            {
                Id = 2,
                Title = "Install Software",
                Description = "Install Visual Studio Community Edition and Microsoft 365"
            }
        };

        public IQueryable<Todo> TodoItems => _todoItems.AsQueryable();

        public void AddTodo(Todo todo)
        {
            todo.Id = _todoItems.Last().Id + 1;
            _todoItems.Add(todo);
        }

        public Todo? GetTodoById(int id)
        {
            return _todoItems.Find(item => item.Id == id);
        }

        public void RemoveTodo(Todo todo)
        {
            _todoItems.Remove(todo);
        }

        public void UpdateTodo(Todo todo)
        {
            var index = _todoItems.FindIndex(item => item.Id == todo.Id);
            _todoItems[index] = todo;
        }
    }
}