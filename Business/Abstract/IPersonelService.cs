using Business.Utilities.Result;
using Entity;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IPersonelService 
    {
        int GetCount(Expression<Func<Personel, bool>> filter = null);

       IDataResult< Personel> GetByIdWithSales(int personelId);

        IDataResult< Personel >GetById(int id);

        IDataResult <Personel >GetOne(Expression<Func<Personel, bool>> filter);
        IDataResult<List<Personel>> GetAll(Expression<Func<Personel, bool>> filter = null);
        IDataResult<List<Personel>> List();

        Iresult Create(Personel entity);
        Iresult Update(Personel entity);
        Iresult Delete(Personel entity);

        IDataResult<List<Personel>> GetPersonelsByRole(string role);
        IDataResult<List<Personel>> GetPersonelsBySalaryRange(int minSalary, int maxSalary);
    }
}
