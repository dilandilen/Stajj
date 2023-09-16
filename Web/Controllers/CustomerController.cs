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
            var customers = _customerService.GetAll();
            var viewModel = new CustomerListModel
            {
                Customers = customers.Data
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult CustomerCreate()
        {
            var model = new CustomerModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult CustomerCreate(CustomerModel model)
        {

            var customer = new Customer
            {
                Name = model.Name,
                SurName = model.SurName,
                Email = model.Email,
                Phone = model.Phone,
                Adress = model.Adress,
                IsDelete = false

        };
          var result=  _customerService.Create(customer);
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
            {
                var model = new CustomerModel
                {
                    CustomerId = customer.Data.CustomerId,
                    Name = customer.Data.Name,
                    SurName = customer.Data.SurName,
                    Email = customer.Data.Email,
                    Phone = customer.Data.Phone,
                    Adress = customer.Data.Adress
                };

                return View(model);
            }
            return BadRequest();
          
        }

        [HttpPost]
        public IActionResult CustomerUpdate(CustomerModel model)
        {
           
                var customer = _customerService.GetById(model.CustomerId);
                if (customer.Success)
            {
                customer.Data.Name = model.Name;
                customer.Data.SurName = model.SurName;
                customer.Data.Email = model.Email;
                customer.Data.Phone = model.Phone;
                customer.Data.Adress = model.Adress;
                _customerService.Update(customer.Data);

                return RedirectToAction("Index");

            }

            return BadRequest();
        
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

                var customerSales = _saleTransService.GetSalesByCustomer(id);
 
                var viewModel = new CustomerSalesModel
                {
                    Customer = customer.Data,
                    SaleTransactions = customerSales.Data
                };

                return View(viewModel);
            }
            return BadRequest();
            
        }


    }
}
