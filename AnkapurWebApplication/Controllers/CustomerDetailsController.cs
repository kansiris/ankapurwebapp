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
namespace AnkapurWebApplication.Controllers
{
    public class CustomerDetailsController : Controller
    {
        // GET: CustomerDetails
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult savecustomerdetails(Restaurant restaurant)
        {
            var data = AnkapurService.savecustomerdetails(restaurant.customerphone, restaurant.customername, restaurant.address, restaurant.password, restaurant.Email);
            if (data > 0)
            {
                ViewBag.customerphone = restaurant.customerphone;
                ViewBag.customername = restaurant.customername;
                ViewBag.address = restaurant.address;
                ViewBag.password = restaurant.password;
                ViewBag.Email = restaurant.Email;
                return Json("success");
            }
            return Json("unique", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult validatecustomer(Restaurant restaurant)
        {
            var data = AnkapurService.validatecustomer(restaurant.password, restaurant.customerphone);
            var dt = new DataTable();
            dt.Load(data);
            if (dt.Rows[0][0].ToString() != "Does not Exist")
            {
                //return Json("success");
                var urlBuilder = new UrlHelper(Request.RequestContext);
                var url = urlBuilder.Action("NewOrder", "Index");
                return Json(new { status = "success", redirectUrl = url });
            }
           
             return Json("unique", JsonRequestBehavior.AllowGet);

        }
    }
}