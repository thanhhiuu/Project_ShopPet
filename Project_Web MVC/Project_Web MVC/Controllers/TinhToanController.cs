using Microsoft.AspNetCore.Mvc;
using Project_Web_MVC.Models;

namespace Project_Web_MVC.Controllers
{
    public class TinhToanController : Controller
    {

        // Tiếp nhận tham số theo dạng 2: sử dụng đối sô
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult XuLy(double num1, double num2, string op)
        {
            double kq = 0;
            switch (op)
            {
                case "+": kq = num1 + num2;
                    break;
                case "-":
                    kq = num1 + num2;
                    break;
                case "*":
                    kq = num1 * num2;
                    break;
                case "/":
                    kq = num1 / num2;
                    break;
                default:
                    break;
            }
            // Truyền dữ liệu cho view
            ViewBag.KQ = kq;
            ViewBag.num1 = num1;
            ViewBag.num2 = num2;
            ViewBag.op = op;

            return View("Index");
        }




        // Tiếp nhận tham số theo dạng 3: sử dụng Model

        public IActionResult Tinh()
        {
            return View();
        }
        public IActionResult XuLy1(MayTinhModel m)
        {
            double kq = 0;
            switch (m.op)
            {
                case "+":
                    kq = m.num1 + m.num2;
                    break;
                case "-":
                    kq = m.num1 - m.num2;
                    break;
                case "*":
                    kq = m.num1 * m.num2;
                    break;
                case "/":
                    kq = m.num1 / m.num2;
                    break;
                default:
                    break;
            }
            // Truyền dữ liệu cho view
            ViewBag.KQ = kq;
            ViewBag.num1 = m.num1;
            ViewBag.num2 = m.num2;
            ViewBag.op = m.op;
            return View("Tinh");
        }
    }
}
