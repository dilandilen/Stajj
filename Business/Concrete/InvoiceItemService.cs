using Business.Abstract;
using Business.Utilities.Result;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class InvoiceItemService : IInvoiceItemService
    {
        private IInvoiceItemDal _invoiceItemDal;

        public InvoiceItemService(IInvoiceItemDal invoiceItemDal)
        {
            _invoiceItemDal = invoiceItemDal;
        }

        public Iresult Create(InvoiceItem entity)
        {
            _invoiceItemDal.Create(entity);
            return new SuccessResult();
        }

        public Iresult Delete(InvoiceItem entity)
        {
            _invoiceItemDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<InvoiceItem>> GetAll(Expression<Func<InvoiceItem, bool>> filter = null)
        {
            var result = _invoiceItemDal.GetAll(filter);
            return new SuccessDataResult<List<InvoiceItem>>(result);
        }

        public IDataResult<List<InvoiceItem>> GetAllWithInvoice()
        {
            var result = _invoiceItemDal.GetAllWithInvoice();
            return new SuccessDataResult<List<InvoiceItem>>(result);
        }

        public IDataResult<InvoiceItem> GetById(int id)
        {
            var result = _invoiceItemDal.GetById(id);
            return new SuccessDataResult<InvoiceItem>(result);
        }

        public IDataResult<List<InvoiceItem>> GetInvoiceItemsByInvoice(int invoiceId)
        {
            var result = _invoiceItemDal.GetInvoiceItemsByInvoice(invoiceId);
            return new SuccessDataResult<List<InvoiceItem>>(result);
        }

       
        public IDataResult<List<InvoiceItem>> GetInvoiceItemsByTutar(decimal tutar)
        {
            var result = _invoiceItemDal.GetInvoiceItemsByTutar(tutar);
            return new SuccessDataResult<List<InvoiceItem>>(result);
        }

        public IDataResult<InvoiceItem> GetOne(Expression<Func<InvoiceItem, bool>> filter)
        {
            var result = _invoiceItemDal.GetOne(filter);
            return new SuccessDataResult<InvoiceItem>(result);
        }

        public IDataResult<List<InvoiceItem>> List()
        {
            var result = _invoiceItemDal.List();
            return new SuccessDataResult<List<InvoiceItem>>(result);
        }

        public Iresult Update(InvoiceItem entity)
        {
            _invoiceItemDal.Update(entity);
            return new SuccessResult();
        }
    }
}
