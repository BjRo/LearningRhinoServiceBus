using System;
using Messages;
using Rhino.ServiceBus;
using Rhino.ServiceBus.Hosting;
using Rhino.ServiceBus.Msmq;
using Utils;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new DefaultHost();
            host.Start<SenderBootStrapper>();

            var bus = host.Container.Resolve<IServiceBus>();

            Console.WriteLine("Hit enter to send message");
            Console.ReadLine();
            Console.WriteLine("Sending message . . . ");

            bus.Send(new HelloWorldMessage
            {
                Content = "Hello World!!!"
            });

            Console.ReadLine();
        }
    }
}
