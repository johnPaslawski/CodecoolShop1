using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Controllers
{
    public class PaymentController : Controller
    {
        public OrderService OrderService { get; set; }

        public PaymentController()
        {
            OrderService = new OrderService();
        }

        public IActionResult Index(User user)
        {
            var cart = SessionHelper.GetObjectFromJson<List<LineItem>>(HttpContext.Session, "cart");

            Order newOrder = OrderService.CreateNewOrder(cart, user);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "order", newOrder);

            Payment payment = new Payment();

            return View(payment);
        }

        public IActionResult OrderConfirmation(Payment payment)
        {
            
            var order = SessionHelper.GetObjectFromJson<Order>(HttpContext.Session, "order"); 
            
            OrderConfirmationView orderConfirmView = new OrderConfirmationView(order, payment);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "podsumowaniewszystkiego", orderConfirmView);
            return View("OrderConfirmation", orderConfirmView);
        }

        public IActionResult ConfirmOrderAndPayment()
        {
            var jsondlaadmina = SessionHelper.GetObjectFromJson<OrderConfirmationView>(HttpContext.Session, "podsumowaniewszystkiego");
            
            return View();
        }
    }


}
