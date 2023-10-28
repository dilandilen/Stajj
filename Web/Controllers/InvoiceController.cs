using Business.Abstract;
using Business.Concrete;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.Models;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]

    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _ınvoiceService;
        private readonly IInvoiceItemService _ınvoiceItemService;

        public InvoiceController(IInvoiceService ınvoiceService,IInvoiceItemService ınvoiceItemService)
        {
            _ınvoiceService = ınvoiceService;
            _ınvoiceItemService = ınvoiceItemService;
        }
        public IActionResult Index()
        {
            var faturalar = _ınvoiceService.GetAll();
            if(faturalar.Success)
            return View(faturalar.Data);
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult CreateInvoice()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateInvoice(Invoice model)
        {
            model.Clock = DateTime.Now.ToString("HH:mm");

         _ınvoiceService.Create(model);
            return RedirectToAction("Index");


        }
        [HttpGet]
        
        
        public ActionResult InvoicePenDetail(int id)
        {
            var values = _ınvoiceItemService.GetInvoiceItemsByInvoice(id).Data.ToList();

            return View(values);

        }
    }
}
