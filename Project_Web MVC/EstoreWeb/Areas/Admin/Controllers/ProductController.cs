using EstoreWeb.Models;
using EStoreWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EstoreWeb.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {

        private readonly ApplicationDBContext applicationDBContext;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnvironment;
        public ProductController(ApplicationDBContext _applicationDBContext, Microsoft.AspNetCore.Hosting.IHostingEnvironment _host)
        {
            applicationDBContext = _applicationDBContext;
            hostEnvironment = _host;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 2;
            int pageIndex;
            if (page == null)
            {
                pageIndex = 1;
            }
            else
            {
                pageIndex = (int)page;
            }
            var dsCategory = applicationDBContext.Products.Include(x => x.Category).ToList();

            // Thống kê số trang có thể có
            var PageSum = dsCategory.Count / pageSize + (dsCategory.Count % pageSize > 0 ? 1 : 0);

            // Truyền pageSum qua view 
            ViewBag.PageSum = PageSum;
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageIndex = pageIndex;
            // Phân trang theo pageindex và pagesize
            return View(dsCategory.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList());
        }
        public IActionResult Create()
        {
            // truyền danh sách thể loại cho view để sinh ra điểu khiển dropdownlist
            ViewBag.ListCategory = applicationDBContext.Categories.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name });
            return View();
        }
        [HttpPost] // actionname đổi đường dẫn đến "Create" mà không phải là Create_Post
        public IActionResult Create(Product obj, IFormFile file)
        {
            // Tiến hành thêm obj vào table product 
            // 1. Kiểm tra dữ liệu
            if (!ModelState.IsValid) // hợp lệ
            {
                if (file != null && file.Length > 0)
                {
                    // Get the file name
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string path = Path.Combine(hostEnvironment.WebRootPath, @"images/products"); // lay duong dan luu tru
                    using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                        // tự động đóng luồng
                    }                    // Save the file name to obj.ImageUrl
                    obj.ImageUrl = @"images/products/" + fileName;
                }
                applicationDBContext.Products.Add(obj);
                applicationDBContext.SaveChanges();
                TempData["Success"] = "Thêm thành công";
                return RedirectToAction("Index");
            }
            ViewBag.ListCategory = applicationDBContext.Categories.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name });
            return View();
        }

        // action xử lý edit Category
        public IActionResult Edit(int id)
        {
            // truy vấn category theo id
            var objCategory = applicationDBContext.Products.Find(id);
            if (objCategory == null)
                return NotFound();

            ViewBag.ListCategory = applicationDBContext.Categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
            return View(objCategory);
        }

        [HttpPost]
        public IActionResult Edit(Product obj, IFormFile file)
        { // Tiến hành thêm obj vào table product 
            // 1. Kiểm tra dữ liệu
            if (!ModelState.IsValid) // hợp lệ
            {
                if (file != null && file.Length > 0)
                {
                    // Get the file name
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string path = Path.Combine(hostEnvironment.WebRootPath, @"images/products"); // lay duong dan luu tru
                    using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                        // tự động đóng luồng       
                    }
                    // fUpload.CopyTo(new FileStream(Path.Combine(path, fileName), FileMode.Create)); // tien hanh sao chep len may chu
                    // đóng luồng lại

                    //Xóa ảnh củ 
                    if (!string.IsNullOrEmpty(obj.ImageUrl))
                    {
                        string imagePath = Path.Combine(hostEnvironment.WebRootPath, obj.ImageUrl);
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }

                    // Save the file name to obj.ImageUrl
                    obj.ImageUrl = @"images/products/" + fileName;

                }
                applicationDBContext.Products.Update(obj);
                //db.Update<product>(obj);
                applicationDBContext.SaveChanges();
                TempData["Success"] = "Cập nhật thành công";


                return RedirectToAction("Index");
            }
            ViewBag.ListCategory = applicationDBContext.Categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });

            return View();
        }

        public IActionResult Delete(int id)
        {
            // Truy vấn theo id
            var objCategory = applicationDBContext.Products.Find(id);
            if (objCategory == null)
            {
                return NotFound();
            }
            ViewBag.ListCategory = applicationDBContext.Categories.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });

            // Trả về View Edit
            return View(objCategory);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete_Post(Product obj, int id)
        {
            var objPro = applicationDBContext.Products.Find(id);
            if (objPro == null)
            {
                return NotFound();
            }

            //Xóa ảnh củ 
            if (!string.IsNullOrEmpty(obj.ImageUrl))
            {
                string imagePath = Path.Combine(hostEnvironment.WebRootPath, obj.ImageUrl);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            // Xoa
            applicationDBContext.Products.Remove(objPro);
            applicationDBContext.SaveChanges();
            TempData["Success"] = "Xóa thành công";

            return RedirectToAction("Index");
        }




    }
}
