using System;
using Messages;
using Rhino.ServiceBus;
using Rhino.ServiceBus.Hosting;
using Rhino.ServiceBus.Msmq;
using Utils;

namespace Customer
{
    class Program
    {
        static void Main(string[] args)
        {
            PrepareQueues.Prepare("msmq://localhost/LearningRhinoESB.E5.Customer", QueueType.Standard);

            var host = new DefaultHost();
            host.Start<CustomerBootStrapper>();

            Console.WriteLine("Ayende: Visiting Starbucks ...");
          
            var bus = host.Container.Resolve<IServiceBus>();

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
