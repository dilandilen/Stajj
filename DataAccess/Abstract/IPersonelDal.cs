using Entity;

namespace DataAccess.Abstract
{
    public interface IPersonelDal : IRepository<Personel>
    {


        public Personel GetByIdWithSales(int personelId);

        List<Personel> GetPersonelsByRole(string role);
        List<Personel> GetPersonelsBySalaryRange(int minSalary, int maxSalary);
    }
}
