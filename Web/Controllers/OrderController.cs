using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Authentication;
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
            var orderListModel = new List<OrderListModel>();

            OrderListModel orderModel;

            foreach (var order in orders)
            {
                orderModel = new OrderListModel();
                orderModel.OrderId = order.Id;
                orderModel.OrderNumber = order.OrderNumber;
                orderModel.OrderDate = order.OrderDate;
                orderModel.OrderNote = order.OrderNote;
                orderModel.Phone = order.Phone;
                orderModel.FirstName = order.FirstName;
                orderModel.LastName = order.LastName;
                orderModel.Email = order.Email;
                orderModel.Address = order.Address;
                orderModel.City = order.City;

                orderModel.OrderItems = order.OrderItems.Select(i => new OrderItemModel()
                {
                    OrderItemId = i.Id,
                    Name = i.Product.ProductName,
                    Price = (decimal)i.Price,
                    Quantity = i.Quantity,
                    ImageUrl = i.Product.imgurl
                }).ToList();
                orderListModel.Add(orderModel);
            }

            return View(orderListModel);
        }
        public IActionResult OrderDetail(int id)
        {
            var order = _orderService.GetByIdWithOrderItems(id);

            if (order == null)
            {
                return NotFound();
            }

            var orderDetailModel = new OrderListModel()
            {
                OrderNumber = order.OrderNumber,
                OrderDate = order.OrderDate,
                FirstName = order.FirstName,
                LastName = order.LastName,
                OrderState = order.OrderState,
                Address = order.Address,
                City = order.City,
                OrderItems = order.OrderItems.Select(i => new OrderItemModel
                {
                    Name = i.Product.ProductName,
                    Price = (decimal)i.Price,
                    Quantity = i.Quantity,
                    ProductId = i.ProductId,
                    Image = i.Product.imgurl,


                }).ToList()
            };

            return View(orderDetailModel);
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

            if (order == null)
            {
                return NotFound();
            }

            var orderDetailModel = new OrderListModel()
            {
                OrderId = order.Id,
                OrderNumber = order.OrderNumber,
                OrderDate = order.OrderDate,
                FirstName = order.FirstName,
                LastName = order.LastName,
                OrderState = order.OrderState,
                Address = order.Address,
                City = order.City,
                OrderItems = order.OrderItems.Select(i => new OrderItemModel
                {
                    Name = i.Product.ProductName,
                    Price = (decimal)i.Price,
                    Quantity = i.Quantity,
                    ProductId = i.ProductId,
                    Image = i.Product.imgurl,


                }).ToList()
            };

            return View(orderDetailModel);
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
            var orders = _orderService.GetAll().Where(i => i.OrderState == EnumOrderState.Bekleniyor).Select(i => new AdminOrderModel()
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
        public ActionResult KargolananSiparisler()
        {
            var orders = _orderService.GetAll().Where(i => i.OrderState == EnumOrderState.Kargolandı).Select(i => new AdminOrderModel()
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
        public ActionResult TamamlananSiparisler()
        {
            var orders = _orderService.GetAll().Where(i => i.OrderState == EnumOrderState.Tamamlandı).Select(i => new AdminOrderModel()
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
        public ActionResult PaketlenenSiparisler()
        {
            var orders = _orderService.GetAll().Where(i => i.OrderState == EnumOrderState.Paketlendi).Select(i => new AdminOrderModel()
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


    }
}
