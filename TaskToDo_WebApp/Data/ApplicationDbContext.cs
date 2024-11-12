using Microsoft.EntityFrameworkCore;
using TaskToDo_WebApp.Models;

namespace TaskToDo_WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ToDoTask> Tasks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var taskList = new[]
            {
                new ToDoTask { TaskId = 1, Name = "Go to work", DateAdded = DateTime.Parse("1984-3-13") },
                new ToDoTask { TaskId = 2, Name = "Clean house", DateAdded = DateTime.Parse("1959-4-15") },
            };

            modelBuilder.Entity<ToDoTask>().HasData(taskList);
        }
    }
}
