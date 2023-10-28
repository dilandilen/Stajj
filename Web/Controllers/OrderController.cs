using Business.Abstract;
using DataAccess.Authentication;
using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class OrderController : Controller
    {
        private ICartService _cartService;
        private UserManager<AppUser> _userManager;
        private IOrderService _orderService;

        public OrderController(ICartService cartService, UserManager<AppUser> userManager, IOrderService orderService)

        {
            _cartService = cartService;
            _userManager = userManager;
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            var userıd = _userManager.GetUserId(User);
            var orders = _orderService.GetOrders(userıd).ToList();


            return View(orders);
        }
        public IActionResult OrderDetail(int id)
        {
            var order = _orderService.GetByIdWithOrderItems(id);

            if (order == null)
            {
                return NotFound();
            }

           

            return View(order);
        }
        public IActionResult AdminOrder() {
            var orders = _orderService.GetAllWithOrderLines().Select(i => new AdminOrderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.OrderItems.Count,

            }).OrderByDescending(i => i.OrderDate).ToList();

            return View(orders);
        }
        public IActionResult adminOrderDetail(int id)
        {
            var order = _orderService.GetByIdWithOrderItems(id);


            return View(order);
        }
        [HttpPost]
        public ActionResult UpdateOrderState(int OrderId, EnumOrderState OrderState)
        {
            var order = _orderService.GetByIdWithOrderItems(OrderId); 
            if (order != null)
            {
                order.OrderState = OrderState;
                _orderService.Update(order);
                TempData["mesaj"] = "bilgileriniz kaydedildi";

                return RedirectToAction("adminOrderDetail", new { id = OrderId });
            }
            return RedirectToAction("AdminOrder");
        }
        public ActionResult BekleyenSiparisler()
        {
            var orders = _orderService.BekleyenSiparişler();
            
             return View(orders);
        }
        public ActionResult KargolananSiparisler()
        {
            var orders = _orderService.Kargo();

            return View(orders);
        }
        public ActionResult TamamlananSiparisler()
        {
            var orders = _orderService.tamam();
            return View(orders);
        }
        public ActionResult PaketlenenSiparisler()
        {
            var orders = _orderService.paket();

            return View(orders);
        }


    }
}
