using Microsoft.EntityFrameworkCore;
using SpartaWorkshop.Models;

namespace SpartaWorkshop.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base(options) 
        {
        
        }

        public DbSet<Todo> TodoItems { get; set; }
    }
}
