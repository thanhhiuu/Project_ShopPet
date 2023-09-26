using Microsoft.AspNetCore.Mvc;
using Project_Web_MVC.Models;
using System.Collections;
using System.Diagnostics;

namespace Project_Web_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Action trả về chuỗi hgiá trị
        public IActionResult Typer1 ()
        {
            var data = "Chao bạn đến với ASP.NER";
            return Content(data);
        }
        // Action trả về du lieu dinh dang theo cấu trúc JSON
        public IActionResult Typer2()
        {
            var data = new {name="Thanh Hieu", Age=19};
            return Json(data);
        }
        public IActionResult Typer3()
        {
            ArrayList data = new ArrayList();
            data.Add(new { name = "Thanh Hieu", Age = 19 });
            data.Add(new { name = "Hau Hieu", Age = 19 });
            data.Add(new { name = "Dai Hieu", Age = 19 });

            return Json(data);
        }
        public IActionResult Typer4()
        {
            
            return View();
        }

        // PartialView trả về đúng layout của Typer5 không sử dụng layout có sẵn
        public IActionResult Typer5()
        {

            return PartialView();
        }

        // Điều hướng người dùng đến action kkhác trong ứng dụng
        public IActionResult Typer6()
        {
            // b1. Tiếp nhận yêu câu
            // b2. Xử lý yêu cầu
            // b3. Điều hướng chạy qua cotroller khác
            return RedirectToAction("Index", "News");
        }
        // Điều hướng đế địa chi web bên ngoài
        public IActionResult Typer7()
        {
            return Redirect("https://chat.openai.com/?model=text-davinci-002-render-sha"); ;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}