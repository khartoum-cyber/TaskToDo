using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return View(_db.Tasks.ToList());
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert([Bind("TaskId,Name")]ToDoTask task)
        {
            _db.Add(task);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public ToDoTaskVM GetAll()
        {
            List<ToDoTask> taskList = _db.Tasks.ToList();

            return new ToDoTaskVM
            {
                ToDoTasksList = taskList,
            };
        }

        //[HttpPost]
        //public IActionResult Delete(int id)
        //{
        //    var task = new ToDoTask() { TaskId = id };
        //    _db.Remove(task);
        //    _db.SaveChangesAsync();

        //    return Redirect("http://localhost:5024/");
        //}

        //public IActionResult Update(int id)
        //{
        //    ToDoTaskVM obj = new()
        //    {
        //        ToDoTask = _db.Tasks.AsNoTracking().FirstOrDefault(u => u.TaskId == id)
        //    };

        //    return View(obj);
        //}

        //[HttpPost]
        //public IActionResult Update(ToDoTaskVM task)
        //{
        //    _db.Update(task.ToDoTask);
        //    _db.SaveChanges();

        //    return Redirect("http://localhost:5024/");
        //}
    }
}