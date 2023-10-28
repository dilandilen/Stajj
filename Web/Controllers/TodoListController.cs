using Business.Abstract;
using DataAccess.Abstract;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin,Admin1,Admin2")]

    public class TodoListController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly ICategoryService _categoryService;
        private readonly ITodoListService  _todoListService;
        private readonly IPersonelService _personelService;

        public TodoListController(IProductService productService, ITodoListService todoListService,ICustomerService customerService,    ICategoryService categoryService,IPersonelService personelService)
        {
            _productService = productService;
            _todoListService = todoListService;
            _customerService = customerService;
            _categoryService = categoryService;
            _personelService= personelService;
        }

        public IActionResult Index()
        {

            var deger1=_customerService.GetAll().Data.Count().ToString();
            ViewBag.d1=deger1;
            var deger2 = _personelService.GetAll().Data.Count().ToString();
            ViewBag.d2 = deger2;
            deger2=_categoryService.GetAll().Data.Count().ToString();
            ViewBag.d3 = deger2;
            var todo = _todoListService.GetAll();


            return View(todo.Data);
        }
        [HttpGet]
        public ActionResult TodoListAdd()
        {

            return View();
        }

        [HttpPost]
        public ActionResult TodoListAdd(TodoList model)
        {
            
            _todoListService.Create(model);
            return RedirectToAction("Index");

        }

    }
}
