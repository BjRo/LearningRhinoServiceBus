using Castle.MicroKernel.Registration;
using Rhino.ServiceBus.Castle;
using Rhino.ServiceBus.MessageModules;
using Utils;

namespace Backend
{
    public class BackendBootStrapper : CastleBootStrapper
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