using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Controllers
{
    public class CartController : Controller
    {
        public string Buy(int id)
        {
            return $"added to cart {id}";
        }
    }
}
