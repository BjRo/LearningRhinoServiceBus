using System;
using Barista;
using Cashier;
using Customer;
using Messages;
using Rhino.ServiceBus;
using Rhino.ServiceBus.Hosting;

namespace DevelopmentEnvironment
{
    class Program
    {
        static void Main(string[] args)
        {
            var cashier = new RemoteAppDomainHost(typeof(CashierBootStrapper))
                .Configuration("Cashier.config");
            cashier.Start();

            Console.WriteLine("Cashier has started");

            var barista = new RemoteAppDomainHost(typeof(BaristaBootStrapper))
                .Configuration("Barista.config");
            barista.Start();

            Console.WriteLine("Barista has started");

            var customerHost = new DefaultHost();
            
            customerHost.BusConfiguration(c =>
            {
                c.Bus("rhino.queues://localhost:53000/LearningRhinoESB_E8_Customer", "customer");
                c.Receive("Messages.Cashier", "rhino.queues://localhost:52000/LearningRhinoESB_E8_Cashier");
                c.Receive("Messages.Barista", "rhino.queues://localhost:51000/LearningRhinoESB_E8_Barista");
                return c;
            });

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
