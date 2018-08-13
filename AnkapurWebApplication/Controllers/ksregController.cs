using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnkapurWebApplication.Models;
using System.Web.Security;
using Ankapur.service;
using System.Data.SqlClient;
using System.Web.Routing;
using System.Web.Caching;
using System.Globalization;
using Microsoft.Web.Administration;
using System.IO;
//using Microsoft.SqlServer.Management.Common;
using System.Data;
using System.Web.Hosting;
using Ankapur.Utility;

using Microsoft.AspNet.Identity;
using AnkapurWebApplication.Content;
using Newtonsoft.Json;
using System.Web.UI;

namespace AnkapurWebApplication.Controllers
{
    public class ksregController : Controller
    {
        // GET: ksreg
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult logoff()
        {
            //ScriptManager.RegisterStartupScript(" localStorage.clear();");
            //Response.Write("<script>localStorage.clear();</scrip‌​>");
            FormsAuthentication.SignOut();
            // return RedirectToAction("Index", "Home");
            return Content("<script language='javascript' type='text/javascript'>sessionStorage.clear();localStorage.clear();location.href='" + @Url.Action("Index", "ksmenu") + "'</script>");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login reg1)
        {
            try
            {

                DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                int hour = indianTime.Hour;
                if (hour >= 10 && hour <= 20)
                {
                    if (ModelState.IsValid)
                    {
                        using (AnkapurEntities db = new AnkapurEntities())
                        {
                            var customerphone = reg1.CustPhoneNumber;
                            var pw = reg1.Password;
                            string restcode = ViewBag.restcode;
                            if (customerphone == null || pw == null)
                            {

                                return Content("<script language='javascript' type='text/javascript'>location.href='" + @Url.Action("Index", "ksmenu") + "'</script>");

                            }
                            else if (customerphone.Length < 10)
                            {
                                //ViewBag.vmobmsg = "Please Enter the valid Phonenumber";
                                return Content("<script language='javascript' type='text/javascript'>alert('Please Enter the valid Phonenumber');location.href='" + @Url.Action("Index", "ksmenu") + "'</script>");
                            }
                            else
                            {
                                var details = (from userlist in db.TblNewCustomers
                                               where userlist.CustPhoneNumber == reg1.CustPhoneNumber && userlist.Password == reg1.Password
                                               select new
                                               {
                                                   userlist.CustPhoneNumber,
                                                   userlist.CustomerFName,
                                                   userlist.Delivery_Addresss,
                                                   userlist.Email,
                                                   userlist.Status

                                               }).ToList();
                                //if (details.FirstOrDefault().Status == "ACTIVE")
                                //{
                                if (details.FirstOrDefault() != null)
                                {
                                    if (details.FirstOrDefault().Status == "ACTIVE")
                                    {
                                        string userData = JsonConvert.SerializeObject(details.FirstOrDefault());
                                        ValidUser.SetAuthCookie(userData, details.FirstOrDefault().CustPhoneNumber);
                                        //TempData.Keep("CustPhoneNumber");
                                        //TempData["CustPhoneNumber"] = details.FirstOrDefault().CustPhoneNumber;
                                        //TempData.Peek("CustPhoneNumber");
                                        //TempData["CustomerFName"] = details.FirstOrDefault().CustomerFName;
                                        //TempData.Peek("CustomerFName");
                                        //TempData["Delivery_Addresss"] = details.FirstOrDefault().Delivery_Addresss;
                                        //TempData.Peek("Delivery_Addresss");
                                        //TempData["Email"] = details.FirstOrDefault().Email;
                                        //TempData.Peek("Email");
                                        Session["CustPhoneNumber"] = details.FirstOrDefault().CustPhoneNumber;
                                        Session["CustomerFName"] = details.FirstOrDefault().CustomerFName;
                                        Session["Delivery_Addresss"] = details.FirstOrDefault().Delivery_Addresss;
                                        // Session["Email"] = details.FirstOrDefault().Email;

                                        if (restcode == "Null")
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>location.href='" + @Url.Action("Index", "ksmenu") + "'</script>");

                                        }
                                        else
                                        {
                                            return Content("<script language='javascript' type='text/javascript'>location.href='" + @Url.Action("Index", "ksmenu") + "'</script>");
                                            //return Content("<script language='javascript' type='text/javascript'>alert('Invalid Credentials login failed');location.href='" + @Url.Action("Index", "Home") + "'</script>");
                                        }
                                    }
                                    else
                                    {
                                        //ViewBag.nvmsg = "Mobile is not Verified Please Register to verify";
                                        return Content("<script language='javascript' type='text/javascript'>alert('Mobile is not Verified Please Register to verify');location.href='" + @Url.Action("Index", "ksmenu") + "'</script>");
                                    }
                                }
                                else
                                {
                                    return Content("<script language='javascript' type='text/javascript'>alert('Invalid Credentials login failed');location.href='" + @Url.Action("Index", "ksmenu") + "'</script>");
                                }

                            }

                        }
                    }
                    return RedirectToAction("/Home/Index");
                }
                else
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Restaurant is closed at the moment');location.href='" + @Url.Action("Index", "ksmenu") + "'</script>");
                }

            }
            catch (Exception)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Restaurant is closed at the moment');location.href='" + @Url.Action("Index", "ksmenu") + "'</script>");
            }
        }

        private static TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        [HttpPost]
        public JsonResult Registrationpage(string CustomerPhoneNumber, string CustomerName, string Password, string Address)
        {
            try
            {
                int lengthOfPassword = 5;
                string guid = Guid.NewGuid().ToString().Replace("-", "");
                string OTP = guid.Substring(0, lengthOfPassword).ToUpper();

                SMSCAPI.ServiceSoapClient obj2 = new SMSCAPI.ServiceSoapClient();
                string strPostResponse1 = obj2.SendTextSMS("ankapurchicken", "ankapur6900", CustomerPhoneNumber.ToString(), "Welcome to Ankapur Chicken OTP for activating your account is" + "    " + OTP.ToString(), "ANKPUR");
                string delReport1 = obj2.Getbalance("ankapurchicken", "ankapur6900");
                var data = AnkapurService.Registercustomer(CustomerPhoneNumber, CustomerName, Password, Address, OTP, "INACTIVE");
                if (data > 0)
                {
                    return Json("success");
                }
                return Json("unique", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Failed");
            }
        }
        public JsonResult sendpassword(string phone)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    using (AnkapurEntities db = new AnkapurEntities())
                    {
                        var customerphone = phone;
                        if (customerphone == null)
                        {

                            Content("<script language='javascript' type='text/javascript'> alert('Please Enter the Valid Phonenumber');location.href='" + @Url.Action("Index", "ksmenu") + "' </script>");

                        }
                        else if (customerphone.Length < 10)
                        {
                            //ViewBag.vmobmsg = "Please Enter the valid Phonenumber";
                            Content("<script language='javascript' type='text/javascript'>alert('Please Enter the valid Phonenumber');location.href='" + @Url.Action("Index", "ksmenu") + "'</script>");
                        }
                        else
                        {
                            var details = (from userlist in db.TblNewCustomers
                                           where userlist.CustPhoneNumber == phone
                                           select new
                                           {
                                               userlist.CustPhoneNumber,
                                               userlist.CustomerFName,
                                               userlist.Delivery_Addresss,
                                               userlist.Email,
                                               userlist.Status

                                           }).ToList();
                            //if (details.FirstOrDefault().Status == "ACTIVE")
                            //{
                            if (details.FirstOrDefault() != null)
                            {
                                if (details.FirstOrDefault().Status == "ACTIVE")
                                {



                                    var password = AnkapurService.sendpwtocustomer(phone);
                                    if (password.HasRows)
                                    {
                                        var dt = new DataTable();
                                        dt.Load(password);
                                        string pw = dt.Rows[0]["Password"].ToString();
                                        SMSCAPI.ServiceSoapClient obj2 = new SMSCAPI.ServiceSoapClient();
                                        string strPostResponse1 = obj2.SendTextSMS("ankapurchicken", "ankapur6900", phone.ToString(), "Welcome to Ankapur Chicken Password for your account is" + "    " + pw.ToString(), "ANKPUR");
                                        string delReport1 = obj2.Getbalance("ankapurchicken", "ankapur6900");
                                        return Json("success");
                                        //return Json("exists");
                                    }
                                    else
                                    {
                                        if (password.FieldCount == 0)
                                        {
                                            return Json("exists");

                                        }
                                        else
                                        {
                                            Content("<script language='javascript' type='text/javascript'>alert('Phonenumber is not Found Please Register');location.href='" + @Url.Action("Index", "ksmenu") + "'</script>");
                                        }
                                    }
                                    return Json("unique", JsonRequestBehavior.AllowGet);
                                }
                            }
                        }
                    }
                }
                return Json("unique", JsonRequestBehavior.AllowGet);

            }

            catch (Exception)
            {
                return Json("Failed");
            }
        }
        public JsonResult checkotp(string OTP, string CustomerPhonenumber)
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
                }
            }
            else
            {
                return Json("success");
            }
        }
    }
}