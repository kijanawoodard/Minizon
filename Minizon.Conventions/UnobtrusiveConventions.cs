using System;
using NServiceBus;

namespace Minizon.Conventions
{
    public class UnobtrusiveConventions : IWantToRunBeforeConfiguration
    {
        //http://www.serrate.net/2012/10/16/nservicebus-dry-with-unobtrusive-conventions/
        public void Init()
        {
            Configure.Instance
                 .DefiningCommandsAs(t => minizonNamespace(t) && t.Namespace.EndsWith("Commands"))
                 .DefiningEventsAs(t => minizonNamespace(t) && (t.Namespace.EndsWith("Events") || t.Namespace.EndsWith("Contracts")))
                .DefiningMessagesAs(t => minizonNamespace(t) && t.Namespace.EndsWith("Messages"));
        }

        private Func<Type, bool> minizonNamespace = (type) => type.Namespace != null && type.Namespace.StartsWith("Minizon");
    }
}
