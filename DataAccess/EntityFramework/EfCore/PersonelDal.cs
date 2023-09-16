using DataAcces.Generic;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework.EfCore
{
    public class PersonelDal : GenericRepository<Personel, Context>, IPersonelDal
    {
        public List<Personel> GetPersonelsByRole(string role)
        {
            using (var context = new Context())
            {
                return context.Personels
                    .Where(p => p.Role == role)
                    .ToList();
            }
        }
        public Personel GetByIdWithSales(int personelId)
        {
            using (var context = new Context())
            {
                return context.Personels
                    .Include(c => c.SaleTransactions)
                    .SingleOrDefault(c => c.PersonelId == personelId);
            }
        }

        public List<Personel> GetPersonelsBySalaryRange(int minSalary, int maxSalary)
        {
            using (var context = new Context())
            {
                return context.Personels
                    .Where(p => p.Salary >= minSalary && p.Salary <= maxSalary)
                    .ToList();
            }
        }
    }
}
