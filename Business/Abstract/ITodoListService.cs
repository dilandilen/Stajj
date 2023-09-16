using Business.Utilities.Result;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITodoListService 
    {

       IDataResult<TodoList> GetById(int id);

          IDataResult<TodoList> GetOne(Expression<Func<TodoList, bool>> filter);
        IDataResult<List<TodoList>> GetAll(Expression<Func<TodoList, bool>> filter = null);
        IDataResult<List<TodoList>> List();
        int GetCount(Expression<Func<TodoList, bool>> filter = null);

        Iresult Create(TodoList entity);
        Iresult Update(TodoList entity);
        Iresult Delete(TodoList entity);
    }
}
