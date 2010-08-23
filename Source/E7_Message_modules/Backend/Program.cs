using System;
using Rhino.ServiceBus.Hosting;
using Rhino.ServiceBus.Msmq;
using Utils;

namespace Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            PrepareQueues.Prepare("msmq://localhost/LearningRhinoESB.E1.Backend", QueueType.Standard);

            Console.WriteLine("Starting to listen for incoming messages ...");

            var host = new DefaultHost();
            host.Start<BackendBootStrapper>();

            Console.ReadLine(); ;
        }
    }
}
