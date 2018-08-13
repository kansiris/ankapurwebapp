using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnkapurWebApplication.Models;
using Ankapur.service;
using System.Data.SqlClient;
using System.Web.Routing;
using System.Web.Caching;
using System.Globalization;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using System.Drawing;
using System.Web.Security;
using Microsoft.Web.Administration;
//using Microsoft.SqlServer.Management.Common;
using System.Web.Hosting;
using Ankapur.Utility;
using Microsoft.AspNet.Identity;
using AnkapurWebApplication.Content;
using System.Web.UI;
using System.Dynamic;
using Razorpay.Api;
using System.Net;

namespace AnkapurWebApplication.Controllers
{
    public class NewOrderController : Controller
    {
        // GET: NewOrder
        //[OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Index(string area)
        {
            try
            {
                //if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                //{
                    ViewBag.Products = products();
                    ViewBag.breakfast = breakfast();
                    ViewBag.addons = addons();
                    ViewBag.lunchanddinner = lunchanddinner();
                    ViewBag.pccombos = pccombos();
                    ViewBag.lb = lunchbox();
                    ViewBag.Code = "HN";
                    var darea = area;
                    if (darea == "")
                    { darea = "HN"; }
                    else
                    { darea = area; }
                    ViewBag.delocation = darea;
                    //delarea;
                    string restcodedisplay = ViewBag.Code;
                    string phonenumber = Session["CustPhoneNumber"].ToString();
                    string name = Session["CustomerFName"].ToString();
                    string address = Session["Delivery_Addresss"].ToString();
                    ViewBag.Phone = phonenumber;
                    ViewBag.Name = name;
                    ViewBag.Address = address;
                //}
                return View();
          //  }
                //   return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return View();
            //            return RedirectToAction("Index", "Home");
        }
        }
        //loading of the total products
        public List<Products> products()
        {
            var prd = AnkapurService.Loadproducts();
            var dt = new DataTable();
            dt.Load(prd);
            List<Products> prod = (from DataRow row in dt.Rows

                                   select new Products
                                   {
                                       ProductId = row["ProductID"].ToString(),
                                       ProductName = row["ProductName"].ToString(),
                                       Price = row["Price"].ToString(),
                                       Image = row["Image"].ToString(),
                                       // Image = (Byte[])row["Image"],
                                       Quantity = row["Quanity"].ToString(),
                                       ShortDescription = row["ShortDescription"].ToString(),
                                       LongDescription = row["LongDescription"].ToString()
                                   }
                                   ).ToList();
            return prod;
        }
        //breakfast
        public List<Products> breakfast()
        {
            var prd = AnkapurService.loadprodoncategory(4);
            var dt = new DataTable();
            dt.Load(prd);
            List<Products> prod = (from DataRow row in dt.Rows
                                   select new Products
                                   {
                                       ProductId = row["ProductID"].ToString(),
                                       ProductName = row["ProductName"].ToString(),
                                       Price = row["Price"].ToString(),
                                       Image = row["Image"].ToString(),
                                       // Image = (Byte[])row["Image"],
                                       Quantity = row["Quanity"].ToString(),
                                       ShortDescription = row["ShortDescription"].ToString(),
                                       LongDescription = row["LongDescription"].ToString()
                                   }).ToList();
            return prod;
        }

        //breakfast
        public List<Products> lunchbox()
        {
            var prd = AnkapurService.loadprodoncategory(25);
            var dt = new DataTable();
            dt.Load(prd);
            List<Products> prod = (from DataRow row in dt.Rows
                                   select new Products
                                   {
                                       ProductId = row["ProductID"].ToString(),
                                       ProductName = row["ProductName"].ToString(),
                                       Price = row["Price"].ToString(),
                                       Image = row["Image"].ToString(),
                                       // Image = (Byte[])row["Image"],
                                       Quantity = row["Quanity"].ToString(),
                                       ShortDescription = row["ShortDescription"].ToString(),
                                       LongDescription = row["LongDescription"].ToString()
                                   }).ToList();
            return prod;
        }

        //addons
        public List<Products> addons()
        {
            var prd = AnkapurService.loadprodoncategory(24);
            var dt = new DataTable();
            dt.Load(prd);
            List<Products> prod = (from DataRow row in dt.Rows
                                   select new Products
                                   {
                                       ProductId = row["ProductID"].ToString(),
                                       ProductName = row["ProductName"].ToString(),
                                       Price = row["Price"].ToString(),
                                       Image = row["Image"].ToString(),
                                       // Image = (Byte[])row["Image"],
                                       Quantity = row["Quanity"].ToString(),
                                       ShortDescription = row["ShortDescription"].ToString(),
                                       LongDescription = row["LongDescription"].ToString()
                                   }).ToList();
            return prod;
        }
        //lunchanddinner
        public List<Products> lunchanddinner()
        {
            var prd = AnkapurService.loadprodoncategory(20);
            var dt = new DataTable();
            dt.Load(prd);
            List<Products> prod = (from DataRow row in dt.Rows
                                   select new Products
                                   {
                                       ProductId = row["ProductID"].ToString(),
                                       ProductName = row["ProductName"].ToString(),
                                       Price = row["Price"].ToString(),
                                       Image = row["Image"].ToString(),
                                       // Image = (Byte[])row["Image"],
                                       Quantity = row["Quanity"].ToString(),
                                       ShortDescription = row["ShortDescription"].ToString(),
                                       LongDescription = row["LongDescription"].ToString()
                                   }).ToList();
            return prod;
        }
        //combos

        public List<Products> pccombos()
        {
            var prd = AnkapurService.loadprodoncategory1(21, 23, 8);
            var dt = new DataTable();
            dt.Load(prd);
            List<Products> prod = (from DataRow row in dt.Rows
                                   select new Products
                                   {
                                       ProductId = row["ProductID"].ToString(),
                                       ProductName = row["ProductName"].ToString(),
                                       Price = row["Price"].ToString(),
                                       Image = row["Image"].ToString(),
                                       // Image = (Byte[])row["Image"],
                                       Quantity = row["Quanity"].ToString(),
                                       ShortDescription = row["ShortDescription"].ToString(),
                                       LongDescription = row["LongDescription"].ToString()
                                   }).ToList();
            return prod;
        }


        //Genarating last inserted orderid

        public List<Products> generateorderidforwebcart()
        {
            DateTime orderdate = System.DateTime.Today;
            string restcode = "HN";
            var orderid = AnkapurService.generateorderidforwebcart(orderdate, restcode);
            var dt = new DataTable();
            dt.Load(orderid);
            List<Products> order = (from DataRow row in dt.Rows
                                    select new Products
                                    {
                                        Orderid = row["OrderId"].ToString()
                                    }).ToList();
            return order;
        }

        // saving the order and redirecting to conformation page
        [HttpPost]
        public JsonResult placeorder(string customerPhone, string RestCode, string CustomerRequest, string DeliverTime, decimal Totalamount, decimal cgst1, decimal sgst1, int deliveryamount, string cartdata, string delocation)
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string productids = null; string productqty = null;
                var data = AnkapurService.placeorder(customerPhone, RestCode, CustomerRequest, DeliverTime, Totalamount, cgst1, sgst1, deliveryamount, delocation);
                string cd = cartdata;
                string[] cdvalues = cd.Split(',');

                for (int i = 0; i < cdvalues.Length; i++)
                {
                    if (cdvalues[i] != "null" && cdvalues[i].Split('-')[0] != "null" && cdvalues[i].Split('-')[1] != "null")
                    {
                        productids = productids + "," + cdvalues[i].Split('-')[0];
                        productqty = productqty + "," + cdvalues[i].Split('-')[1];
                    }
                }
                productids = productids.TrimStart(',');
                productqty = productqty.TrimStart(',');
                var orderid = generateorderidforwebcart();

                string oid = orderid.FirstOrDefault().Orderid;
                if (oid == "")
                {
                    string month = DateTime.Now.ToString("MM");
                    string month1 = month.Substring(1, 1);
                    oid = "HN" + DateTime.Now.ToString("dd") + month1 + "-" + 1;
                }
                else
                {
                    oid = orderid.FirstOrDefault().Orderid;
                }
                for (int i = 0; i < productids.Split(',').Length; i++)
                {
                    var cartitems = AnkapurService.insertdetailsidbase(oid, productids.Split(',')[i], Convert.ToInt32(productqty.Split(',')[i].ToString()));
                }

                if (data == -1)
                {
                    ViewBag.customerphone = customerPhone;
                    ViewBag.restcode = RestCode;
                    ViewBag.customerrequest = CustomerRequest;
                    ViewBag.delivertime = DeliverTime;
                    ViewBag.totalamount = Totalamount;
                    return Json("success");
                }

                return Json("unique", JsonRequestBehavior.AllowGet);
            }
            else
            {
                placeorder data = new placeorder();
                data.cartdata = cartdata;
                data.cgst = Convert.ToString(cgst1);
                data.sgst = Convert.ToString(sgst1);
                data.RestCode = RestCode;
                data.customerrequest = CustomerRequest;
                data.DeliverTime = DeliverTime;
                data.deliveryamount = Convert.ToString(deliveryamount);
                data.delocation = delocation;
                data.Totalamount = Convert.ToString(Totalamount);
                TempData["mydata"] = data;
                return Json("/NewOrder/guestorder");
            }
        }



        //updating cart items
        [HttpPost]
        public JsonResult updatecart(string orderid, string productid, int quantity)
        {
            var updatedcart = AnkapurService.updatecart(orderid, productid, quantity);
            if (updatedcart > 0)
            {
                return Json("success");
            }
            return Json("unique", JsonRequestBehavior.AllowGet);
        }
        //Order confirmation page       
        public ActionResult orderview()
        {
            try
            {
                if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    string phonenumber = Session["CustPhoneNumber"].ToString();
                    string name = Session["CustomerFName"].ToString();
                    //  string address = Session["Delivery_Addresss"].ToString();
                    var addressdetails = AnkapurService.getaddressdetails(phonenumber);
                    var dta1 = new DataTable();
                    dta1.Load(addressdetails);
                    var address = (dta1.Rows[0]["Delivery_Addresss"].ToString());

                    //  string email = Session["Email"].ToString();
                    ViewBag.Phone = phonenumber;
                    ViewBag.Name = name;
                    ViewBag.Address = address;
                    //   ViewBag.Email = email;
                    DateTime orderdate = System.DateTime.Today;
                    string restcode = "HN";
                    var orderid1 = AnkapurService.orderidforconformpage(orderdate, restcode);
                    var dt = new DataTable();
                    dt.Load(orderid1);
                    string orderid = dt.Rows[0]["OrderId"].ToString();
                    var result = DateTime.Now.Year.ToString();

                    var orderid2 = orderid.Split('-')[0] + result + "-" + orderid.Split('-')[1];
                    if (orderid == "")
                    {
                        string month = DateTime.Now.ToString("MM");
                        string month1 = month.Substring(1, 1);
                        var year1 = DateTime.Now.Year.ToString();
                        orderid = "HN" + DateTime.Now.ToString("dd") + month1 + year1 + "-" + 1;
                    }
                    else
                    {
                        orderid = dt.Rows[0]["OrderId"].ToString();
                    }
                    ViewBag.orderidconfirm = orderid;
                    var details = AnkapurService.getbilldetails(phonenumber, orderid);
                    var dt1 = new DataTable();
                    dt1.Load(details);
                    var delivery = (dt1.Rows[0]["DeliveryArea"].ToString());
                    var totalamount = (dt1.Rows[0]["Totalamount"].ToString());
                    var cgst = (dt1.Rows[0]["CGST"].ToString());
                    var sgst = (dt1.Rows[0]["SGST"].ToString());
                    var deliverychrges = (dt1.Rows[0]["Deliverycharges"].ToString());
                    var deliverytime = (dt1.Rows[0]["ToBeDelivered"].ToString());
                    var actamount = Convert.ToDecimal(cgst) + Convert.ToDecimal(sgst) + Convert.ToInt32(deliverychrges);
                    var actamount1 = Convert.ToDecimal(totalamount) - Convert.ToDecimal(actamount);
                    int actamount2 = Convert.ToInt32(actamount1);
                    ViewBag.actamt = actamount2;
                    ViewBag.Totalamount = totalamount;
                    var tam = totalamount.Split('.');
                    ViewBag.Totalamount1 = tam[0] + "00";
                    ViewBag.orderid = orderid;
                    ViewBag.CGST = cgst;
                    ViewBag.SGST = sgst;
                    ViewBag.Deliverycharges = deliverychrges;
                    ViewBag.displaytime = deliverytime;
                    ViewBag.conformorderitems = conformpageitems();
                    ViewBag.sdarea = delivery;
                    ViewBag.orderid = orderid;
                    return View();
                }
                return RedirectToAction("guestorder", "NewOrder");
            }
            catch (Exception)
            {

                return RedirectToAction("guestorder", "NewOrder");
            }
        }


        public ActionResult guestorder(string otp)

        {
            if (otp == "" || otp == null)
            {
                //  otp = "1";
                try
                {
                    placeorder data = TempData["mydata"] as placeorder;
                    TempData.Peek("mydata");
                    string RestCode = data.RestCode; string CustomerRequest = data.customerrequest; string DeliverTime = data.DeliverTime; string Totalamount = data.Totalamount; string cgst1 = data.cgst; string sgst1 = data.sgst; string deliveryamount = data.deliveryamount; string cartdata = data.cartdata; string delocation = data.delocation;
                    ViewBag.restcode = RestCode;
                    ViewBag.delocation = delocation;
                    ViewBag.CustomerResquest = CustomerRequest;
                    ViewBag.DeliverTime = DeliverTime;
                    ViewBag.totalamont = Totalamount;
                    ViewBag.cgst = cgst1;
                    ViewBag.sgst1 = sgst1;
                    ViewBag.deliveryamount = deliveryamount;
                    ViewBag.cartdata = cartdata;
                    TblNewCustomer obj = new TblNewCustomer();
                    var a = new Tuple<TblNewCustomer, placeorder>(obj, data);
                    return View(a);
                }
                catch (Exception)
                {
                    //  return RedirectToAction("guestorder", "NewOrder");
                    return Content("<script language='javascript' type='text/javascript'>alert('Please Placeorder');location.href='" + @Url.Action("Index", "GetRestaurant") + "'</script>");
                }
            }
            return View();
        }
        // guestorder
        [HttpPost]
        public ActionResult addguest([Bind(Prefix = "Item2")] placeorder data, [Bind(Prefix = "Item1")] TblNewCustomer obj) //string CustomerPhoneNumber, string CustomerName, string Address, string status
        {
            try
            {
                string RestCode = data.RestCode; string CustomerRequest = data.customerrequest; string DeliverTime = data.DeliverTime; string Totalamount = data.Totalamount; string cgst1 = data.cgst; string sgst1 = data.sgst; string deliveryamount = data.deliveryamount; string cartdata = data.cartdata; string delocation = data.delocation;
                if (delocation == "null")
                { delocation = Response.Cookies["restsd"].Value; }
                string productids = null; string productqty = null;

                using (AnkapurEntities db = new AnkapurEntities())
                {
                    var customerphone = obj.CustPhoneNumber;
                    var customername = obj.CustomerFName;
                    var deliveryaddress = obj.Delivery_Addresss;
                    if (customerphone == null)
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert('Please Enter valid Phonenumber');location.href='" + @Url.Action("Index", "Neworder") + "'</script>");
                    }
                    else if (customerphone != null && customerphone.Length != 10)
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert('Please Enter valid Phonenumber');location.href='" + @Url.Action("Index", "Neworder") + "'</script>");
                    }

                    if (customername == null)
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert('Please Enter customername');location.href='" + @Url.Action("Index", "Neworder") + "'</script>");
                    }
                    if (deliveryaddress == null)
                    {
                        return Content("<script language='javascript' type='text/javascript'>alert('Please Enter address');location.href='" + @Url.Action("Index", "Neworder") + "'</script>");
                    }
                    else
                    {
                        var details = (from userlist in db.TblNewCustomers
                                       where userlist.CustPhoneNumber == customerphone
                                       select new
                                       {
                                           userlist.CustPhoneNumber,
                                           userlist.CustomerFName,
                                           userlist.Delivery_Addresss,
                                           userlist.Status

                                       }).ToList();

                        if (details.FirstOrDefault() != null)
                        {
                            if (details.FirstOrDefault().Status == "ACTIVE")
                            {
                                AnkapurService.guestupdatecustomer(obj.CustPhoneNumber, obj.CustomerFName, obj.Delivery_Addresss, "ACTIVE");
                                string userData1 = JsonConvert.SerializeObject(obj);
                                ValidUser.SetAuthCookie(userData1, obj.CustPhoneNumber);
                                Session["CustPhoneNumber"] = obj.CustPhoneNumber;
                                Session["CustomerFName"] = obj.CustomerFName;
                                Session["Delivery_Addresss"] = obj.Delivery_Addresss;
                                var data1 = AnkapurService.placeorder(customerphone, RestCode, CustomerRequest, DeliverTime, decimal.Parse(Totalamount), decimal.Parse(cgst1), decimal.Parse(sgst1), Convert.ToInt16(deliveryamount), delocation);
                                string cd = cartdata;
                                string[] cdvalues = cd.Split(',');
                                for (int i = 0; i < cdvalues.Length; i++)
                                {
                                    if (cdvalues[i] != "null" && cdvalues[i].Split('-')[0] != "null" && cdvalues[i].Split('-')[1] != "null")
                                    {
                                        productids = productids + "," + cdvalues[i].Split('-')[0];
                                        productqty = productqty + "," + cdvalues[i].Split('-')[1];
                                    }
                                }
                                productids = productids.TrimStart(',');
                                productqty = productqty.TrimStart(',');
                                var orderid = generateorderidforwebcart();
                                string oid = orderid.FirstOrDefault().Orderid;
                                if (oid == "")
                                {
                                    string month = DateTime.Now.ToString("MM");
                                    string month1 = month.Substring(1, 1);
                                    oid = "HN" + DateTime.Now.ToString("dd") + month1 + "-" + 1;
                                }
                                else
                                {
                                    oid = orderid.FirstOrDefault().Orderid;
                                }
                                for (int i = 0; i < productids.Split(',').Length; i++)
                                {
                                    var cartitems = AnkapurService.insertdetailsidbase(oid, productids.Split(',')[i], Convert.ToInt32(productqty.Split(',')[i].ToString()));
                                }
                                return RedirectToAction("guestorder", "NewOrder", new { otp = obj.CustPhoneNumber });
                            }

                            int lengthOfPassword = 5;
                            string guid = Guid.NewGuid().ToString().Replace("-", "");
                            string OTP = guid.Substring(0, lengthOfPassword).ToUpper();

                            SMSCAPI.ServiceSoapClient obj2 = new SMSCAPI.ServiceSoapClient();
                            string strPostResponse1 = obj2.SendTextSMS("ankapurchicken", "ankapur6900", customerphone.ToString(), "Welcome to Ankapur Chicken OTP for activating your account is" + "    " + OTP.ToString(), "ANKPUR");
                            string delReport1 = obj2.Getbalance("ankapurchicken", "ankapur6900");
                            AnkapurService.updatecustomerotp(obj.CustPhoneNumber, obj.CustomerFName, obj.Delivery_Addresss, OTP);

                            return RedirectToAction("guestorder", "NewOrder", new { otp = obj.CustPhoneNumber });
                        }

                        else
                        {

                            int lengthOfPassword = 5;
                            string guid = Guid.NewGuid().ToString().Replace("-", "");
                            string OTP = guid.Substring(0, lengthOfPassword).ToUpper();

                            SMSCAPI.ServiceSoapClient obj2 = new SMSCAPI.ServiceSoapClient();
                            string strPostResponse1 = obj2.SendTextSMS("ankapurchicken", "ankapur6900", customerphone.ToString(), "Welcome to Ankapur Chicken OTP for activating your account is" + "    " + OTP.ToString(), "ANKPUR");
                            string delReport1 = obj2.Getbalance("ankapurchicken", "ankapur6900");
                            AnkapurService.Registercustomer(obj.CustPhoneNumber, obj.CustomerFName, "guest", obj.Delivery_Addresss, OTP, "INACTIVE");
                            return RedirectToAction("guestorder", "NewOrder", new { otp = obj.CustPhoneNumber });
                        }

                    }
                }
            }
            catch (Exception)
            {
                //  return RedirectToAction("guestorder", "NewOrder");
                return Content("<script language='javascript' type='text/javascript'>alert('The Phone number is already registered Please Login ');location.href='" + @Url.Action("Index", "Home") + "'</script>");
            }
        }



        public JsonResult checkotp(TblNewCustomer obj, string OTP, string CustomerPhonenumber, string RestCode, string CustomerRequest, string DeliverTime, decimal Totalamount, decimal cgst1, decimal sgst1, int deliveryamount, string cartdata, string delocation)
        {

            var data = AnkapurService.checkotp(OTP, CustomerPhonenumber);
            DataTable dt = new DataTable();
            dt.Load(data);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["EmpStatus"].ToString() == "Does not Exist")
                {
                    return Json("failed");
                }
                else
                {
                    return Json("success");
                    // return RedirectToAction("orderview", "NewOrder", new { area = @ViewBag.sdarea });
                }
            }
            else
            {
                string productids = null; string productqty = null;
                var data1 = AnkapurService.placeorder(CustomerPhonenumber, RestCode, CustomerRequest, DeliverTime, (Totalamount), (cgst1), (sgst1), Convert.ToInt16(deliveryamount), delocation);
                string cd = cartdata;
                string[] cdvalues = cd.Split(',');
                for (int i = 0; i < cdvalues.Length; i++)
                {
                    if (cdvalues[i] != "null" && cdvalues[i].Split('-')[0] != "null" && cdvalues[i].Split('-')[1] != "null")
                    {
                        productids = productids + "," + cdvalues[i].Split('-')[0];
                        productqty = productqty + "," + cdvalues[i].Split('-')[1];
                    }
                }
                productids = productids.TrimStart(',');
                productqty = productqty.TrimStart(',');
                var orderid = generateorderidforwebcart();
                string oid = orderid.FirstOrDefault().Orderid;
                if (oid == "")
                {
                    string month = DateTime.Now.ToString("MM");
                    string month1 = month.Substring(1, 1);
                    oid = "HN" + DateTime.Now.ToString("dd") + month1 + "-" + 1;
                }
                else
                {
                    oid = orderid.FirstOrDefault().Orderid;
                }
                for (int i = 0; i < productids.Split(',').Length; i++)
                {
                    var cartitems = AnkapurService.insertdetailsidbase(oid, productids.Split(',')[i], Convert.ToInt32(productqty.Split(',')[i].ToString()));
                }
                var detail = AnkapurService.guestloginnewcust(CustomerPhonenumber);
                var dt1 = new DataTable();
                dt1.Load(detail);
                var deliverADDRESS = (dt1.Rows[0]["Delivery_Addresss"].ToString());
                var CustomerFName = (dt1.Rows[0]["CustomerFName"].ToString());
                obj.CustPhoneNumber = CustomerPhonenumber;
                obj.CustomerFName = CustomerFName;
                obj.Delivery_Addresss = deliverADDRESS;
                string userData1 = JsonConvert.SerializeObject(obj);
                ValidUser.SetAuthCookie(userData1, obj.CustPhoneNumber);
                Session["CustPhoneNumber"] = obj.CustPhoneNumber;
                Session["CustomerFName"] = obj.CustomerFName;
                Session["Delivery_Addresss"] = obj.Delivery_Addresss;
                return Json("success");
            }
        }

        [HttpPost]
        public ActionResult Login([Bind(Prefix = "Item2")] placeorder data, [Bind(Prefix = "Item1")] TblNewCustomer obj)
        {
            try
            {
                string RestCode = data.RestCode; string CustomerRequest = data.customerrequest; string DeliverTime = data.DeliverTime; string Totalamount = data.Totalamount; string cgst1 = data.cgst; string sgst1 = data.sgst; string deliveryamount = data.deliveryamount; string cartdata = data.cartdata; string delocation = data.delocation;
                string productids = null; string productqty = null;
                if (ModelState.IsValid)
                {
                    using (AnkapurEntities db = new AnkapurEntities())
                    {
                        var customerphone = obj.CustPhoneNumber;
                        var pw = obj.Password;
                        string restcode = ViewBag.restcode;
                        if (customerphone == null || pw == null)
                        {
                            return Content("<script language='javascript' type='text/javascript'>location.href='" + @Url.Action("Index", "Home") + "'</script>");
                        }
                        else if (customerphone.Length < 10)
                        {
                            return Content("<script language='javascript' type='text/javascript'>alert('Please Enter the valid Phonenumber');location.href='" + @Url.Action("Index", "Home") + "'</script>");
                        }
                        else
                        {
                            var details = (from userlist in db.TblNewCustomers
                                           where userlist.CustPhoneNumber == obj.CustPhoneNumber && userlist.Password == obj.Password
                                           select new
                                           {
                                               userlist.CustPhoneNumber,
                                               userlist.CustomerFName,
                                               userlist.Delivery_Addresss,
                                               userlist.Email,
                                               userlist.Status

                                           }).ToList();

                            if (details.FirstOrDefault() != null)
                            {
                                if (details.FirstOrDefault().Status == "ACTIVE")
                                {
                                    string userData = JsonConvert.SerializeObject(details.FirstOrDefault());
                                    ValidUser.SetAuthCookie(userData, details.FirstOrDefault().CustPhoneNumber);
                                    Session["CustPhoneNumber"] = details.FirstOrDefault().CustPhoneNumber;
                                    Session["CustomerFName"] = details.FirstOrDefault().CustomerFName;
                                    Session["Delivery_Addresss"] = details.FirstOrDefault().Delivery_Addresss;

                                    var data1 = AnkapurService.placeorder(customerphone, RestCode, CustomerRequest, DeliverTime, decimal.Parse(Totalamount), decimal.Parse(cgst1), decimal.Parse(sgst1), Convert.ToInt16(deliveryamount), delocation);

                                    string cd = cartdata;
                                    string[] cdvalues = cd.Split(',');

                                    for (int i = 0; i < cdvalues.Length; i++)
                                    {
                                        if (cdvalues[i] != "null" && cdvalues[i].Split('-')[0] != "null" && cdvalues[i].Split('-')[1] != "null")
                                        {
                                            productids = productids + "," + cdvalues[i].Split('-')[0];
                                            productqty = productqty + "," + cdvalues[i].Split('-')[1];
                                        }
                                    }
                                    productids = productids.TrimStart(',');
                                    productqty = productqty.TrimStart(',');
                                    var orderid = generateorderidforwebcart();

                                    string oid = orderid.FirstOrDefault().Orderid;
                                    if (oid == "")
                                    {
                                        string month = DateTime.Now.ToString("MM");
                                        string month1 = month.Substring(1, 1);
                                        oid = "HN" + DateTime.Now.ToString("dd") + month1 + "-" + 1;
                                    }
                                    else
                                    {
                                        oid = orderid.FirstOrDefault().Orderid;
                                    }
                                    for (int i = 0; i < productids.Split(',').Length; i++)
                                    {
                                        var cartitems = AnkapurService.insertdetailsidbase(oid, productids.Split(',')[i], Convert.ToInt32(productqty.Split(',')[i].ToString()));
                                    }


                                    return RedirectToAction("orderview", "NewOrder", new { area = @ViewBag.sdarea });

                                }
                                else
                                {

                                    return Content("<script language='javascript' type='text/javascript'>alert('Mobile is not Verified Please Register to verify');location.href='" + @Url.Action("Index", "Home") + "'</script>");
                                }
                            }
                            else
                            {
                                return Content("<script language='javascript' type='text/javascript'>alert('Invalid Credentials login failed');location.href='" + @Url.Action("Index", "neworder") + "'</script>");
                            }

                        }

                    }
                }
                return RedirectToAction("/Home/Index");


            }
            catch (Exception)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Restaurant is closed at the moment');location.href='" + @Url.Action("Index", "Home") + "'</script>");
            }
        }







        // Validating promo code
        [HttpPost]
        public JsonResult validatepromo(string pcode)
        {
            var data = AnkapurService.checkpromo(pcode);
            DataTable dt = new DataTable();
            dt.Load(data);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["EmpStatus"].ToString() == "Does not Exist")
                {
                    return Json("failed");
                }
                else
                {
                    return Json("success");
                }
            }
            else
            {
                return Json("success");
            }
        }

        ////loading cart for conform page
        public List<Products> conformpageitems()
        {
            DateTime orderdate = System.DateTime.Today;
            string restcode = "HN";
            var orderid1 = AnkapurService.orderidforconformpage(orderdate, restcode);
            var dt = new DataTable();
            dt.Load(orderid1);
            string orderid = dt.Rows[0]["OrderId"].ToString();
            var result = DateTime.Now.Year.ToString();
            var orderid2 = orderid.Split('-')[0] + result + "-" + orderid.Split('-')[1];
            if (orderid == "")
            {
                string month = DateTime.Now.ToString("MM");
                string month1 = month.Substring(1, 1);
                var year = DateTime.Now.Year.ToString();
                orderid = "HN" + DateTime.Now.ToString("dd") + month1 + year + "-" + 1;
            }
            else
            {
                orderid = dt.Rows[0]["OrderId"].ToString();
            }
            var cartdetails = AnkapurService.loadcartdetailsforconformpage(orderid);
            var dt1 = new DataTable();
            dt1.Load(cartdetails);
            List<Products> itemsforcp = (from DataRow row in dt1.Rows
                                         select new Products
                                         {
                                             //ProductId = row["ProductID"].ToString(),
                                             ProductName = row["ProductName"].ToString(),
                                             Price1 = (int)row["Price"],
                                             Image = row["Image"].ToString(),
                                             // Image = (Byte[])row["Image"],
                                             Quantity1 = (int)row["Quantity"]
                                             //ShortDescription = row["ShortDescription"].ToString(),
                                             //LongDescription = row["LongDescription"].ToString()
                                         }).ToList();
            return itemsforcp;
        }
        public List<Products> cartpageitems()
        {
            DateTime orderdate = System.DateTime.Today;
            string restcode = "HN";
            var orderid1 = AnkapurService.orderidforcartpage(orderdate, restcode);
            var dt = new DataTable();
            dt.Load(orderid1);
            string orderid = dt.Rows[0]["OrderId"].ToString();
            var result = DateTime.Now.Year.ToString();

            var orderid2 = orderid.Split('-')[0] + result + "-" + orderid.Split('-')[1];
            if (orderid == "")
            {
                string month = DateTime.Now.ToString("MM");
                string month1 = month.Substring(1, 1);
                var year = DateTime.Now.Year.ToString();
                orderid = "HN" + DateTime.Now.ToString("dd") + month1 + year + "-" + 1;
            }
            else
            {
                orderid = dt.Rows[0]["OrderId"].ToString();
            }
            //var orderid = "HN289-1";
            var cartdetails = AnkapurService.loadcartdetailsforconformpage(orderid2);
            var dt1 = new DataTable();
            dt1.Load(cartdetails);
            List<Products> itemsforcartp = (from DataRow row in dt1.Rows
                                            select new Products
                                            {
                                                //ProductId = row["ProductID"].ToString(),
                                                ProductName = row["ProductName"].ToString(),
                                                Price1 = (int)row["Price"],
                                                Image = row["Image"].ToString(),
                                                // Image = (Byte[])row["Image"],
                                                Quantity1 = (int)row["Quantity"]
                                                //ShortDescription = row["ShortDescription"].ToString(),
                                                //LongDescription = row["LongDescription"].ToString()
                                            }).ToList();
            return itemsforcartp;
        }
        //Update address in order confirmationpage
        public JsonResult updatingaddress(string phone, string address)
        {
            var updateaddress = AnkapurService.updatecustaddress(phone, address);
            if (updateaddress > 0)
            {
                return Json("success");
            }
            return Json("unique", JsonRequestBehavior.AllowGet);
        }
        //thank you page

        public ActionResult thankyoupage()
        {
            //try
            //{
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string phonenumber = Session["CustPhoneNumber"].ToString();
                string name = Session["CustomerFName"].ToString();


                var upaddress = AnkapurService.displayupdatedaddress(phonenumber);
                var datatable = new DataTable();
                datatable.Load(upaddress);
                string address = datatable.Rows[0]["Address"].ToString();
                ViewBag.Phone = phonenumber;
                ViewBag.Name = name;
                ViewBag.Address = address;
                DateTime orderdate = System.DateTime.Today;
                string restcode = "HN";
                var orderid1 = AnkapurService.orderidforconformpage(orderdate, restcode);
                var dt = new DataTable();
                dt.Load(orderid1);
                string orderid = dt.Rows[0]["OrderId"].ToString();
                var result = DateTime.Now.Year.ToString();

                var orderid2 = orderid.Split('-')[0] + result + "-" + orderid.Split('-')[1];
                if (orderid == "")
                {
                    string month = DateTime.Now.ToString("MM");
                    string month1 = month.Substring(1, 1);
                    var year = DateTime.Now.Year.ToString();
                    orderid = "HN" + DateTime.Now.ToString("dd") + month1 + year + "-" + 1;
                }
                else
                {
                    orderid = dt.Rows[0]["OrderId"].ToString();
                }
                ViewBag.orderidtq = orderid;

                var details = AnkapurService.getbilldetails(phonenumber, orderid);
                var dt1 = new DataTable();
                dt1.Load(details);
                var delivery = (dt1.Rows[0]["DeliveryArea"].ToString());
                var totalamount = (dt1.Rows[0]["Totalamount"].ToString());
                var cgst = (dt1.Rows[0]["CGST"].ToString());
                var sgst = (dt1.Rows[0]["SGST"].ToString());
                var deliverychrges = (dt1.Rows[0]["Deliverycharges"].ToString());
                var deliverytime = (dt1.Rows[0]["ToBeDelivered"].ToString());
                var dateoforder = (dt1.Rows[0]["OrderDate"].ToString());
                var otime = (dt1.Rows[0]["OrderTime"].ToString());
                var paytype = (dt1.Rows[0]["TransactionId"].ToString());
                var actamount = Convert.ToDecimal(cgst) + Convert.ToDecimal(sgst) + Convert.ToInt32(deliverychrges);
                var actamount1 = Convert.ToDecimal(totalamount) - Convert.ToDecimal(actamount);
                int actamount2 = Convert.ToInt32(actamount1);
                ViewBag.actamt = actamount2;
                ViewBag.Totalamount = totalamount;
                ViewBag.CGST = cgst;
                ViewBag.SGST = sgst;
                ViewBag.Deliverycharges = deliverychrges;
                ViewBag.displaytime = deliverytime;
                ViewBag.dateorder = dateoforder;
                ViewBag.ordertime = otime;
                ViewBag.paytype = paytype;

                //string darea = TempData["dellocation"].ToString();
                ViewBag.sdarea = delivery;
                return View();
            }
            return RedirectToAction("Index", "GetRestaurant");
            //}
            //catch (Exception)
            //{
            //    //     return View();
            //    return RedirectToAction("Index", "GetRestaurant");
            //}
        }







        //update orderstatus and confirm order
        public JsonResult updateorderstatus(string orderid, int statusid, string custinst, string promo)
        {

            string phonenumber = Session["CustPhoneNumber"].ToString();
            DateTime orderdate = System.DateTime.Today;
            string restcode = "HN";
            var orderid1 = AnkapurService.orderidforconformpage(orderdate, restcode);
            var dt = new DataTable();
            dt.Load(orderid1);
            string orderidforsms = dt.Rows[0]["OrderId"].ToString();

            if (orderid == "")
            {
                string month = DateTime.Now.ToString("MM");
                string month1 = month.Substring(1, 1);
                var year = DateTime.Now.Year.ToString();
                orderid = "HN" + DateTime.Now.ToString("dd") + month1 + year + "-" + 1;
            }
            else
            {
                string orderidnew1 = dt.Rows[0]["OrderId"].ToString();
            }
            var result = DateTime.Now.Year.ToString();

            var orderidforsms2 = orderid.Split('-')[0] + result + "-" + orderid.Split('-')[1];
            ViewBag.orderidtq = orderidforsms2;

            var details = AnkapurService.getbilldetails(phonenumber, orderid);
            var dt1 = new DataTable();
            dt1.Load(details);

            decimal totalamount = ((decimal)dt1.Rows[0]["Totalamount"]);

            SMSCAPI.ServiceSoapClient obj1 = new SMSCAPI.ServiceSoapClient();
            ////SMSCAPI.ServiceSoapClient obj2 = new SMSCAPI.ServiceSoapClient();
            ////SMSCAPI.ServiceSoapClient obj3 = new SMSCAPI.ServiceSoapClient();
            ////SMSCAPI.ServiceSoapClient obj4 = new SMSCAPI.ServiceSoapClient();
            string strPostResponse = obj1.SendTextSMS("ankapurchicken", "ankapur6900", "9000754777", "web order        Order id:" + orderidforsms.ToString() + "                       " + "Grand Total Rs:" + totalamount.ToString() + "              " + "Customer Phone: " + phonenumber.ToString() + "           ", "ANKPUR");
            ////string strPostResponse2 = obj1.SendTextSMS("ankapurchicken", "ankapur6900", "7382241213", "web order        Order id:" + orderidforsms.ToString() + "                       " + "Grand Total Rs:" + totalamount.ToString() + "              " + "Customer Phone: " + phonenumber.ToString() + "           ", "ANKPUR");
            ////string strPostResponse3 = obj1.SendTextSMS("ankapurchicken", "ankapur6900", "7842687670", "web order        Order id:" + orderidforsms.ToString() + "                       " + "Grand Total Rs:" + totalamount.ToString() + "              " + "Customer Phone: " + phonenumber.ToString() + "           ", "ANKPUR");
            ////string strPostResponse1 = obj2.SendTextSMS("ankapurchicken", "ankapur6900", phonenumber.ToString(), "Thank you for ordering with Ankapur Chicken your order is confirmed    Order id:" + orderid.ToString() + "   " + "Grand Total Rs:" + totalamount.ToString(), "ANKPUR");
            string delReport = obj1.Getbalance("ankapurchicken", "ankapur6900");
            ////string delReport1 = obj2.Getbalance("ankapurchicken", "ankapur6900");
            ////string delReport3 = obj1.Getbalance("ankapurchicken", "ankapur6900");
            //string delReport4 = obj2.Getbalance("ankapurchicken", "ankapur6900");
            //if (promo == "ANK5")
            //{
            //    //int discountamount = Convert.ToInt32(totalamount) / 100 * 5;
            //    //totalamount = totalamount - discountamount;
            //    int hun = Int32.Parse("100");
            //    Decimal divp = Decimal.Parse("5".Replace(".", "."));
            //    // Decimal amt = hun * divp;


            //    decimal discountamt = (totalamount) / hun * divp;


            //    totalamount = (totalamount - discountamt);
            //}
            var pmstatus = "USED";

            var data = AnkapurService.updateorderstatus(orderid, statusid, custinst, promo, pmstatus, totalamount);
            if (data > 0)
            {
                return Json("success");
            }
            return Json("unique", JsonRequestBehavior.AllowGet);

        }
        //public JsonResult cancelorder(string orderid, int statusid, string custinst)
        //{
        //    var data = AnkapurService.updateorderstatus(orderid, statusid, custinst);
        //    if (data > 0)
        //    {
        //        return Json("success");
        //    }
        //    return Json("unique", JsonRequestBehavior.AllowGet);
        //}
        //updating order start
        [HttpPost]
        public JsonResult updateorder(decimal Totalamount, decimal cgst1, decimal sgst1, int deliveryamount, string cartdata, string DeliverTime)
        {
            DateTime orderdate = System.DateTime.Today;
            string restcode = "HN";
            var orderid1 = AnkapurService.orderidforconformpage(orderdate, restcode);
            var dt = new DataTable();
            dt.Load(orderid1);
            string orderid = dt.Rows[0]["OrderId"].ToString();
            if (orderid == "")
            {
                string month = DateTime.Now.ToString("MM");
                string month1 = month.Substring(1, 1);
                orderid = "HN" + DateTime.Now.ToString("dd") + month1 + "-" + 1;
            }
            else
            {
                orderid = dt.Rows[0]["OrderId"].ToString();
            }

            string checksum = "NA";
            string productids = null; string productqty = null;
            var ddata = AnkapurService.deleteorderdetails(orderid);
            var data = AnkapurService.updateorder(orderid, Totalamount, cgst1, sgst1, deliveryamount, checksum, DeliverTime);

            string cd = cartdata;
            string[] cdvalues = cd.Split(',');

            for (int i = 0; i < cdvalues.Length; i++)
            {
                if (cdvalues[i] != "null" && cdvalues[i].Split('-')[0] != "null" && cdvalues[i].Split('-')[1] != "null")
                {
                    productids = productids + "," + cdvalues[i].Split('-')[0];
                    productqty = productqty + "," + cdvalues[i].Split('-')[1];
                }
            }
            productids = productids.TrimStart(',');
            productqty = productqty.TrimStart(',');
            //var orderid = generateorderidforwebcart();

            //string oid = orderid.FirstOrDefault().Orderid;
            //if (oid == "")
            //{
            //    string month = DateTime.Now.ToString("MM");
            //    string month1 = month.Substring(1, 1);
            //    oid = "HN" + DateTime.Now.ToString("dd") + month1 + "-" + 1;
            //}
            //else
            //{
            //    oid = orderid.FirstOrDefault().Orderid;
            //}
            for (int i = 0; i < productids.Split(',').Length; i++)
            {
                var cartitems = AnkapurService.insertdetailsidbase(orderid, productids.Split(',')[i], Convert.ToInt32(productqty.Split(',')[i].ToString()));
            }

            if (data == 1)
            {
                //ViewBag.customerphone = customerPhone;
                //ViewBag.restcode = RestCode;
                //ViewBag.customerrequest = CustomerRequest;

                //ViewBag.delivertime = DeliverTime;
                ViewBag.totalamount = Totalamount;

                return Json("success");
            }

            return Json("unique", JsonRequestBehavior.AllowGet);
        }
        //updating order end

        //View Order start
        public ActionResult ViewOrder()
        {
            try
            {
                if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    string name = Session["CustomerFName"].ToString();
                    ViewBag.Name = name;
                    ViewBag.orderhistory = Odtails();
                    //ViewBag.itemsod = ordereditems();
                    return View();
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return View();
                //        return RedirectToAction("Index", "Home");
            }
        }

        //View Order end

        public List<OrderDetails> Odtails()
        {
            string phonenumber = Session["CustPhoneNumber"].ToString();
            string restcode = "HN";
            var od = AnkapurService.vieworderdetails(restcode, phonenumber);
            var dt = new DataTable();
            dt.Load(od);
            List<OrderDetails> orderDetailsResponse = (from DataRow data in dt.Rows
                                                       select new OrderDetails
                                                       {
                                                           OrderId = data["OrderId"].ToString(),
                                                           OrderDate = (data["OrderDate"].ToString()),
                                                           OrderTime = (data["OrderTime"].ToString()),
                                                           Restcode = data["RestCode"].ToString(),
                                                           Orderstatus = data["Orderstatus"].ToString(),
                                                           Totalamount = (decimal)data["TotalAmount"]
                                                       }).ToList();
            return orderDetailsResponse;
        }

        //update customer profile
        public ActionResult updatecustomerprofile()
        {
            try
            {
                if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {

                    string phone = Session["CustPhoneNumber"].ToString();
                    ViewBag.pn = phone;

                    var data = AnkapurService.getprofiledetails(phone);
                    var dt = new DataTable();
                    dt.Load(data);
                    string cname = dt.Rows[0]["name"].ToString();
                    string cemail = dt.Rows[0]["Email"].ToString();
                    string altmobile = dt.Rows[0]["altmobile"].ToString();
                    string caddress = dt.Rows[0]["address"].ToString();
                    string image = dt.Rows[0]["ProfilePic"].ToString();

                    ViewBag.Name = cname;
                    ViewBag.deladdress = caddress;
                    ViewBag.eid = cemail;
                    ViewBag.altmobile = altmobile;
                    ViewBag.pimage = image;
                    return View();
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Home");
            }
        }


        //image upload
        [HttpPost]
        public ActionResult updatecontactpersonimage(HttpPostedFileBase helpSectionImages, string con_id)
        {
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["helpSectionImages"];
                Image img = Bitmap.FromStream(pic.InputStream);
                ImageConverter _imageConverter = new ImageConverter();
                byte[] contactimage = (byte[])_imageConverter.ConvertTo(img, typeof(byte[]));
                string base64String = Convert.ToBase64String(contactimage);
                return Json(base64String);
            }
            return Json(JsonRequestBehavior.AllowGet);
        }

        //update profile
        public JsonResult updateprofile(string phone, string fname, string email, string altmobile, string address, string image)
        {
            string im1 = image.Replace("data:image;base64,", "");
            var data = AnkapurService.updateprofile(phone, fname, email, altmobile, address, im1);
            if (data > 0)
            {
                return Json("success");
            }
            return Json("unique", JsonRequestBehavior.AllowGet);
        }
        //public List<Products> ordereditems()
        //{
        //    string orderid = Odtails().FirstOrDefault().OrderId;
        //    var cartdetails = AnkapurService.loadcartdetailsforconformpage(orderid);
        //    var dt1 = new DataTable();
        //    dt1.Load(cartdetails);
        //    List<Products> itemsforcp = (from DataRow row in dt1.Rows
        //                                 select new Products
        //                                 {
        //                                     //ProductId = row["ProductID"].ToString(),
        //                                     ProductName = row["ProductName"].ToString(),
        //                                     Price1 = (int)row["Price"],
        //                                     Image = (Byte[])row["Image"],
        //                                     Quantity1 = (int)row["Quantity"]
        //                                     //ShortDescription = row["ShortDescription"].ToString(),
        //                                     //LongDescription = row["LongDescription"].ToString()
        //                                 }).ToList();
        //    return itemsforcp;
        //}

        class payees
        {
            public string id { get; set; }
            public string entity { get; set; }
            public string amount { get; set; }
            public string currency { get; set; }
            public string status { get; set; }
            public string order_id { get; set; }
            public string invoice_id { get; set; }
            public string international { get; set; }
            public string method { get; set; }
            public string amount_refunded { get; set; }
            public string refund_status { get; set; }
            public string captured { get; set; }
            public string description { get; set; }
            public string card_id { get; set; }
            public string bank { get; set; }
            public string wallet { get; set; }
            public string vpa { get; set; }
            public string email { get; set; }
            public List<ResponseData> notes { get; set; }

            public string contact { get; set; }
            public string fee { get; set; }
            public string tax { get; set; }
            public string error_code { get; set; }
            public string error_description { get; set; }
            public string created_at { get; set; }

        }
        public class ResponseData
        {
            public string address { get; set; }
            public string order_id { get; set; }
        }
        public JsonResult paymentorderstatus(string orderid, string custinst, string promo, string payment)
        {
            int statusid = 1;
            string phonenumber = Session["CustPhoneNumber"].ToString();
            DateTime orderdate = System.DateTime.Today;
            string restcode = "HN";
            var orderid1 = AnkapurService.orderidforconformpage(orderdate, restcode);
            var dt = new DataTable();
            dt.Load(orderid1);
            string orderidforsms = dt.Rows[0]["OrderId"].ToString();

            if (orderid == "")
            {
                string month = DateTime.Now.ToString("MM");
                string month1 = month.Substring(1, 1);
                var year = DateTime.Now.Year.ToString();
                orderid = "HN" + DateTime.Now.ToString("dd") + month1 + year + "-" + 1;
            }
            else
            {
                string orderidnew1 = dt.Rows[0]["OrderId"].ToString();
            }
            var result = DateTime.Now.Year.ToString();

            var orderidforsms2 = orderid.Split('-')[0] + result + "-" + orderid.Split('-')[1];
            ViewBag.orderidtq = orderidforsms2;

            var details = AnkapurService.getbilldetails(phonenumber, orderid);
            var dt1 = new DataTable();
            dt1.Load(details);

            decimal totalamount = ((decimal)dt1.Rows[0]["Totalamount"]);

            SMSCAPI.ServiceSoapClient obj1 = new SMSCAPI.ServiceSoapClient();
            ////SMSCAPI.ServiceSoapClient obj2 = new SMSCAPI.ServiceSoapClient();
            //SMSCAPI.ServiceSoapClient obj3 = new SMSCAPI.ServiceSoapClient();
            ////SMSCAPI.ServiceSoapClient obj4 = new SMSCAPI.ServiceSoapClient();
            string strPostResponse = obj1.SendTextSMS("ankapurchicken", "ankapur6900", "9000754777", "web order paid Online   Order id:" + orderidforsms.ToString() + "                       " + "Grand Total Rs:" + totalamount.ToString() + "              " + "Customer Phone: " + phonenumber.ToString() + "           ", "ANKPUR ");
            string strPostResponse1 = obj1.SendTextSMS("ankapurchicken", "ankapur6900", "7780352828", "web order paid Online   Order id:" + orderidforsms.ToString() + "                       " + "Grand Total Rs:" + totalamount.ToString() + "              " + "Customer Phone: " + phonenumber.ToString() + "           ", "ANKPUR");
            ////string strPostResponse2 = obj3.SendTextSMS("ankapurchicken", "ankapur6900", "7780352828", "web order        Order id:" + orderidforsms.ToString() + "                       " + "Grand Total Rs:" + totalamount.ToString() + "              " + "Customer Phone: " + phonenumber.ToString() + "           ", "ANKPUR");
            ////string strPostResponse3 = obj1.SendTextSMS("ankapurchicken", "ankapur6900", "7842687670", "web order        Order id:" + orderidforsms.ToString() + "                       " + "Grand Total Rs:" + totalamount.ToString() + "              " + "Customer Phone: " + phonenumber.ToString() + "           ", "ANKPUR");
            ////string strPostResponse1 = obj2.SendTextSMS("ankapurchicken", "ankapur6900", phonenumber.ToString(), "Thank you for ordering with Ankapur Chicken your order is confirmed    Order id:" + orderid.ToString() + "   " + "Grand Total Rs:" + totalamount.ToString(), "ANKPUR");
            string delReport = obj1.Getbalance("ankapurchicken", "ankapur6900");
            ////string delReport1 = obj2.Getbalance("ankapurchicken", "ankapur6900");
            //string delReport3 = obj3.Getbalance("ankapurchicken", "ankapur6900");
            //string delReport4 = obj2.Getbalance("ankapurchicken", "ankapur6900");
            //if (promo == "ANK5")
            //{
            //    //int discountamount = Convert.ToInt32(totalamount) / 100 * 5;
            //    //totalamount = totalamount - discountamount;
            //    int hun = Int32.Parse("100");
            //    Decimal divp = Decimal.Parse("5".Replace(".", "."));
            //    // Decimal amt = hun * divp;


            //    decimal discountamt = (totalamount) / hun * divp;


            //    totalamount = (totalamount - discountamt);
            //}


            string paymentId = payment;
            decimal totalamount1 = totalamount * decimal.Parse("100.00");
            string tot = totalamount1.ToString().Split('.')[0];

            //Payment Section

            // RazorpayClient client = new RazorpayClient("rzp_test_3OHEkrM9aPMz5u", "WUA3WciyAExRDwRwxMIqU5Yb"); //test
            RazorpayClient client = new RazorpayClient("rzp_live_W09eYwUgy9DAI0", "hAYkcQhdf8ZEGfYXYyE0FEX1"); //live
            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            Payment payment1 = client.Payment.Fetch(paymentId);

            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", tot);

            Payment paymentCaptured = payment1.Capture(options);


            var pmstatus = "USED";

            //   var data = AnkapurService.updateorderstatus(orderid, statusid, custinst, promo, pmstatus, totalamount);
            var data = AnkapurService.paymentorderstatus(orderid, statusid, custinst, promo, pmstatus, totalamount, payment);

            if (data > 0)
            {
                return Json("success");
            }
            return Json("unique", JsonRequestBehavior.AllowGet);

        }

    }
}