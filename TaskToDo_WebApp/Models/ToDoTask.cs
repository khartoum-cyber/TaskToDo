using System.ComponentModel.DataAnnotations;

namespace TaskToDo_WebApp.Models
{
    public class ToDoTask
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
