using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Models
{
    public class User
    {
        [Display(Name = "Your user ID:")]
        public int UserId { get; set; } = new Random().Next(1000, 9999999);

        [Display(Name = "First and second name:")]
        public string UserName { get; set; }

        [Display(Name = "Email:")]
        public string UserEmail { get; set; }

        [Display(Name = "Phone number:")]
        public int UserPhoneNumber { get; set; }


        [Display(Name = "Country:")]
        public string BillingCountry { get; set; }

        [Display(Name = "City:")]
        public string BillingCity { get; set; }

        [Display(Name = "Zipcode:")]
        public int BillingZipcode { get; set; }

        [Display(Name = "Adress:")]
        public string BillingAdress { get; set; }


        [Display(Name = "Country:")]
        public string ShippingCountry { get; set; }

        [Display(Name = "City:")]
        public string ShippingCity { get; set; }

        [Display(Name = "Zipcode:")]
        public int ShippingZipcode { get; set; }

        [Display(Name = "Adress:")]
        public string ShippingAdress { get; set; }
    }
}
