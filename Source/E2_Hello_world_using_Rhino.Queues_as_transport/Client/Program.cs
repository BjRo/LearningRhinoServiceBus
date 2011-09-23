using System;
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

            var bus = host.Bus as IServiceBus;

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
