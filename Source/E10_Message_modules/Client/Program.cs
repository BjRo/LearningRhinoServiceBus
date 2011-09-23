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
            PrepareQueues.Prepare("msmq://localhost/LearningRhinoESB.E10.Client", QueueType.Standard);

            var host = new DefaultHost();
            host.Start<ClientBootStrapper>();

            var bus = host.Bus as IServiceBus;
         
            Console.WriteLine("Hit enter to send message");
            Console.ReadLine();

            bus.Send(new HelloWorldMessage
            {
                Content = "Hello World!!!"
            });

            Console.ReadLine();
        }
    }
}
