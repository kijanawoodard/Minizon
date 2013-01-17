using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Dependencies;
using NServiceBus;
using Newtonsoft.Json.Serialization;
using Raven.Client;

namespace Minizon.Admin.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static void RegisterDependenciesForServiceControllers(HttpConfiguration config)
        {
            config.DependencyResolver = new SimpleContainer();
        }

    }

    public class SimpleContainer : IDependencyResolver
    {
        public IDependencyScope BeginScope()
        {
            // This example does not support child scopes, so we simply return 'this'.
            return this;
        }

        public object GetService(Type serviceType)
        {
            // TODO: look for a proper dependency wiring for WebApi controller
            if (serviceType == typeof(Minizon.Catalog.CatalogController))
            {
                return new Minizon.Catalog.CatalogController(MvcApplication.Bus, MvcApplication.DocumentStore.OpenSession());
            }
            if (serviceType == typeof(Minizon.Pricing.PricingController))
            {
                return new Minizon.Pricing.PricingController(MvcApplication.Bus, MvcApplication.DocumentStore.OpenSession());
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
            // When BeginScope returns 'this', the Dispose method must be a no-op.
        }
    }
}
