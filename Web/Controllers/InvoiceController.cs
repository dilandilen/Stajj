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
            var viewModel = new InvoiceListModel
            {
                Invoices = faturalar.Data
            };
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult CreateInvoice()
        {
            var model = new InvoiceModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateInvoice(InvoiceModel model)
        {

            var entity = new Invoice
            {
       InvoiceSerialNo= model.InvoiceSerialNo,
      InvoiceOrderNo= model.InvoiceOrderNo,
Date=DateTime.Now,
TaxAdministration=model.TaxAdministration,
Clock = DateTime.Now.ToString("HH:mm"),
Sum=model.Sum,
Received=model.Received,
Delivered=model.Delivered,

        };
            _ınvoiceService.Create(entity);
            return RedirectToAction("Index");


        }
        [HttpGet]
        
        public ActionResult InvoicePenDetail(int id)
        {
            var fatura =_ınvoiceService.GetByIdWithItems(id);
            var values =_ınvoiceItemService.GetInvoiceItemsByInvoice(id).Data.ToList();
            var viewModel = new InvoiceItemandInvoiceModel
            {
                Invoice = fatura.Data,
              InvoiceItems = values
            }; return View(viewModel);
        }
    }
}
