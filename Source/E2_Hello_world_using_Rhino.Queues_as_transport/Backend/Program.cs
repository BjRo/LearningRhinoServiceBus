using System;
using Rhino.ServiceBus.Hosting;

namespace Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting to listen for incoming messages ...");

            var host = new DefaultHost();
            host.Start<BackendBootStrapper>();

            Console.ReadLine();
        }
    }
}
