using System;
using System.IO;
using Rhino.ServiceBus.Hosting;

namespace Client2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Directory.Exists("client2.esent"))
                Directory.Delete("client2.esent", true);

            if (Directory.Exists("client2_subscriptions.esent"))
                Directory.Delete("client2_subscriptions.esent", true);

            var host = new DefaultHost();
            host.Start<Client2BootStrapper>();

            Console.WriteLine("Client2: Waiting for message . . . ");

            Console.ReadLine();
        }
    }
}
