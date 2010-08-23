using System;
using Rhino.ServiceBus.Hosting;
using Rhino.ServiceBus.Msmq;
using Utils;

namespace Barista
{
    class Program
    {
        static void Main(string[] args)
        {
            PrepareQueues.Prepare("msmq://localhost/LearningRhinoESB.E5.Barista", QueueType.Standard);

            Console.WriteLine("Barista: Ready for drink preparation ...");

            var host = new DefaultHost();
            host.Start<BaristaBootStrapper>();

            Console.ReadLine();
        }
    }
}
