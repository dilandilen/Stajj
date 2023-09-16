using Business.Utilities.Result;
using Entity;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IExpenseService
    {
        IDataResult< Expense> GetById(int id);

        IDataResult<Expense> GetOne(Expression<Func<Expense, bool>> filter);
        IDataResult<List<Expense>> GetAll(Expression<Func<Expense, bool>> filter = null);
        IDataResult<List<Expense>> List();

        Iresult Create(Expense entity);
        Iresult Update(Expense entity);
        Iresult Delete(Expense entity);
    }
}
