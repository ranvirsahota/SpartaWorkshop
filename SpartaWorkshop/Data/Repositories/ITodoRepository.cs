using SpartaWorkshop.Models;

namespace SpartaWorkshop.Data.Repositories
{
    public interface ITodoRepository
    {
        IQueryable<Todo> TodoItems { get; }
        Todo? GetTodoById(int id);
        void AddTodo(Todo todo);
        void UpdateTodo(Todo todo);
        void RemoveTodo(Todo todo);
    }
}