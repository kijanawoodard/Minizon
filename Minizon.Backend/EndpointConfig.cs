using NServiceBus.Config;
using Raven.Client;
using Raven.Client.Document;

namespace Minizon.Backend
{
    using NServiceBus;

    /*
        This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
        can be found here: http://nservicebus.com/GenericHost.aspx
    */
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public void Init()
        {
            NServiceBus.Configure.With()
                .DefaultBuilder()
                .Log4Net()
                .JsonSerializer()
                .MsmqTransport()
                .UnicastBus()
                    .IsTransactional(true)
                    .PurgeOnStartup(false)
                .DisableSecondLevelRetries();
        }
    }

    public class WireDependencies : INeedInitialization
    {
        public void Init()
        {
           Configure.Instance.Configurer.ConfigureComponent<IDocumentStore>(() =>
	        {
	            var store = new DocumentStore
	                            {
	                                ConnectionStringName = "RavenDB"
	                            };
	            store.Initialize();
	            return store;
	        }, DependencyLifecycle.SingleInstance);

            Configure.Instance.Configurer.ConfigureComponent<IDocumentSession>(
                () => Configure.Instance.Builder.Build<IDocumentStore>().OpenSession(), DependencyLifecycle.InstancePerUnitOfWork);
        }
    }
}