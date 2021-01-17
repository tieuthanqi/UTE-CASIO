using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DongHoCasio
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Cart",
               url: "gio-hang",
               defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "DongHoCasio.Controllers" }
           );
            routes.MapRoute(
               name: "dang nhap",
               url: "dang-nhap",
               defaults: new { controller = "Home", action = "Login", id = UrlParameter.Optional },
               namespaces: new string[] { "DongHoCasio.Controllers" }
           );


            routes.MapRoute(
                name: "Them gio hang",
                url: "them-gio-hang",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new string[] { "DongHoCasio.Controllers" }
            );
            routes.MapRoute(
                name: "Hoan thanh",
                url: "hoan-thanh",
                defaults: new { controller = "Cart", action = "HoanThanh", id = UrlParameter.Optional },
                namespaces: new string[] { "DongHoCasio.Controllers" }
            );
            routes.MapRoute(
                name: "Thanh toan",
                url: "thanh-toan",
                defaults: new { controller = "Cart", action = "ThanhToan", id = UrlParameter.Optional },
                namespaces: new string[] { "DongHoCasio.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "DongHoCasio.Controllers" }
            );

        }
    }
}
