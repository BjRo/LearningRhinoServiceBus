using System;
using System.IO;
using Messages;
using Rhino.ServiceBus;
using Rhino.ServiceBus.Hosting;
using Utils;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueUtil.PrepareQueue("client");

            var host = new DefaultHost();
            host.Start<ClientBootStrapper>();

            Console.WriteLine("Client 1: Hit enter to send message");
            Console.ReadLine();

            var bus = host.Container.Resolve<IServiceBus>();

            bus.Send(new HelloWorldMessage
            {
                Content = "Hello World!!!"
            });

            Console.ReadLine();
        }
    }
}
