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
