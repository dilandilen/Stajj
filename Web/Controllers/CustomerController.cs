using Microsoft.AspNetCore.Mvc;
using Web.Models; 
using Entity;
using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin,Admin1")]

    public class CustomerController : Controller

    {

        ICustomerService _customerService;
        ISaleTransService _saleTransService;
        public CustomerController(ICustomerService customerService, ISaleTransService saleTransService)
        {
            _customerService = customerService;
            _saleTransService = saleTransService;
        }

        public ActionResult Index()
        {
            var customers = _customerService.GetAll().Data;
           
            return View(customers);
        }

        [HttpGet]
        public ActionResult CustomerCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustomerCreate(Customer model)
        {

            var result=  _customerService.Create(model);
            if (result.Success)
            {
             return RedirectToAction("Index");
            } return BadRequest();
        }

        [HttpGet]
        public ActionResult CustomerUpdate(int id)
        {
            var customer = _customerService.GetById(id);

            if (customer.Success)
            { return View(customer.Data);
            }
            return BadRequest();
          
        }

        [HttpPost]
        public IActionResult CustomerUpdate(Customer model)
        {
           
               
               
                _customerService.Update(model);

                return RedirectToAction("Index");

            

        
        }
        [HttpPost]
        public IActionResult CustomerDelete(int customerId)
        {
            var entity = _customerService.GetById(customerId);


            var result = _customerService.Delete(entity.Data);
            if (result.Success)
            {

                return RedirectToAction("Index");
            }
            return BadRequest(result.Message);
        }


        [HttpGet]
        public IActionResult CustomerSales(int id)
        {
            var customer = _customerService.GetByIdWithSales(id);
            if (customer.Success)
            {
                ViewBag.customer = customer.Data.Name;
                var customerSales = _saleTransService.GetSalesByCustomer(id);
 
                

                return View(customerSales.Data);
            }
            return BadRequest();
            
        }


    }
}
