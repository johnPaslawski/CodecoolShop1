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
    public class CheckoutController : Controller
    {
        public OrderService OrderService { get; set; }

        public CheckoutController()
        {
            OrderService = new OrderService();
        }

        public IActionResult Index(List<LineItem> itemsInCart)
        {
            // tu będzie wchodziło, kiedy będzie zalogowany już user i będą już jakieś jego dane
            return View(itemsInCart);
        }

        public IActionResult FillUserData(List<LineItem> itemsInCart)
        {
            
            User user = new User();
            Order newOrder = OrderService.CreateNewOrder(itemsInCart, user);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "order", newOrder);

            

            

            return View("UserDataForm", user);
        }
    }
}
