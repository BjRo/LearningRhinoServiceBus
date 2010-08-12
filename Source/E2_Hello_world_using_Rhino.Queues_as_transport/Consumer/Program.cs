using System;
using System.IO;
using Rhino.ServiceBus.Hosting;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Resetting queues");

            if (Directory.Exists("Test.esent"))
                Directory.Delete("Test.esent", true);

            Console.WriteLine("Starting to listen for incoming messages ...");

            var host = new DefaultHost();
            host.Start<ConsumerBootStrapper>();

            Console.ReadLine();
        }
    }
}
