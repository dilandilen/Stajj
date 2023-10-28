using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
            if (personels.Success)
            {
                return View(personels.Data);
            }
            return BadRequest();
        }

        public IActionResult PersonelDetails(int id)
        {
            var personel = _personelService.GetById(id);
            if (personel.Success)
            {
                return View(personel.Data);
            }


            return BadRequest();
        }

        [HttpGet]
        public IActionResult PersonelAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PersonelAdd(Personel model)
        {
          

                _personelService.Create(model);
                return RedirectToAction("Index");
           
        }

        [HttpGet]
        public IActionResult PersonelUpdate(int id)
        {
            var personel = _personelService.GetById(id);
            if (personel.Success)
            {

                
                return View(personel.Data);

            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult PersonelUpdate(Personel model)
        {
            
              
                _personelService.Update(model);
            


            return RedirectToAction("Index");
             
            

        }
       

        [HttpPost]
        public IActionResult PersonelDelete(int PersonelId)
        {
            var personel = _personelService.GetById(PersonelId);
            if (personel.Success)
            {
                _personelService.Delete(personel.Data);
                return RedirectToAction("Index");

            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult PersonelSales(int id)
        {
            var personel = _personelService.GetByIdWithSales(id).Data.Name;
            ViewBag.personel=personel;

            var personelSales = _saleTransService.GetSalesByEmployee(id);
           

            return View(personelSales.Data);
        }
        public IActionResult PersonelDetail()
        {
            var personels = _personelService.GetAll();
           if(personels.Success)
            return View(personels.Data);
           else return BadRequest();
        }
      
    }
}
