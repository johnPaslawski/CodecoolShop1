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

            //order neworder = orderservice.createneworder(itemsincart, user);
            //sessionhelper.setobjectasjson(httpcontext.session, "order", neworder);

            return View(itemsInCart);
        }

        public IActionResult UserDataForm()
        {          
            User user = new User();

            return View("UserDataForm", user);
        }
    }
}
