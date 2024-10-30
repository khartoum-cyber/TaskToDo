using System.ComponentModel.DataAnnotations;

namespace TaskToDo_WebApp.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
