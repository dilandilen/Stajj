using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IPersonelService _personelService;
        private readonly ICustomerService _customerService;
        public ActionResult Index()
        {
           

            return View();
        }
    }
}
