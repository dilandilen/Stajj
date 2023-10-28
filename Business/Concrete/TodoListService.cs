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
    public class TodoListService : ITodoListService
    {
        private ITodoListDal _todoListDal;

        public TodoListService(ITodoListDal todoListDal)
        {
            _todoListDal = todoListDal;
        }

        public Iresult Create(TodoList entity)
        {
            _todoListDal.Create(entity);
            return new SuccessResult();

        }

        public Iresult Delete(TodoList entity)
        {
            _todoListDal.Delete(entity);
            return new SuccessResult();

        }

        public IDataResult< List<TodoList>> GetAll(Expression<Func<TodoList, bool>>? filter = null)
        {
            return new SuccessDataResult<List<TodoList>>( _todoListDal.GetAll(filter));
        }

        public IDataResult<TodoList> GetById(int id)
        {
            return new SuccessDataResult<TodoList>(_todoListDal.GetById(id));
          
        }

        public int GetCount(Expression<Func<TodoList, bool>> filter = null)
        {
            return _todoListDal.GetCount(filter);
        }

        public IDataResult<TodoList> GetOne(Expression<Func<TodoList, bool>> filter)
        {
            return new SuccessDataResult<TodoList>( _todoListDal.GetOne(filter));
        }

        public IDataResult<List<TodoList>> List()
        {
            return new SuccessDataResult<List<TodoList>>(_todoListDal.List());
        }

        public Iresult Update(TodoList entity)
        {
            _todoListDal.Update(entity);
            return new SuccessResult();
        }


    }
}
