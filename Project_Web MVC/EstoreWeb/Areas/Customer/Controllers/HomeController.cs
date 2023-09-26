using EstoreWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EstoreWeb.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = SD.Role_Customer)]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext db;

        public HomeController(ApplicationDBContext _db, ILogger<HomeController> logger)
        {
            _logger = logger;
            db = _db;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageIndex;
            if (page == null)
            {
                pageIndex = 1;
            }
            else
            {
                pageIndex = (int)page;
            }
            var dsCategory = db.Products.Include(x => x.Category).ToList();

            // Thống kê số trang có thể có
            var PageSum = dsCategory.Count / pageSize + (dsCategory.Count % pageSize > 0 ? 1 : 0);

            // Truyền pageSum qua view 
            ViewBag.PageSum = PageSum;  
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageIndex = pageIndex;
            // Phân trang theo pageindex và pagesize
            return View(dsCategory.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());

        }

        public IActionResult Privacy()
        {
            return View();
        }



        public IActionResult Detail(int id)
        {
            var obj = db.Products.Find(id);
            ViewBag.Product = db.Products.Where(w => w.CategoryId == obj.CategoryId && w.Id != obj.Id).ToList();
            if (obj == null)
                return NotFound();
            return View(obj);
        }
        //public async Task<IActionResult> Detail(int id)
        //{

        //    // Sử dụng async/await để lấy product
        //    var product = await applicationDBContext.Products.FindAsync(id);

        //    // Khởi tạo model
        //    var model = new ProductViewModel();
        //    model.Product = product;

        //    // Lấy sản phẩm liên quan
        //    model.RelatedProducts = await GetRelatedProducts(product);

        //    return View(model);

        //}

        //// Hàm lấy sản phẩm liên quan
        //private async Task<List<Product>> GetRelatedProducts(Product product)
        //{
        //    return await applicationDBContext.Products
        //      .Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id)
        //      .Take(5)
        //      .ToListAsync();
        //}







        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}