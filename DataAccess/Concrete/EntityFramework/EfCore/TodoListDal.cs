using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.EfCore
{
    public class TodoListDal : GenericRepository<TodoList>, ITodoListDal

    {
        public TodoListDal(Context context) : base(context)
        {
        }
    }
}
