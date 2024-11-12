using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskToDo_WebApp.Data;
using TaskToDo_WebApp.Models;

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

        [HttpGet]
        public IActionResult Index(string searchDate)
        {
            if (_db.Tasks == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tasks'  is null.");
            }

            var tasks = from t in _db.Tasks
                select t;

            if (!string.IsNullOrEmpty(searchDate))
            {
                tasks = tasks.Where(t => t.DateAdded == Convert.ToDateTime(searchDate));
            }

            return View(tasks.ToList());
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(ToDoTask task)
        {
            if (ModelState.IsValid)
            {
                _db.Add(task);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(task);
        }

        //get
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = _db.Tasks
                .FirstOrDefault(t => t.TaskId == id);

            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _db.Tasks.Find(id);

            if (task != null)
            {
                _db.Tasks.Remove(task);
            }

            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        //get
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = _db.Tasks.Find(id);

            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, ToDoTask task)
        {
            if (id != task.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(task);
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.TaskId))
                    {
                        return NotFound();
                    }

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        private bool TaskExists(int? id)
        {
            return _db.Tasks.Any(t => t.TaskId == id);
        }
    }
}