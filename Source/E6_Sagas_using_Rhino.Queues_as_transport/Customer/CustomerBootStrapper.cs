using Rhino.ServiceBus.Castle;
using Rhino.ServiceBus.Internal;
using Rhino.ServiceBus.Sagas.Persisters;
using Component = Castle.MicroKernel.Registration.Component;

namespace Customer
{
    public class CustomerBootStrapper : CastleBootStrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.Register(
                Component.For(typeof (ISagaPersister<>))
                    .ImplementedBy(typeof (InMemorySagaPersister<>))
            );
        }
    }
}