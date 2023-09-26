using EstoreWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstoreWeb.Controllers
{


    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CaregoryController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public CaregoryController(ApplicationDBContext _applicationDBContext)
        {
            _dbContext = _applicationDBContext;
        }
        public IActionResult Index()
        {
            var dsCaregory = _dbContext.Categories.ToList();
            return View(dsCaregory);
        }

        // Add
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            // Insert obj to table Categories
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(obj);
                _dbContext.SaveChanges();
                TempData["success"] = "Thêm thành công";
                return RedirectToAction("Index");
            }
            return View();

        }
        // Edit
        public IActionResult Edit(int id) {
            // Truy vấn category theo id
            var edit = _dbContext.Categories.Find(id);
            //var edit1 = _dbContext.Categories.SingleOrDefault(x => x.Id == id);
            //var edit2 = _dbContext.Categories.Where(x => x.Id == id).SingleOrDefault();

            // Trả về view để Edit
            if(edit == null)
            
                return NotFound();
            
            return View(edit);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            // Edit obj to table Categories
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(obj);

                //_dbContext.Entry<Category>(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();
                TempData["success"] = "Cập nhật thành công";

                return RedirectToAction("Index");
            }
            return View();
        }

        // Delete
        public IActionResult Delete(int id)
        {
            // Truy vấn theo id
            var objCategory = _dbContext.Categories.Find(id);
            if (objCategory == null)
            {
                return NotFound();
            }
            // Trả về View Edit
            return View(objCategory);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            // Truy vấn theo id
            var objCategory = _dbContext.Categories.Find(id);
            if (objCategory == null)
            {
                return NotFound();
            }
            _dbContext.Categories.Remove(objCategory);
            _dbContext.SaveChanges();
            TempData["success"] = "Category deleted success";
            return RedirectToAction("Index");
        }
    }
}
