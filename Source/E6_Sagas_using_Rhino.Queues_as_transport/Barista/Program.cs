using System;
using Rhino.ServiceBus.Hosting;
using Utils;

namespace Barista
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueUtil.PrepareQueue("barista");
            
            Console.WriteLine("Barista: Ready for drink preparation ...");

            var host = new DefaultHost();
            host.Start<BaristaBootStrapper>();

            Console.ReadLine();
        }
    }
}
