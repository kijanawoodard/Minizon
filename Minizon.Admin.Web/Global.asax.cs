﻿using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NServiceBus;
using Raven.Client.Document;

namespace Minizon.Admin.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static DocumentStore DocumentStore;
        static readonly Lazy<DocumentStore> StartDocumentStore = new Lazy<DocumentStore>(ConfigureRavenDb);
        public static IBus Bus;
        static readonly Lazy<IBus> StartBus = new Lazy<IBus>(ConfigureNServiceBus);

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureRavenDb();

            WebApiConfig.RegisterDependenciesForServiceControllers(GlobalConfiguration.Configuration);
        }

        protected void Application_BeginRequest()
        {
            Bus = StartBus.Value;
            DocumentStore = StartDocumentStore.Value;
        }

        private static IBus ConfigureNServiceBus()
        {
            return NServiceBus.Configure.With()
                .DefaultBuilder()
                .Log4Net()
                .JsonSerializer()
                .MsmqTransport()
                .UnicastBus()
                    .IsTransactional(true)
                    .PurgeOnStartup(false)
                .DisableSecondLevelRetries()
                .SendOnly();
        }

        private static DocumentStore ConfigureRavenDb()
        {
            var store = new DocumentStore
                                       {
                                           ConnectionStringName = "RavenDB"
                                       };
            store.Initialize();
            return store;
        }
    }
}