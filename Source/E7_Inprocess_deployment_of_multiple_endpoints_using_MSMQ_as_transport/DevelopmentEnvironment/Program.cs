using System;
using Barista;
using Cashier;
using Customer;
using Messages;
using Rhino.ServiceBus;
using Rhino.ServiceBus.Hosting;
using Rhino.ServiceBus.Msmq;
using Utils;

namespace DevelopmentEnvironment
{
    class Program
    {
        static void Main(string[] args)
        {
            PrepareQueues.Prepare("msmq://localhost/LearningRhinoESB.E7.Barista", QueueType.Standard);
            PrepareQueues.Prepare("msmq://localhost/LearningRhinoESB.E7.Cashier", QueueType.Standard);
            PrepareQueues.Prepare("msmq://localhost/LearningRhinoESB.E7.Customer", QueueType.Standard);

            var cashier = new RemoteAppDomainHost(typeof(CashierBootStrapper))
                .Configuration("Cashier.config");
            cashier.Start();

            Console.WriteLine("Cashier has started");

            var barista = new RemoteAppDomainHost(typeof(BaristaBootStrapper))
                .Configuration("Barista.config");
            barista.Start();

            Console.WriteLine("Barista has started");

            var customerHost = new DefaultHost();
            customerHost.BusConfiguration(c => c.Bus("msmq://localhost/LearningRhinoESB.E7.Customer")
                .Receive("Messages.Cashier", "msmq://localhost/LearningRhinoESB.E7.Cashier")
                .Receive("Messages.Barista", "msmq://localhost/LearningRhinoESB.E7.Barista"));
            customerHost.Start<CustomerBootStrapper>();

            var bus = customerHost.Container.Resolve<IServiceBus>();

            var customer = new CustomerController(bus)
            {
                Drink = "Hot Chocolate",
                Name = "Ayende",
                Size = DrinkSize.Venti
            };

            customer.BuyDrinkSync();

            Console.ReadLine();
        }
    }
}
