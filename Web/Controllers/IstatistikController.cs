using Business.Abstract;
using Business.Concrete;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin,Admin1")]

    public class IstatistikController : Controller
    {
        ICustomerService _customerService; IProductService _productservice;IPersonelService _personelService;ICategoryService _categoryService;
 ISaleTransService _saleTransService;
        public IstatistikController(ICustomerService customerService, IProductService productservice, IPersonelService personelService, ICategoryService categoryService,ISaleTransService saleTransService)
        {
            _customerService = customerService;
            _productservice = productservice;
            _personelService = personelService;
            _categoryService = categoryService;
            _saleTransService = saleTransService;
        }
        public IActionResult Index()
        { 
            int a = _customerService.GetAll().Data.Count();
            ViewBag.value1 = a;
            
            int B = _productservice.GetAll().Data.Count();
            ViewBag.value2 = B;
            
            int c = _personelService.GetAll().Data.Count();
            ViewBag.value3 = c;
          
            int d = _categoryService.GetAll().Data.Count();
            ViewBag.value4 = d;
            
            int e = _productservice.GetTotalStock();
            ViewBag.value5 = e;

            int f= _productservice.GetProductsByLowStock(80).Data.Count();
            ViewBag.value6 = f;

            int g = _productservice.GetBrandCount();
            ViewBag.value7 = g;
            
            var x =_productservice.GetAll().Data.OrderByDescending(p => p.Selling_price).FirstOrDefault();
            string  y = x.ProductName;
            ViewBag.value8 = y;
            var z = _productservice.GetAll().Data.OrderBy(p => p.Selling_price).FirstOrDefault();
            y = z.ProductName;
            ViewBag.value9 = y;
            var deger10=_productservice.GetAll().Data.GroupBy(p=>p.Brandname).OrderByDescending(z=>z.Count()).Select(p=>p.Key).FirstOrDefault();
            ViewBag.value10 = deger10;

            var l =_personelService.GetAll().Data.Sum(p=>p.Salary);
            ViewBag.value11 = l;
            var mostProfitableProduct = _productservice.GetAll().Data
    .OrderByDescending(p => p.Selling_price - p.Cost_price) 
    .FirstOrDefault();

            string productName = mostProfitableProduct?.ProductName ?? "Bilgi Yok";

            ViewBag.value12 = productName;
            var deger13=_saleTransService.GetAll().Data.Sum (s=>s.TotalAmount).ToString();
            ViewBag.value14 = deger13;
            var deger14=_saleTransService.GetAll().Data.GroupBy(x=>x.ProductId).OrderByDescending(z=>z.Count()).Select(Y=>Y.Key).FirstOrDefault();
            var product = _productservice.GetById(deger14);
            ViewBag.value13 = product.Data.ProductName;

            DateTime now = DateTime.Now;  
            var degerz = _saleTransService.GetCount(x => x.Date.Date == now.Date).ToString();
            ViewBag.value15 = degerz;
            var degery = _saleTransService
                .GetAll(x => x.Date >= now.Date && x.Date < now.Date.AddDays(1))  
                .Data
                .Sum(Y => Y.TotalAmount)
                .ToString();

            ViewBag.value16 = degery;


            return View();

        }
        public IActionResult SimpleTables()
        {
            var cityCustomerCounts = _customerService.GetAll().Data
                .GroupBy(c => c.Adress)
                .Select(group => new CityCustomerCountModel
                {
                    Adress = group.Key,
                    CustomerCount = group.Count(),
                })
                .ToList();

            return View(cityCustomerCounts);
        }
      



    }
}
