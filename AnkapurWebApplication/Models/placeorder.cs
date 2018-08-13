using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnkapurWebApplication.Models
{
    public class placeorder
    {

        public string Totalamount { get; set; }
        public string cgst { get; set; }
        public string sgst { get; set; }
        public string Deliverycharges { get; set; }
        public string customerrequest { get; set; }


        public string RestCode { get; set; }
        public string DeliverTime { get; set; }
        public string deliveryamount { get; set; }
        public string delocation { get; set; }

        public string cartdata { get; set; }

        
    }
}