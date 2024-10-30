using Microsoft.AspNetCore.Mvc;

namespace TaskToDo_WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
