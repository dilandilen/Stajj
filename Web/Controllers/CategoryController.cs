using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
                var viewModel = new CategoryListViewModel
                {
                    Categories = categories.Data
                };
                return View(viewModel);
            }
            return BadRequest(categories.Message);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
          
                var entity = new Category
                {
                    CategoryName = model.CategoryAd,
                };
            
            var result=    _categoryService.Create(entity);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();

        }

        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var category = _categoryService.GetByIdWithProducts(id);
            if (category == null)
            {
                return NotFound();
            }

            var model = new CategoryModel
            {
                CategoryID = category.Data.CategoryID,
                CategoryAd = category.Data.CategoryName,
                Products = category.Data.ProductCategories?.Select(pc => pc.Product)?.ToList() 

            };

            return View(model);
        }


        [HttpPost]
        public IActionResult EditCategory(CategoryModel model, IFormFile file)
        {
            var entity = _categoryService.GetById(model.CategoryID);
            if (entity == null)
            {
                return NotFound();
            }

            entity.Data.CategoryName = model.CategoryAd;

            if (file != null && file.Length > 0)
            {


                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine("wwwroot", "images", uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                entity.Data.Imgurl = "/images/" + uniqueFileName; 
            }

          var result=  _categoryService.Update(entity.Data);
            if (result.Success)
            {
                return RedirectToAction("Index");
            }return BadRequest(result);
        }

        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);

            
              var result=  _categoryService.Delete(entity.Data);
            if (result.Success)
            {

                return RedirectToAction("Index");
            }return BadRequest(result.Message);
        }
        [HttpPost]
        public IActionResult DeleteFromCategory(int categoryId, int productId)
        {
            _categoryService.DeleteFromCategory(categoryId, productId);
            return Redirect("/admin/editcategory/" + categoryId);
        }
        public PartialViewResult _Categories()
        {
            return PartialView(new CategoryListViewModel() { Categories = _categoryService.GetAllCategoryWithProduct().Data })
;        }
    }
   
}
