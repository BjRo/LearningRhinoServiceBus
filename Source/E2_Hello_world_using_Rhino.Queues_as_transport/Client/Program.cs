using System;
using System.IO;
using Messages;
using Rhino.ServiceBus;
using Rhino.ServiceBus.Hosting;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Directory.Exists("client.esent"))
                Directory.Delete("client.esent", true);

            if (Directory.Exists("client_subscriptions.esent"))
                Directory.Delete("client_subscriptions.esent", true);

            var host = new DefaultHost();
            host.Start<ClientBootStrapper>();

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
