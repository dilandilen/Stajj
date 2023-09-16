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
            var categories = _categoryService.GetAll().Data;


            var lastNProducts = products
                .OrderByDescending(p => p.ProductId)
                .Take(5)
                .ToList();

            ViewBag.newproduct = lastNProducts;

            return View(new ProductCategoryModel()
            {
                Product = new ProductListModel
                {
                    Products = products
                },
                CAT = new CategoryListViewModel
                {
                    Categories = categories,
                    
                }
            });
        }
        [AllowAnonymous]

        public ActionResult ProductList(int id)
        {
           var category= _categoryService.GetByIdWithProducts(id).Data;
            var productsInCategory = _productService
                .GetAllWithCategories()
                .Data
                .Where(p => p.ProductCategories.Any(pc => pc.CategoryID == id))
                .ToList();
            return View(new ProductCategoryModel()
            {
                Product = new ProductListModel
                {
                    Products = productsInCategory
                },
                CATCategory = new CategoryModel
                {
                    CategoryAd = category.CategoryName,

                }
            });
        }


        public ActionResult CategoryList()
        {
            var category = _categoryService.GetAllCategoryWithProduct().Data;
            return View(new CategoryListViewModel() { Categories = category });
        }

        public ActionResult ProductDetails(int id)

        {
            var product = _productService.GetByIdWithCategories(id);
            if (product.Success)
            {
                var model = new ProductModel
                {
                    ProductName = product.Data.ProductName,
                    ProductId = product.Data.ProductId,
                    Cost_price = product.Data.Cost_price,
                    Selling_price = product.Data.Selling_price,
                    imgurl = product.Data.imgurl,
                    Stock = product.Data.Stock,
                    Brandname = product.Data.Brandname,
                    State = product.Data.State,

                };

                return View(model);
            }
            return BadRequest();

        }
        /*  
          public ActionResult Product()
          {

              return View();
          }*/
        [AllowAnonymous]

        [HttpPost]
        public ActionResult Search(string keyword)
        {
            var matchingProducts = _productService.GetAllWithCategories().Data.Where(p => p.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            p.Brandname.Contains(keyword, StringComparison.OrdinalIgnoreCase))
             .OrderBy(p => p.ProductName).ThenBy(p => p.Brandname).ToList();

            return View(new ProductListModel()
            {
                Products = matchingProducts
            })
                ;

        }
    }
}
