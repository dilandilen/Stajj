using DataAcces.Generic;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework.EfCore
{
    public class TodoListDal: GenericRepository<TodoList, Context>, ITodoListDal
    {
    }
}
