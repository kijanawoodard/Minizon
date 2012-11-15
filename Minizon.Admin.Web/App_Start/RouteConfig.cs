using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Minizon.Admin.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                // for a controller to handle RavenDB-like ids
                // http://weblogs.asp.net/shijuvarghese/archive/2010/06/04/how-to-work-ravendb-id-with-asp-net-mvc-routes.aspx
                url: "{controller}/{action}/{*id}",
                defaults: new { controller = "Book", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}