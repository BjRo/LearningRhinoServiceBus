using Rhino.ServiceBus.Castle;
using Rhino.ServiceBus.MessageModules;
using Utils;
using Component = Castle.MicroKernel.Registration.Component;

namespace Client
{
    public class ClientBootStrapper : CastleBootStrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.Register(
                Component.For<IMessageModule>()
                    .ImplementedBy<EchoMessageModule>()
                    .Named("Echo"));
        }
    }
}