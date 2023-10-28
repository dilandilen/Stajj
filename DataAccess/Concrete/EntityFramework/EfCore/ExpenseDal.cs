using DataAccess.Abstract;

using Entity;

namespace DataAccess.Concrete.EntityFramework.EfCore
{
    public class ExpenseDal : GenericRepository<Expense>, IExpenseDal

    {
        public ExpenseDal(Context context) : base(context)
        {
        }
    }
}
