using Microsoft.AspNetCore.Mvc;
using TaskToDo_WebApp.Data;
using TaskToDo_WebApp.Models;
using TaskToDo_WebApp.Models.ViewModel;

namespace TaskToDo_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var toDoListViewModel = GetAll();
            return View(toDoListViewModel);
        }

        [HttpPost]
        public RedirectResult Insert(ToDoTaskVM task)
        {
            _db.Add(task.ToDoTask);
            _db.SaveChangesAsync();

            return Redirect("http://localhost:5024/");
        }

        public ToDoTaskVM GetAll()
        {
            List<ToDoTask> taskList = _db.Tasks.ToList();

            return new ToDoTaskVM
            {
                ToDoTasksList = taskList,
            };
        }
    }
}
