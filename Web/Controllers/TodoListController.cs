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

            var viewModel = new TodoListViewModel
            {
               TodoLists=todo.Data,
            };
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult TodoListAdd()
        {

            return View();
        }

        [HttpPost]
        public ActionResult TodoListAdd(TodoListModel model)
        {
            var entity = new TodoList
            {
               Title  = model.Title,
               Hour=model.Hour,
               Status=true,
               Date=model.Date,

            };
            _todoListService.Create(entity);
            return RedirectToAction("Index");

        }

    }
}
