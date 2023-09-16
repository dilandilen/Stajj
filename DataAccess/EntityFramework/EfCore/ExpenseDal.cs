using DataAcces.Generic;
using DataAccess.Abstract;
using DataAccess.Concrete;

using Entity;

namespace DataAccess.EntityFramework.EfCore
{
    public class ExpenseDal : GenericRepository<Expense, Context>, IExpenseDal
    {
    }
}
