using Codecool.CodecoolShop.Daos.Implementations;
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
    [Route("cart")]
    public class CartController : Controller
    {
        public ProductService ProductService { get; set; }

        public CartController()
        {
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance());
        }

        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<LineItem>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                return View("Cart");
            }
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.Product.DefaultPrice * item.Quantity);
            return View("Cart");
        }
        
        [Route("buy/{id}")]
        //sprawdzić czy int id też zadziała, pokombinować z fromQuery itd
        public IActionResult Buy(int id)
        {
            
            if (SessionHelper.GetObjectFromJson<List<LineItem>>(HttpContext.Session, "cart") == null)
            {
                List<LineItem> cart = new List<LineItem>();
                cart.Add(new LineItem { Product = ProductService.GetProductById(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<LineItem> cart = SessionHelper.GetObjectFromJson<List<LineItem>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new LineItem { Product = ProductService.GetProductById(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<LineItem> cart = SessionHelper.GetObjectFromJson<List<LineItem>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<LineItem> cart = SessionHelper.GetObjectFromJson<List<LineItem>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
