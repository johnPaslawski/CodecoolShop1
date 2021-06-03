using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Models
{
    public class OrderConfirmationView
    {
        public Order Order { get; set; }
        public Payment Payment { get; set; }

        public OrderConfirmationView(Order order, Payment payment)
        {
            Order = order;
            Payment = payment;
        }
    }
}
