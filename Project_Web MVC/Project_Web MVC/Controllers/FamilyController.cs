using Microsoft.AspNetCore.Mvc;
using Project_Web_MVC.Models;
using System.Reflection;

namespace Project_Web_MVC.Controllers
{
    public class FamilyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult My()
        {
            // Gửi data qua View
            ViewBag.HoTen = "Nguyen Thanh Hieu";
            ViewBag.Tuoi = 90;
            ViewBag.NgheNghiep = "Ban hang";
            ViewData["Hinh"] = "VS.jpg";
            return View();
        }
        public IActionResult Member()
        {
            var ds = new List<Models.MemberInfo>();
            ds.Add(new Models.MemberInfo { HoTen = "Nguyen thanh binh", Tuoi = 90, QuanHe = "Cha", Hinh = "VS.jpg", NgheNghiep = "Nong" });
            ds.Add(new Models.MemberInfo { HoTen = "Phan thi minh", Tuoi = 90, QuanHe = "Me", Hinh = "VS.jpg", NgheNghiep = "Nong" });
            ds.Add(new Models.MemberInfo { HoTen = "Nguyen thanh hieu", Tuoi = 90, QuanHe = "con", Hinh = "VS.jpg", NgheNghiep = "Hoc sinh" });
            ds.Add(new Models.MemberInfo { HoTen = "Nguyen thanh nam", Tuoi = 90, QuanHe = "con", Hinh = "VS.jpg", NgheNghiep = "Ban hang" });

            return View(ds);
        }
    }
}
