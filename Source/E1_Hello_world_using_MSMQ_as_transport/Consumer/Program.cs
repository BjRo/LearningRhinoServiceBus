using System;
using Rhino.ServiceBus.Hosting;
using Rhino.ServiceBus.Msmq;
using Utils;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Resetting queues");

            PrepareQueues.Prepare("msmq://localhost/LearningRhinoESB.E1.Consumer", QueueType.Standard);

            Console.WriteLine("Starting to listen for incoming messages ...");

            var host = new DefaultHost();
            host.Start<ConsumerBootStrapper>();

            Console.ReadLine(); ;
        }
    }
}
