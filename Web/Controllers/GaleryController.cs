using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin,Admin1")]

    public class GaleryController : Controller
    {
        ICategoryService _categoryService;
        public GaleryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var categories = _categoryService.GetAll();
            if (categories.Success)
            {
                
                return View(categories.Data);
            }
            return BadRequest();
        }
    }
}
