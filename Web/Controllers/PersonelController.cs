using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework.EfCore;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.X509.SigI;
using System.Linq;
using Web.Models;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]

    public class PersonelController : Controller
    {
        IPersonelService _personelService;
        ISaleTransService _saleTransService;
      //  bu personel gerksiz mi gereksiz değil mi anlamadım müşteri internet üzerinden şipariş ederse gereksiz ama gelip bizden alırsa veresiye defteri gibni müşteriş kimden ne kadara almış görebiliriz bu bi dusun
        public PersonelController(IPersonelService personelService, ISaleTransService saleTransService)
        {
            _personelService = personelService;
            _saleTransService = saleTransService;
        }

        public IActionResult Index()
        {
            var personels = _personelService.GetAll();
            var viewModel = new PersonelListModel
            {
                Personels = personels.Data
            };
            return View(viewModel);
        }

        public IActionResult PersonelDetails(int id)
        {
            var personel = _personelService.GetById(id);
            if (personel == null)
            {
                return NotFound();
            }

            var model = new PersonelModel
            {
                PersonelId = personel.Data.PersonelId,
                Name = personel.Data.Name,
                SurName = personel.Data.SurName,
                Email = personel.Data.Email,
                Phone = personel.Data.Phone,
                Role = personel.Data.Role,
                Salary = personel.Data.Salary
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult PersonelAdd()
        {
            var model = new PersonelModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult PersonelAdd(PersonelModel model)
        {
          
                var personel = new Personel
                {
                    Name = model.Name,
                    SurName = model.SurName,
                    Email = model.Email,
                    Phone = model.Phone,
                    Role = model.Role,
                    Salary = model.Salary
                };

                _personelService.Create(personel);
                return RedirectToAction("Index");
           
        }

        [HttpGet]
        public IActionResult PersonelUpdate(int id)
        {
            var personel = _personelService.GetById(id);
            if (personel == null)
            {
                return NotFound();
            }

            var model = new PersonelModel
            {
                PersonelId = personel.Data.PersonelId,
                Name = personel.Data.Name,
                SurName = personel.Data.SurName,
                Email = personel.Data.Email,
                Phone = personel.Data.Phone,
                Role = personel.Data.Role,
                Salary = personel.Data.Salary
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult PersonelUpdate(PersonelModel model)
        {
            
                var personel = _personelService.GetById(model.PersonelId);
                if (personel == null)
                {
                    return NotFound();
                }

                personel.Data.Name = model.Name;
                personel.Data.SurName = model.SurName;
                personel.Data.Email = model.Email;
                personel.Data.Phone = model.Phone;
                personel.Data.Role = model.Role;
            personel.Data.Salary = model.Salary;

                _personelService.Update(personel.Data);

                return RedirectToAction("Index");
            

        }
       

        [HttpPost]
        public IActionResult PersonelDelete(int PersonelId)
        {
            var personel = _personelService.GetById(PersonelId);
            if (personel != null)
            {
                _personelService.Delete(personel.Data);
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult PersonelSales(int id)
        {
            var personel = _personelService.GetByIdWithSales(id);
            if (personel == null)
            {
                return NotFound();
            }

            var personelSales = _saleTransService.GetSalesByEmployee(id);
            var viewModel = new PersonelSalesModel
            {
                Personel = personel.Data,
                SaleTransactions = personelSales.Data
            };

            return View(viewModel);
        }
        public IActionResult PersonelDetail()
        {
            var personels = _personelService.GetAll();
            var viewModel = new PersonelListModel
            {
                Personels = personels.Data
            };
            return View(viewModel);
        }
      
    }
}
