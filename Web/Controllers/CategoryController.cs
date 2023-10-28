using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web.Models;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin,Admin1,Admin2")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public CategoryController(ICategoryService categoryService, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _categoryService = categoryService;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            if (categories.Success)
            {

                return View(categories.Data);
            }
            return BadRequest(categories.Message);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category model)
        {


            var result = _categoryService.Create(model);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();

        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var category = _categoryService.GetByIdWithProducts(id).Data;
          
            ViewBag.Products = category.ProductCategories?.Select(pc => pc.Product)?.ToList();
            return View(category);
        }


        [HttpPost]
        public IActionResult EditCategory(Category model, IFormFile file)
        {
            var result = _categoryService.Update(model, file);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);


            var result = _categoryService.Delete(entity.Data);
            if (result.Success)
            {

                return RedirectToAction("Index");
            }
            return BadRequest(result.Message);
        }
    }
   
}
