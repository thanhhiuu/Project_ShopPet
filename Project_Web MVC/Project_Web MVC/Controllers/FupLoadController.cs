using Microsoft.AspNetCore.Mvc;

namespace Project_Web_MVC.Controllers
{
    public class FupLoadController : Controller
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public FupLoadController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment =   hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upload(IFormFile fUpLoad)
        {
            if(fUpLoad != null)
            {
                string filename = Guid.NewGuid().ToString() +Path.GetExtension(fUpLoad.FileName);
                string path = Path.Combine(_hostingEnvironment.WebRootPath, @"uploads");
                fUpLoad.CopyTo(new FileStream(Path.Combine(path, filename), FileMode.Create));
                ViewData["SUCCESS"] = "Đã up file thành công";
                return View("Index");
            }
            ViewData["FAIL"] = "Đã up file thất bại";

            return View("Index");
        }

    }
}
