using Codecool.CodecoolShop.Helpers;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index(User user)
        {

            Payment payment = new Payment();

            return View(payment);
        }

        public IActionResult OrderConfirmation(Payment payment)
        {
            
            var order = SessionHelper.GetObjectFromJson<Order>(HttpContext.Session, "order"); 
            
            OrderConfirmationView orderConfirmView = new OrderConfirmationView(order, payment);
            return View("OrderConfirmation", orderConfirmView);
        }
    }


}
