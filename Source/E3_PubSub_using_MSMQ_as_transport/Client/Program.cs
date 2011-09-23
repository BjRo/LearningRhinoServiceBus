using System;
using Messages;
using Rhino.ServiceBus;
using Rhino.ServiceBus.Hosting;
using Rhino.ServiceBus.Msmq;
using Utils;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PrepareQueues.Prepare("msmq://localhost/LearningRhinoESB.E3.Client", QueueType.Standard);

            var host = new DefaultHost();
            host.Start<ClientBootStrapper>();

            Console.WriteLine("Client 1: Hit enter to send message");
            Console.ReadLine();

            var bus = host.Bus as IServiceBus;

            bus.Send(new HelloWorldMessage
            {
                Content = "Hello World!!!"
            });

            Console.ReadLine();
        }
    }
}
