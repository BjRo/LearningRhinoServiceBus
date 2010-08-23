using System;
using System.IO;
using Rhino.ServiceBus.Hosting;

namespace Barista
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Directory.Exists("barista.esent"))
                Directory.Delete("barista.esent", true);

            if (Directory.Exists("barista_subscriptions.esent"))
                Directory.Delete("barista_subscriptions.esent", true);

            Console.WriteLine("Barista: Ready for drink preparation ...");

            var host = new DefaultHost();
            host.Start<BaristaBootStrapper>();

            Console.ReadLine();
        }
    }
}
