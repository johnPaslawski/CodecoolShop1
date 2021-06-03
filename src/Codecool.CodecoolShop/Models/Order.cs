using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<LineItem> OrderItems { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public User OrderUser { get; set; }
        public Payment OrderPayment { get; set; }

        public Order(int orderId, List<LineItem> orderItems, DateTime orderDate, User orderUser)
        {
            OrderId = orderId;
            OrderItems = orderItems;
            OrderDate = orderDate;
            OrderUser = orderUser;
            TotalPrice = OrderItems.Sum(x => x.Quantity * x.Product.DefaultPrice);
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // ORDER P[AYMENT BEDZIE USTAWIANE PÓŹNIEJ !!!!
            //OrderPayment = orderPayment;
        }
    }
}
