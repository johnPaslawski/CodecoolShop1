using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Models
{
    public class CartViewModel
    {
        public List<LineItem> productsList { get; set; }

        public decimal Total { get; set; }
    }
}
