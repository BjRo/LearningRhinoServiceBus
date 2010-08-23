using System;
using Rhino.ServiceBus.Hosting;
using Rhino.ServiceBus.Msmq;
using Utils;

namespace Cashier
{
    class Program
    {
        static void Main(string[] args)
        {
            PrepareQueues.Prepare("msmq://localhost/LearningRhinoESB.E5.Cashier", QueueType.Standard);

            var host = new DefaultHost();
            host.Start<CashierBootStrapper>();

            Console.WriteLine("Cashier: Waiting for message . . . ");

            Console.ReadLine();
        }
    }
}
