using System;
using Castle.MicroKernel.Registration;
using Rhino.ServiceBus.Hosting;
using Rhino.ServiceBus.MessageModules;
using Utils;

namespace Client
{
    public class ClientBootStrapper : AbstractBootStrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            container.Register(
                Component.For<IMessageModule>()
                    .ImplementedBy<EchoMessageModule>()
                    .Named("Echo"));
        }
    }
}