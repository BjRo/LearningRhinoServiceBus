using System;
using Rhino.ServiceBus.Hosting;

namespace Client2
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new DefaultHost();
            host.Start<Client2BootStrapper>();

            Console.WriteLine("Client2: Waiting for message . . . ");

            Console.ReadLine();
        }
    }
}
