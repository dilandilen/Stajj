using Business.Abstract;
using Business.Aspect.Autofac.Validation;
using Business.Utilities.Result;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class PersonelService : IPersonelService
    {
        private IPersonelDal _personelDal;

        public PersonelService(IPersonelDal personelDal)
        {
            _personelDal = personelDal;
        }
        [ValidationAspect(typeof(PersonelValidator), Priority = 1)]

        public Iresult Create(Personel entity)
        {
            _personelDal.Create(entity);
            return new SuccessResult();
        }

        public Iresult Delete(Personel entity)
        {
            _personelDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Personel>> GetAll(Expression<Func<Personel, bool>> filter = null)
        {
            var result = _personelDal.GetAll(filter);
            return new SuccessDataResult<List<Personel>>(result);
        }



        public IDataResult<Personel> GetById(int id)
        {
            var result = _personelDal.GetById(id);
            return new SuccessDataResult<Personel>(result);
        }

        public IDataResult<Personel> GetByIdWithSales(int personelId)
        {
            var result = _personelDal.GetByIdWithSales(personelId);
            return new SuccessDataResult<Personel>(result);
        }

        public IDataResult<Personel> GetOne(Expression<Func<Personel, bool>> filter)
        {
            var result = _personelDal.GetOne(filter);
            return new SuccessDataResult<Personel>(result);
        }

        public IDataResult<List<Personel>> GetPersonelsByRole(string role)
        {
            var result = _personelDal.GetPersonelsByRole(role);
            return new SuccessDataResult<List<Personel>>(result);
        }

        public IDataResult<List<Personel>> GetPersonelsBySalaryRange(int minSalary, int maxSalary)
        {
            var result = _personelDal.GetPersonelsBySalaryRange(minSalary, maxSalary);
            return new SuccessDataResult<List<Personel>>(result);
        }

        public IDataResult<List<Personel>> List()
        {
            var result = _personelDal.List();
            return new SuccessDataResult<List<Personel>>(result);
        }
        [ValidationAspect(typeof(PersonelValidator), Priority = 1)]

        public Iresult Update(Personel entity)
        {
            _personelDal.Update(entity);
            return new SuccessResult();
        }

        int IPersonelService.GetCount(Expression<Func<Personel, bool>> filter)
        {
            return _personelDal.GetCount(filter);
                
        
        }
    }
}
