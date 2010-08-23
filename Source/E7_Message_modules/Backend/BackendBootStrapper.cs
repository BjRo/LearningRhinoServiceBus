using Castle.MicroKernel.Registration;
using Rhino.ServiceBus.Hosting;
using Rhino.ServiceBus.MessageModules;
using Utils;

namespace Backend
{
    public class BackendBootStrapper : AbstractBootStrapper
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