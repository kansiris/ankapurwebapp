using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ankapur.service;
using AnkapurWebApplication.Models;
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
using System.Web.Security;
using Microsoft.AspNet.Identity;
using AnkapurWebApplication.Content;

namespace AnkapurWebApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        LoginService loginService = new LoginService();
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var user = (CustomPrinciple)System.Web.HttpContext.Current.User;
                var profile = LoginService.GetUserProfile(int.Parse(user.Phone)); //Get's User Profile
                return RedirectToAction("index", "NewOrder");
            }
            return View();
        }
    }
}