using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Web.Models;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Business.Concrete;

namespace Web.Controllers
{

    [Authorize(Roles = "Admin,Admin1,Admin2")]

    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAllWithCategories();
            if (products.Success)
                return View(products.Data);
            else return BadRequest();
        }

        public async Task<IActionResult> ProductListPdf()
        {
            var pdfBytes = await _productService.GenerateProductListPdf(); 

            return File(pdfBytes, "application/pdf", "ProductList.pdf");
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {


            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product model)
        {

            



            _productService.Create(model);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult ProductUpdate(int? id)
        {
            

            var product = _productService.GetByIdWithCategories((int)id);

            ViewBag.Categories = _categoryService.GetAll().Data;

                var model = new ProductModel
                {
                    ProductId = product.Data.ProductId,
                    ProductName = product.Data.ProductName,
                    Stock = product.Data.Stock,
                    Cost_price = product.Data.Cost_price,
                    Selling_price = product.Data.Selling_price,
                    State = product.Data.State,
                    imgurl = product.Data.imgurl,
                    Brandname = product.Data.Brandname,
                   SelectedCategories = product.Data.ProductCategories.Select(c => c.Category).ToList(),
                };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel model, int[] categoryIds)
        {
            var product = _productService.GetByIdWithCategories(model.ProductId);
            if (product == null)
            {
                return NotFound();
            }

            product.Data.ProductName = model.ProductName;
            product.Data.Stock = model.Stock;
            product.Data.Cost_price = model.Cost_price;
            product.Data.Selling_price = model.Selling_price;
            product.Data.State = model.State;
            product.Data.Brandname = model.Brandname;

            if (model.ProductImage != null && model.ProductImage.Length > 0)
            {
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProductImage.FileName;
                var imagePath = Path.Combine("wwwroot", "images", uniqueFileName); // Save to //wwwroot/images

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await model.ProductImage.CopyToAsync(stream);
                }

                product.Data.imgurl = "/images/" + uniqueFileName;
            }

            _productService.Update(product.Data, categoryIds);

            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult ProductDelete(int productId)
        {
            var product = _productService.GetById(productId);
            if (product != null)
            {


                _productService.Delete(product.Data);
            }

            return RedirectToAction("Index");
        }
       


    } } 
