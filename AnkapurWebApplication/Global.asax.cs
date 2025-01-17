﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Newtonsoft.Json;
using AnkapurWebApplication.Models;
using AnkapurWebApplication.Content;
using System.Security.Cryptography;

namespace AnkapurWebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            try
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                if (authTicket != null)
                {
                    var serializeModel = JsonConvert.DeserializeObject<UserMaster>(authTicket.UserData);
                    var newUser = new CustomPrinciple(authTicket.Name)
                    {
                        ID = serializeModel.ID,
                        FirstName = serializeModel.First_Name,
                        LastName = serializeModel.Last_Name,
                        Emailid = serializeModel.EmailId,
                        Phone = serializeModel.Phone
                    };
                    HttpContext.Current.User = newUser;

                }
            }
            }
            catch (CryptographicException cex)
            {
                FormsAuthentication.SignOut();
            }
        }
    }
}
