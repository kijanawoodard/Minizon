using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Minizon.Admin.Web.Models;

namespace Minizon.Admin.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static List<Book> Books = new List<Book>
                                             {
                                                 new Book
                                                     {
                                                         Author = "Kijana Woodard",
                                                         ISBN = "1234",
                                                         Name = "How to beat the crap out of them"
                                                     }
                                                 ,
                                                 new Book
                                                     {
                                                         Author = "Sean Feldman",
                                                         ISBN = "4321",
                                                         Name = "Peace and harmony"
                                                     }
                                             };


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}