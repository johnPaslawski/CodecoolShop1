using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codecool.CodecoolShop.Models
{
    public class Payment
    {
        
        public long CardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime CardExpiryDate { get; set; }
        public int CardCVVCode { get; set; }
    }
}
