using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class CustomerPanel : Controller
    {
       

        private IProductService _productService;
        private ICategoryService _categoryService;

        public CustomerPanel(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        [AllowAnonymous]

        public IActionResult Index()
        {
            var products = _productService.GetAll().Data;





            return View(products);
        }
        [AllowAnonymous]

        public ActionResult ProductList(int id)
        {
            var productsInCategory = _productService.Getbycategory(id);
              

          return View(productsInCategory.Data);
        }


        public ActionResult CategoryList()
        {
            var category = _categoryService.GetAllCategoryWithProduct().Data;
            return View(category);
        }

        public ActionResult ProductDetails(int id)

        {
            var product = _productService.GetByIdWithCategories(id);
            if (product.Success)
            {


                return View(product.Data);
            }
            return BadRequest();

        }
        
        [AllowAnonymous]

        [HttpPost]
        public ActionResult Search(string keyword)
        {
            var matchingProducts= _productService.Search(keyword);

            return View(matchingProducts.Data);
            
                

        }
     
    }
}
