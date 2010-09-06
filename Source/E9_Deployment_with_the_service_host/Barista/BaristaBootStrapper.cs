using Castle.MicroKernel.Registration;
using Rhino.ServiceBus.Hosting;
using Rhino.ServiceBus.Internal;
using Rhino.ServiceBus.Sagas.Persisters;

namespace Barista
{
	public class BaristaBootStrapper : AbstractBootStrapper
	{
		protected override void ConfigureContainer()
		{
			base.ConfigureContainer();

			container.Register(
				Component.For(typeof(ISagaPersister<>))
					.ImplementedBy(typeof(InMemorySagaPersister<>))
		    );
		}
	}
}