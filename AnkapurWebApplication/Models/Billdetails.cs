using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnkapurWebApplication.Models
{
    public class Billdetails
    {
        public int Totalamount { get; set; }
        public int cgst { get; set; }
        public int sgst { get; set; }
        public int Deliverycharges { get; set; }

    }
}