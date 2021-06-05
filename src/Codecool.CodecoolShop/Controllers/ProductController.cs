using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Codecool.CodecoolShop.Helpers;
using Microsoft.AspNetCore.Http;

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public ProductService ProductService { get; set; }

        
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance());
        }


        [Route("/")]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<LineItem>>(HttpContext.Session, "cart");
            ViewBag.SuppliersList = SupplierDaoMemory.GetInstance().GetAll().ToList();
            ViewBag.CategoriesList = ProductService.GetAllProductCategories().ToList();

            if (cart == null)
            {
                ViewBag.CartItemsCount = 0;
            }
            else
            {
                ViewBag.CartItemsCount = cart.Sum(x => x.Quantity);
                //HttpContext.Session.SetInt32("itemsInCart", cart.Sum(x => x.Quantity));
            }
            

            //var products = ProductService.GetProductsForCategory(1);
            var products = ProductService.GetAllProducts();
            return View(products.ToList());
        }


        [Route("/bySupplier")]
        public IActionResult IndexBySupplier(int supplierId)
        {
            ViewBag.SuppliersList = SupplierDaoMemory.GetInstance().GetAll().ToList();
            ViewBag.CategoriesList = ProductService.GetAllProductCategories().ToList();
            var cart = SessionHelper.GetObjectFromJson<List<LineItem>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                ViewBag.CartItemsCount = 0;
            }
            else
            {
                ViewBag.CartItemsCount = cart.Sum(x => x.Quantity);
                //HttpContext.Session.SetInt32("itemsInCart", cart.Sum(x => x.Quantity));
            }
            Supplier supplier = SupplierDaoMemory.GetInstance().Get(supplierId);

            var products = ProductService.GetProductsForSupplier(supplier);
            return View("Index", products.ToList());
        }


        [Route("/byCategory")]
        public IActionResult IndexByCategory(int categoryId)
        {
            ViewBag.SuppliersList = SupplierDaoMemory.GetInstance().GetAll().ToList();
            ViewBag.CategoriesList = ProductService.GetAllProductCategories().ToList();
            var cart = SessionHelper.GetObjectFromJson<List<LineItem>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                ViewBag.CartItemsCount = 0;
            }
            else
            {
                ViewBag.CartItemsCount = cart.Sum(x => x.Quantity);
                //HttpContext.Session.SetInt32("itemsInCart", cart.Sum(x => x.Quantity));
            }
            var products = ProductService.GetProductsForCategory(categoryId);
            return View("Index", products.ToList());
        }


        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
