using Codecool.CodecoolShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Services
{
    public class OrderService
    {
        public Order CreateNewOrder(List<LineItem> orderItems, User user)
        {
            //to by dobrze było pobierać z bazy i dawać np o jeden więcej niż p[oprzedni order
            int orderId = new Random().Next(100, 100000);
            DateTime orderDate = DateTime.Now;
            // do wyjaśnienia - w zależności od logowania gdzie będzie tworzony user, LUB POBIERANY
            // Z ZALOGOWANIA I TYLKO UZUPEŁNIANE JEGO BRAKUJĄCE DANE
            //User orderUser = new User() { };
            
            Order order = new Order(orderId, orderItems, orderDate, user);

            return order;
        }
    }
}
