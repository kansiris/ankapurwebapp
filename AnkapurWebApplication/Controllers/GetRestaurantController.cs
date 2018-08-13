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
    public class GetRestaurantController : Controller
    {
        // GET: GetRestaurant
        //[OutputCache(NoStore = true, Duration = 0)]
        public ActionResult Index(string sd)
        {
            try
            {

                if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    
                    string name = Session["CustomerFName"].ToString();
                     ViewBag.Name = name;
                    ViewBag.Restaurants = getrestaurants();
            return View();
                 }
                ViewBag.Restaurants = getrestaurants();
                return View();
                //              else
                //               {
                //        return RedirectToAction("Index", "Home");
                //              }
            }
            catch (Exception)
            {

                return Content("<script language='javascript' type='text/javascript'>alert('Restaurant is closed at the moment');location.href='" + @Url.Action("Index", "Home") + "'</script>");
            }
        }
        public List<Restaurant> getrestaurants()
        {
            var restaurants = AnkapurService.getrestaurants();
            var dt = new DataTable();
            dt.Load(restaurants);
            List<Restaurant> rest = (from DataRow row in dt.Rows select new Restaurant() { restcode = row["RestCode"].ToString(), fullname = row["FullName"].ToString() }).ToList();
            return rest;
        }


        [HttpPost]
        public ActionResult Index(Restaurant restaurant, string sd)
         {
            try
            {
                //
                //               if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                //              {
                //                  //action="@Url.Action("Index", "NewOrder")"

                var rest = restaurant.restcode;
            //  var name = restaurant.fullname;
            if (rest == "---SELECT---")
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Please select the delivery area');location.href='" + @Url.Action("Index", "GetRestaurant") + "'</script>");

            }
            else if (rest != "---SELECT---")
            {
                var delarea = sd;
                if (delarea == null)
                {
                    delarea = "Himayat Nagar";
                }
               
                else
                {
                    delarea = sd;
                }
                return RedirectToAction("Index", "NewOrder", new { code = restaurant.restcode, area = delarea });
            }
            else
            {

                ViewBag.srmsg = "Please select the the delivery area";
                //    return Content("<script language='javascript' type='text/javascript'>alert('Please select the the delivery area');location.href='" + @Url.Action("Index", "GetRestaurant") + "'</script>");
            }
                //             }
                //            else
                //            {
                //                return RedirectToAction("Index", "Home");
                //            }
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}
