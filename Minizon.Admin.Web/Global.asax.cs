using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Minizon.Admin.Web.Models;
using Raven.Client.Document;

namespace Minizon.Admin.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static DocumentStore DocumentStore;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            WireRavenDb();
        }

        private static void WireRavenDb()
        {
            DocumentStore = new DocumentStore
                                {
                                    ConnectionStringName = "RavenDB"
                                };
            DocumentStore.Initialize();
        }
    }
}