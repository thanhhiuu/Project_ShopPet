using Microsoft.AspNetCore.Mvc;

namespace Project_Web_MVC.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
