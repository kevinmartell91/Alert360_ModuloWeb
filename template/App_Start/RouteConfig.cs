using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace template
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                //defaults: new { controller = "Home", action = "alertas", id = UrlParameter.Optional }
                //defaults: new { controller = "Home", action = "test", id = UrlParameter.Optional }
                //defaults: new { controller = "Home", action = "testLoginShake", id = UrlParameter.Optional }
                //defaults: new { controller = "Home", action = "modulo", id = UrlParameter.Optional }
                //defaults: new { controller = "Home", action = "SplitPanel", id = UrlParameter.Optional }
                defaults: new { controller = "Login", action = "index", id = UrlParameter.Optional }
            );
        }
    }
}