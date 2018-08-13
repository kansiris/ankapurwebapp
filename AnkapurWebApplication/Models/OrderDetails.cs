using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnkapurWebApplication.Models
{
    public class OrderDetails
    {
        public string OrderId { get; set; }
        public string OrderDate { get; set; }
        public string OrderTime { get; set; }
        public string Restcode { get; set; }
        public decimal Totalamount { get; set; }
        public string Orderstatus { get; set; }
    }
}