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
    public class InvoiceService : IInvoiceService
    {
        private IInvoiceDal _invoiceDal;

        public InvoiceService(IInvoiceDal invoiceDal)
        {
            _invoiceDal = invoiceDal;
        }

        public Iresult Create(Invoice entity)
        {
            _invoiceDal.Create(entity);
            return new SuccessResult("Invoice created successfully.");
        }

        public Iresult Delete(Invoice entity)
        {
            _invoiceDal.Delete(entity);
            return new SuccessResult("Invoice deleted successfully.");
        }

        public IDataResult<List<Invoice>> GetAll(Expression<Func<Invoice, bool>> filter = null)
        {
            var invoices = _invoiceDal.GetAll(filter);
            return new SuccessDataResult<List<Invoice>>(invoices, "Invoices retrieved successfully.");
        }

        public IDataResult<Invoice> GetById(int id)
        {
            var invoice = _invoiceDal.GetById(id);
            if (invoice != null)
            {
                return new SuccessDataResult<Invoice>(invoice, "Invoice retrieved successfully.");
            }
            return new ErrorDataResult<Invoice>("Invoice not found.");
        }

        public IDataResult<Invoice> GetByIdWithItems(int Iıd)
        {
            var invoice = _invoiceDal.GetByIdWithItems(Iıd);
            if (invoice != null)
            {
                return new SuccessDataResult<Invoice>(invoice, "Invoice with items retrieved successfully.");
            }
            return new ErrorDataResult<Invoice>("Invoice not found.");
        }

        public int GetCount(Expression<Func<Invoice, bool>> filter = null)
        {
            return _invoiceDal.GetCount(filter);
        }

        public IDataResult<List<Invoice>> GetInvoicesByDateRange(DateTime startDate, DateTime endDate)
        {
            var invoices = _invoiceDal.GetInvoicesByDateRange(startDate, endDate);
            return new SuccessDataResult<List<Invoice>>(invoices, "Invoices retrieved successfully.");
        }

        public IDataResult<List<Invoice>> GetInvoicesByDeliverd(string deliverd)
        {
            var invoices = _invoiceDal.GetInvoicesByDeliverd(deliverd);
            return new SuccessDataResult<List<Invoice>>(invoices, "Invoices retrieved successfully.");
        }

        public IDataResult<List<Invoice>> GetInvoicesByReceived(string received)
        {
            var invoices = _invoiceDal.GetInvoicesByReceived(received);
            return new SuccessDataResult<List<Invoice>>(invoices, "Invoices retrieved successfully.");
        }

        public IDataResult<List<Invoice>> GetInvoicesByTaxidAdministration(string taxidAiresis)
        {
            var invoices = _invoiceDal.GetInvoicesByTaxAdministration(taxidAiresis);
            return new SuccessDataResult<List<Invoice>>(invoices, "Invoices retrieved successfully.");
        }

        public IDataResult<Invoice> GetOne(Expression<Func<Invoice, bool>> filter)
        {
            var invoice = _invoiceDal.GetOne(filter);
            if (invoice != null)
            {
                return new SuccessDataResult<Invoice>(invoice, "Invoice retrieved successfully.");
            }
            return new ErrorDataResult<Invoice>("Invoice not found.");
        }

        public IDataResult<List<Invoice>> List()
        {
            var invoices = _invoiceDal.List();
            return new SuccessDataResult<List<Invoice>>(invoices, "Invoices retrieved successfully.");
        }

        public Iresult Update(Invoice entity)
        {
            _invoiceDal.Update(entity);
            return new SuccessResult("Invoice updated successfully.");
        }
    }
}
