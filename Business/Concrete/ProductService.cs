using Business.Abstract;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Business.ValidationRules.FluentValidation;
using System.ComponentModel.DataAnnotations;
using Business.Utilities.Result;
using Business.Aspect.Autofac.Validation;
using Business.Constants;
using Business.Aspect.Autofac.Transaction;
using Business.Aspects.Autofac.Caching;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        private IProductDal _productDal;
        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public int GetTotalStock()
        {
            return _productDal.GetAll().Sum(p => p.Stock);

        }

        public int GetBrandCount()
        {
            var brandCount = _productDal.GetAll().Select(p => p.Brandname).Distinct().Count();
            return brandCount;
        }
        public async Task<byte[]> GenerateProductListPdf()
        {
            var products = GetAll();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                Document document = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                document.Open();

                foreach (var product in products.Data)
                {
                    document.Add(new Paragraph(product.ProductName));
                    document.Add(new Paragraph(product.Stock.ToString()));
                    document.Add(new Paragraph(product.Selling_price.ToString()));
                }

                document.Close();

                return memoryStream.ToArray();
            }
        }

        public IDataResult<List<Product>> GetProductsByLowStock(int minimumStock)
        {
            var products = _productDal.GetAll(p => p.Stock < minimumStock);
            return new SuccessDataResult<List<Product>>(products);
        }
        [ValidationAspect(typeof(ProductValidator), Priority = 1)]

        public Iresult Create(Product entity)
        {
            _productDal.Create(entity);
            return new SuccessResult(Messages.ProductAdded);
        }

        public Iresult Delete(Product entity)
        {
            _productDal.Delete(entity);
            return new SuccessResult();
        }

        public int GetCount(Expression<Func<Product, bool>> filter = null)
        {
            var count = _productDal.GetCount(filter);
            return count;
        }
        [CacheAspect(duration: 1)]

        public IDataResult<List<Product>> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            var products = _productDal.GetAll(filter);
            return new SuccessDataResult<List<Product>>(products);
        }
        public IDataResult<List<Product>> Search(string keyword)
        {
            var matchingProducts = GetAllWithCategories().Data.Where(p => p.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
            p.Brandname.Contains(keyword, StringComparison.OrdinalIgnoreCase))
             .OrderBy(p => p.ProductName).ThenBy(p => p.Brandname).ToList();
            return new SuccessDataResult < List<Product >> (matchingProducts);
        }
        public IDataResult<Product> GetById(int id)
        {
            var product = _productDal.GetById(id);
            return new SuccessDataResult<Product>(product);
        }

        public IDataResult<Product> GetByIdWithCategories(int id)
        {
            var product = _productDal.GetByIdWithCategories(id);
            return new SuccessDataResult<Product>(product);
        }

        public int GetCountByCategory(string category)
        {

            return _productDal.GetCountByCategory(category);
        }

        public IDataResult<Product> GetOne(Expression<Func<Product, bool>> filter)
        {
            var product = _productDal.GetOne(filter);
            return new SuccessDataResult<Product>(product);
        }
        [CacheAspect(duration: 1)]

        public IDataResult<Product> GetProductDetails(int id)
        {
            var product = _productDal.GetProductDetails(id);
            return new SuccessDataResult<Product>(product);
        }
        [TransactionScopeAspect]
        //burda stosk durumlarını kontrl et sonra düzelt
        public Iresult TransactionalOperation(Product product)
        {
            
            return new SuccessResult(Messages.ProductUpdated);
        }
        [CacheAspect(duration: 1)]

        public IDataResult<List<Product>> Getbycategory(int id)
        {
            var productsInCategory =
                GetAllWithCategories()
                .Data
                .Where(p => p.ProductCategories.Any(pc => pc.CategoryID == id))
                .ToList();
            return new SuccessDataResult<List<Product>>(productsInCategory);
        }

        public IDataResult<List<Product>> List()
        {
            var products = _productDal.List();
            return new SuccessDataResult<List<Product>>(products);
        }


        [ValidationAspect(typeof(ProductValidator), Priority = 1)]

        public Iresult Update(Product entity, int[] categoryIds)
        {
            _productDal.Update(entity, categoryIds);
            return new SuccessResult();
        }
       [CacheAspect(duration: 1)]

        public IDataResult<List<Product>> GetAllWithCategories()
        {
            var products = _productDal.GetAllWithCategories();
            return new SuccessDataResult<List<Product>>(products);
        }
    }
}
