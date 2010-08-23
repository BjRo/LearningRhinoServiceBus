using System;
using System.IO;
using Messages;
using Rhino.ServiceBus;
using Rhino.ServiceBus.Hosting;

namespace Customer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Directory.Exists("customer.esent"))
                Directory.Delete("customer.esent", true);

            if (Directory.Exists("customer_subscriptions.esent"))
                Directory.Delete("customer_subscriptions.esent", true);

            var host = new DefaultHost();
            host.Start<CustomerBootStrapper>();

            Console.WriteLine("Customer is visiting Starbucks ...");
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
