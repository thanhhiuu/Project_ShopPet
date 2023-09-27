using EstoreWeb.Models;
using Microsoft.AspNetCore.Mvc;
using EstoreWeb.HelpCode;
using Microsoft.EntityFrameworkCore;

namespace EstoreWeb.Areas.Customer.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly ApplicationDBContext db;

        public CartController(ApplicationDBContext _db, ILogger<CartController> logger)
        {
            _logger = logger;
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
       public IActionResult AddToCart()
       {
            return View();
       }
    }
}
