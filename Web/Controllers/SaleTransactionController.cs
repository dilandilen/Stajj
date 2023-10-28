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
           
            return View(sales.Data);


        }
        [HttpGet]
        public IActionResult SalesAdd()
        {
            List<SelectListItem> urunler = (from x in _productService.GetAll().Data.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ProductName,
                                                Value = x.ProductId.ToString()
                                            }).ToList();
            List<SelectListItem> cariler = (from x in _customerService.GetAll().Data.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.Name + " " + x.SurName,
                                                Value = x.CustomerId.ToString()
                                            }).ToList();
            List<SelectListItem> personeller = (from x in _personelService.GetAll().Data.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Name + " " + x.SurName,
                                                    Value = x.PersonelId.ToString()
                                                }).ToList();
            ViewBag.VProduct = urunler;
            ViewBag.VCustomer = cariler;
            ViewBag.Vpersonel = personeller;

            return View();
        }

        [HttpPost]
        public IActionResult SalesAdd(SaleTransaction salesMove)
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
            

            return View(sales);
        }
        [HttpPost]
        public IActionResult SalesUpdate(SaleTransaction model)
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