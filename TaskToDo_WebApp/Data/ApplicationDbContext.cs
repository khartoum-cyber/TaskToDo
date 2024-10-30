using Microsoft.EntityFrameworkCore;
using TaskToDo_WebApp.Models;

namespace TaskToDo_WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ToDoTask> Tasks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
