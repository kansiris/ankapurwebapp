//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using AnkapurWebApplication.Models;
//using Ankapur.service;
//using Ankapur.Utility;
//using System.Data;
//using Newtonsoft.Json;
//using System.Drawing;

//namespace AnkapurWebApplication.Controllers
//{
//    public class ksmenuController : Controller
//    {


//        // GET: ksmenu
//        public ActionResult Index(string area)
//        {
//            try
//            {
//                // if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
//                //  {
//                ViewBag.Products = products();
//                ViewBag.breakfast = breakfast();
//                ViewBag.addons = addons();
//                ViewBag.lunchanddinner = lunchanddinner();
//                ViewBag.pccombos = pccombos();
//                ViewBag.Code = "HN";
//                var darea = area;
//                if (darea == "")
//                { darea = "HN"; }
//                else
//                { darea = area; }
//                ViewBag.delocation = darea;
//                //delarea;
//                string restcodedisplay = ViewBag.Code;
//                string phonenumber = Session["CustPhoneNumber"].ToString();
//                string name = Session["CustomerFName"].ToString();
//                string address = Session["Delivery_Addresss"].ToString();
//                ViewBag.Phone = phonenumber;
//                ViewBag.Name = name;
//                ViewBag.Address = address;

//                return View();
//                //   }
//                //   return RedirectToAction("Index", "Home");
//            }
//            catch (Exception)
//            {
//                return View();
//                //            return RedirectToAction("Index", "Home");
//            }
//        }
//        //loading of the total products
//        public List<Products> products()
//        {
//            var prd = AnkapurService.Loadproducts();
//            var dt = new DataTable();
//            dt.Load(prd);
//            List<Products> prod = (from DataRow row in dt.Rows

//                                   select new Products
//                                   {
//                                       ProductId = row["ProductID"].ToString(),
//                                       ProductName = row["ProductName"].ToString(),
//                                       Price = row["Price"].ToString(),
//                                       Image = (Byte[])row["Image"],
//                                       Quantity = row["Quanity"].ToString(),
//                                       ShortDescription = row["ShortDescription"].ToString(),
//                                       LongDescription = row["LongDescription"].ToString()
//                                   }
//                                   ).ToList();
//            return prod;
//        }
//        //breakfast
//        public List<Products> breakfast()
//        {
//            var prd = AnkapurService.loadprodoncategory(4);
//            var dt = new DataTable();
//            dt.Load(prd);
//            List<Products> prod = (from DataRow row in dt.Rows
//                                   select new Products
//                                   {
//                                       ProductId = row["ProductID"].ToString(),
//                                       ProductName = row["ProductName"].ToString(),
//                                       Price = row["Price"].ToString(),
//                                       Image = (Byte[])row["Image"],
//                                       Quantity = row["Quanity"].ToString(),
//                                       ShortDescription = row["ShortDescription"].ToString(),
//                                       LongDescription = row["LongDescription"].ToString()
//                                   }).ToList();
//            return prod;
//        }
//        //addons
//        public List<Products> addons()
//        {
//            var prd = AnkapurService.loadprodoncategory(24);
//            var dt = new DataTable();
//            dt.Load(prd);
//            List<Products> prod = (from DataRow row in dt.Rows
//                                   select new Products
//                                   {
//                                       ProductId = row["ProductID"].ToString(),
//                                       ProductName = row["ProductName"].ToString(),
//                                       Price = row["Price"].ToString(),
//                                       Image = (Byte[])row["Image"],
//                                       Quantity = row["Quanity"].ToString(),
//                                       ShortDescription = row["ShortDescription"].ToString(),
//                                       LongDescription = row["LongDescription"].ToString()
//                                   }).ToList();
//            return prod;
//        }
//        //lunchanddinner
//        public List<Products> lunchanddinner()
//        {
//            var prd = AnkapurService.loadprodoncategory(20);
//            var dt = new DataTable();
//            dt.Load(prd);
//            List<Products> prod = (from DataRow row in dt.Rows
//                                   select new Products
//                                   {
//                                       ProductId = row["ProductID"].ToString(),
//                                       ProductName = row["ProductName"].ToString(),
//                                       Price = row["Price"].ToString(),
//                                       Image = (Byte[])row["Image"],
//                                       Quantity = row["Quanity"].ToString(),
//                                       ShortDescription = row["ShortDescription"].ToString(),
//                                       LongDescription = row["LongDescription"].ToString()
//                                   }).ToList();
//            return prod;
//        }
//        //combos

//        public List<Products> pccombos()
//        {
//            var prd = AnkapurService.loadprodoncategory1(21, 23, 8);
//            var dt = new DataTable();
//            dt.Load(prd);
//            List<Products> prod = (from DataRow row in dt.Rows
//                                   select new Products
//                                   {
//                                       ProductId = row["ProductID"].ToString(),
//                                       ProductName = row["ProductName"].ToString(),
//                                       Price = row["Price"].ToString(),
//                                       Image = (Byte[])row["Image"],
//                                       Quantity = row["Quanity"].ToString(),
//                                       ShortDescription = row["ShortDescription"].ToString(),
//                                       LongDescription = row["LongDescription"].ToString()
//                                   }).ToList();
//            return prod;
//        }


      
//    }

//    }