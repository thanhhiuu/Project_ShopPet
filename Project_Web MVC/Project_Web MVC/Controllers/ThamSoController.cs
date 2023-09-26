using Microsoft.AspNetCore.Mvc;
using Project_Web_MVC.Models;

namespace Project_Web_MVC.Controllers
{
    public class ThamSoController : Controller
    {


        // Nhận tham số với Request
        public IActionResult Index()
        {
            var name = Request.Query["hoten"];
            var age = Request.Query["tuoi"];

            var msg = "Chao ban den " + name + " - Tuoi " + age + " voi ASP.NET CORE MVC";
            return Content(msg);
        }


        // Nhận giá trị tham số bằng đối số của action methods
        public IActionResult Index1(string hoten, int tuoi)
        {
            //var name = Request.Query["hoten"];
            //var age = Request.Query["tuoi"];

            var msg = "Chao ban den " + hoten + " - Tuoi " + tuoi + " voi ASP.NET CORE MVC";
            return Content(msg);
        }

        // Nhận tham số bằng Model
        public IActionResult Index2(Profile pf)
        {
            //var name = Request.Query["hoten"];
            //var age = Request.Query["tuoi"];

            var msg = "Chao ban den " + pf.hoten + " - Tuoi " + pf.tuoi + " voi ASP.NET CORE MVC";
            return Content(msg);
        }
    }
}
