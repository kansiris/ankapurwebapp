//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnkapurWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblNewCustomer
    {
        public string CustPhoneNumber { get; set; }
        public string CustomerFName { get; set; }
        public string CustomerLName { get; set; }
        public string Billing_Address { get; set; }
        public string Delivery_Addresss { get; set; }
        public string Land_Mark { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public Nullable<int> CustomerTypeId { get; set; }
        public Nullable<double> DeliveryLocationLatitude { get; set; }
        public Nullable<double> DeliveryLocationLongitude { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string OTP { get; set; }
        public string Status { get; set; }
    }
}
