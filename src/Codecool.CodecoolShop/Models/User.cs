using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int UserPhoneNumber { get; set; }

        public string BillingCountry { get; set; }
        public string BillingCity { get; set; }
        public string BillingZipcode { get; set; }
        public string BillingAdress { get; set; }
        
        public string ShippingCountry { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingZipcode { get; set; }
        public string ShippingAdress { get; set; }
    }
}
