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
            PrepareQueues.Prepare("msmq://localhost/LearningRhinoESB_E9_Customer", QueueType.Standard);
            PrepareQueues.Prepare("msmq://localhost/LearningRhinoESB_E9_Cashier", QueueType.Standard);
            PrepareQueues.Prepare("msmq://localhost/LearningRhinoESB_E9_Barista", QueueType.Standard);

            var customerHost = new DefaultHost();

            customerHost.Start<CustomerBootStrapper>();

            Console.WriteLine("Customer was started");
            Console.WriteLine("Waiting for order");
            Console.ReadLine();

            var bus = customerHost.Bus as IServiceBus;

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
