using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Authentication;
using Web.Models;
using static iTextSharp.text.pdf.events.IndexEvents;

namespace web.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private ICartService _cartService;
        private UserManager<AppUser> _userManager;
        private IOrderService _orderService;

        public CartController(ICartService cartService, UserManager<AppUser> userManager, IOrderService orderService)

        {
            _cartService = cartService;
            _userManager = userManager;
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            return View(new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemModel()
                {
                    CartItemId = i.Id,
                    ProductId = i.ProductId,
                    Name = i.Product.ProductName,
                    Price = (decimal)i.Product.Selling_price,
                    ImageUrl = i.Product.imgurl,
                    Quantity = i.Quantity

                }).ToList()
            });
        }
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var userId = _userManager.GetUserId(User);
            _cartService.AddToCart(userId, productId, quantity);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteFromCart(int productId)
        {
            var userId = _userManager.GetUserId(User);
            _cartService.DeleteFromCart(userId, productId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            var orderModel = new OrderModel();
            orderModel.CartModel = new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemModel()
                {
                    CartItemId = i.Id,
                    ProductId = i.ProductId,
                    Name = i.Product.ProductName,
                    Price = (decimal)i.Product.Selling_price,
                    ImageUrl = i.Product.imgurl,
                    Quantity = i.Quantity

                }).ToList()
            };
            return View(orderModel);
        }
        [HttpPost]
        public ActionResult Checkout(OrderModel entity)
        {
            
                var userId = _userManager.GetUserId(User);

                var cart = _cartService.GetCartByUserId(userId);
                entity.CartModel = new CartModel()
                {
                    CartId = cart.Id,
                    CartItems = cart.CartItems.Select(i => new CartItemModel()
                    {
                        CartItemId = i.Id,
                        ProductId = i.Product.ProductId,
                        Name = i.Product.ProductName,
                        Price = (decimal)i.Product.Cost_price,
                        ImageUrl = i.Product.imgurl,
                        Quantity = i.Quantity
                    }).ToList()
                };

                SaveOrder(entity, cart);

                ClearCart(cart.Id.ToString());

                return View("Completed");
            
            
                return View(entity);
            

        }

        private void ClearCart(string cartId)
        {
            _cartService.ClearCart(cartId);
        }
        private void SaveOrder(OrderModel model, Cart cart)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random()).Next(1111, 9999).ToString();
            order.Total = 15;
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Bekleniyor;
            order.FirstName = model.FirstName;
            order.LastName = model.LastName;
            order.Email = model.Email;
            order.Phone = model.Phone;
            order.Address = model.Address;
            order.City = model.City;
            order.UserId = _userManager.GetUserId(User);
             order.OrderNote="bekleniyor";
            order.OrderItems = new List<OrderItem>();

            foreach (var item in  cart.CartItems)
            {
                var orderitem = new OrderItem()
                {
                    Price = (double)( item.Quantity * item.Product.Selling_price),
                    Quantity = item.Quantity,
                    ProductId = item.ProductId
                };
                order.OrderItems.Add(orderitem);
            }
            _orderService.Create(order);
        }
    }
}