using Business.Utilities.Result;
using Entity;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IInvoiceService
    {
        int GetCount(Expression<Func<Invoice, bool>> filter = null);
        IDataResult< Invoice> GetByIdWithItems(int Iıd)
;
        IDataResult< Invoice >GetById(int id);

        IDataResult<Invoice> GetOne(Expression<Func<Invoice, bool>> filter);
        IDataResult<List<Invoice>> GetAll(Expression<Func<Invoice, bool>> filter = null);
        IDataResult<List<Invoice>> List();

        Iresult Create(Invoice entity);
        Iresult Update(Invoice entity);
        Iresult Delete(Invoice entity);
        IDataResult<List<Invoice>> GetInvoicesByDateRange(DateTime startDate, DateTime endDate);
        IDataResult<List<Invoice>> GetInvoicesByTaxidAdministration(string taxidAiresis);
        IDataResult<List<Invoice>> GetInvoicesByReceived(string received);
        IDataResult<List<Invoice>> GetInvoicesByDeliverd(string deliverd);
    }
}
