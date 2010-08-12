using System;
using System.IO;
using Rhino.ServiceBus.Hosting;

namespace Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Resetting queues");

            if (Directory.Exists("backend.esent"))
                Directory.Delete("backend.esent", true);

            Console.WriteLine("Starting to listen for incoming messages ...");

            var host = new DefaultHost();
            host.Start<BackendBootStrapper>();

            Console.ReadLine();
        }
    }
}
