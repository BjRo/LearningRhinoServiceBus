using System;
using Messages;
using Rhino.ServiceBus;
using Rhino.ServiceBus.Hosting;
using Utils;

namespace Customer
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueUtil.PrepareQueue("customer");

            var host = new DefaultHost();
            host.Start<CustomerBootStrapper>();

            Console.WriteLine("Ayende is visiting Starbucks ...");
            Console.WriteLine("Hit enter for buying a hot chocolate ...");

            //Give the other services a bit air to initialize.
            Console.ReadLine();

            var bus = host.Container.Resolve<IServiceBus>();

            var customer = new CustomerController(bus)
            {
                Drink = "Hot Chocolate",
                Name = "Starbucks Lover",
                Size = DrinkSize.Venti
            };

            customer.BuyDrinkSync();

            Console.ReadLine();
        }
    }
}
