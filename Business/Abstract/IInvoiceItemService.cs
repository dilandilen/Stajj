using Business.Utilities.Result;
using Entity;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IInvoiceItemService 
    {
        IDataResult< List<InvoiceItem>> GetAllWithInvoice()
;
        IDataResult< InvoiceItem >GetById(int id);

        IDataResult<InvoiceItem >GetOne(Expression<Func<InvoiceItem, bool>> filter);
        IDataResult< List<InvoiceItem>> GetAll(Expression<Func<InvoiceItem, bool>> filter = null);
        IDataResult<List<InvoiceItem>> List();

        Iresult Create(InvoiceItem entity);
        Iresult Update(InvoiceItem entity);
        Iresult Delete(InvoiceItem entity);
        IDataResult<List<InvoiceItem>> GetInvoiceItemsByTutar(decimal tutar);
        IDataResult<List<InvoiceItem> >GetInvoiceItemsByInvoice(int invoiceId);
    }
}
