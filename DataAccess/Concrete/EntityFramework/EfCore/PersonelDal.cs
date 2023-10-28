using DataAccess.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.EfCore
{
    public class PersonelDal : GenericRepository<Personel>, IPersonelDal
    {
        public PersonelDal(Context context) : base(context)
        {
        }
        public List<Personel> GetPersonelsByRole(string role)
        {
            
                return _context.Personels
                    .Where(p => p.Role == role)
                    .ToList();
            
        }
        public Personel GetByIdWithSales(int personelId)
        {
           
                return _context.Personels
                    .Include(c => c.SaleTransactions)
                    .SingleOrDefault(c => c.PersonelId == personelId);
            
        }

        public List<Personel> GetPersonelsBySalaryRange(int minSalary, int maxSalary)
        {
           
                return _context.Personels
                    .Where(p => p.Salary >= minSalary && p.Salary <= maxSalary)
                    .ToList();
            
        }
    }
}
