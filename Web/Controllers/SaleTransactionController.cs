using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Models; 
using Entity;
using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin,Admin1,Admin2")]

    public class SaleTransactionController : Controller
    {
        //burda satış ekleme istemiyorum şu an müşteri nişey aldığında otomatik olarak eklensin bir de burdaki fiyat kısmını ürünün fiyatına entegre etmem lazım
        private readonly ISaleTransService _saleTransactionService;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly IPersonelService _personelService;

        public SaleTransactionController(ISaleTransService saleTransactionService, IProductService productService, ICustomerService customerService, IPersonelService personelService)
        {
            _saleTransactionService = saleTransactionService;
            _productService = productService;
            _customerService = customerService;
            _personelService = personelService;
        }

        public IActionResult Index()
        {
            var sales = _saleTransactionService.Getallswrelate();
            var viewModel = new SaleTransactionListModel
            {
                SaleTransactions = sales.Data
            };
            return View(viewModel);


        }
        [HttpGet]
        public IActionResult SalesAdd()
        {
            var personel = _personelService.GetAll().Data
                .Select(e => new SelectListItem
                {
                    Text = $"{e.Name} {e.SurName}",
                    Value = e.PersonelId.ToString()
                })
                .ToList();
            ViewBag.VPersonel = new SelectList(personel, "Value", "Text");

            var customers = _customerService.GetAll().Data
                .Select(c => new SelectListItem
                {
                    Text = $"{c.Name} {c.SurName}",
                    Value = c.CustomerId.ToString()
                })
                .ToList();
            ViewBag.VCustomer = new SelectList(customers, "Value", "Text");

            var products = _productService.GetAll().Data
                .Select(p => new SelectListItem
                {
                    Text = p.ProductName,
                    Value = p.ProductId.ToString()
                })
                .ToList();
            ViewBag.VProduct = new SelectList(products, "Value", "Text");

            return View();
        }

        [HttpPost]
        public IActionResult SalesAdd(SaleTransactionModel salesMove)
        {
            var product=_productService.GetById(salesMove.ProductId).Data;
            var sales = new SaleTransaction
            {
                Date = DateTime.Now,
                Quantity = salesMove.Quantity,
                Price = product.Selling_price,
                TotalAmount = salesMove.Quantity * product.Selling_price,



            };


            _saleTransactionService.Create(sales, salesMove.ProductId, salesMove.CustomerId, salesMove.PersonelId);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult SalesUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sales = _saleTransactionService.GetByIdWithAllRelatives((int)id);
                 if (sales == null)
            {
                return NotFound();
            }
            ViewBag.Product = _productService.GetAll();
            ViewBag.Personel = _personelService.GetAll();
            ViewBag.Customer = _customerService.GetAll();
            var model = new SaleTransactionModel
            {
                ProductId = sales.Data.ProductId,
                CustomerId = sales.Data.CustomerId,
                PersonelId = sales.Data.PersonelId,
                Price = sales.Data.Price,
                Date= sales.Data.Date,
                TotalAmount = sales.Data.TotalAmount,
                Quantity = sales.Data.Quantity,
                Product = sales.Data.Product,
                Customer = sales.Data.Customer,
                Personel = sales.Data.Personel
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult SalesUpdate(SaleTransactionModel model)
        {
            var sales = _saleTransactionService.GetByIdWithAllRelatives(model.SalesId);
            sales.Data.Price = model.Price;
            sales.Data.TotalAmount = model.TotalAmount;
            sales.Data.Quantity = model.Quantity;
            sales.Data.Date=model.Date;
            _saleTransactionService.Update(sales.Data, sales.Data.ProductId, sales.Data.CustomerId, sales.Data.PersonelId);
          return RedirectToAction("Index");


        }
    }
}   