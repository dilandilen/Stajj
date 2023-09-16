using Business.Abstract;
using Business.Utilities.Result;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ExpenseService : IExpenseService
    {
        private IExpenseDal _expenseDal;

        public ExpenseService(IExpenseDal expenseDal)
        {
            _expenseDal = expenseDal;
        }


        public Iresult Create(Expense entity)
        {
            
                _expenseDal.Create(entity);
            return new SuccessResult("kayıt başarılı");
            
        }

        public Iresult Delete(Expense entity)
        {
            _expenseDal.Delete(entity);
            return new SuccessResult();
        }

       

      

        public Iresult Update(Expense entity)
        {
            
                _expenseDal.Update(entity);
            return new SuccessResult();


        }

        IDataResult<List<Expense>> IExpenseService.GetAll(Expression<Func<Expense, bool>> filter)
        {
            throw new NotImplementedException();
        }

        IDataResult<Expense> IExpenseService.GetById(int id)
        {
            throw new NotImplementedException();
        }

        IDataResult<Expense> IExpenseService.GetOne(Expression<Func<Expense, bool>> filter)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<Expense>> IExpenseService.List()
        {
            throw new NotImplementedException();
        }
    }
}
