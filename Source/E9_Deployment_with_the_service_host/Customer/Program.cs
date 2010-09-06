using System;
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
            PrepareQueues.Prepare("msmq://localhost/LearningRhinoESB_E9_Customer", QueueType.Standard);
            PrepareQueues.Prepare("msmq://localhost/LearningRhinoESB_E9_Cashier", QueueType.Standard);
            PrepareQueues.Prepare("msmq://localhost/LearningRhinoESB_E9_Barista", QueueType.Standard);

            var customerHost = new DefaultHost();

            customerHost.BusConfiguration(c => c.Bus("msmq://localhost/LearningRhinoESB_E9_Customer")
                .Receive("Messages.Cashier", "msmq://localhost/LearningRhinoESB_E9_Cashier")
                .Receive("Messages.Barista", "msmq://localhost/LearningRhinoESB_E9_Barista"));
            
            customerHost.Start<CustomerBootStrapper>();

            Console.WriteLine("Customer was started");
            Console.ReadLine();

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
