using System;
using System.Linq;
using Messages;
using Rhino.ServiceBus;
using Rhino.ServiceBus.Hosting;
using Rhino.ServiceBus.Msmq;
using Utils;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PrepareQueues.Prepare("msmq://localhost/LearningRhinoESB.E12.Client", QueueType.Standard);

            var host = new DefaultHost();
            host.Start<ClientBootStrapper>();

            var bus = host.Bus as IServiceBus;
         
            Console.WriteLine("Hit enter to send message");
            Console.ReadLine();


            var message = GetMessageWithLargeCollection();

            try
            {
                bus.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }
        
        private static object GetMessageWithLargeCollection()
        {
            var message = new HelloWorldMessage
            {
                //256 entries is the max value
                Content = Enumerable.Range(0, 257)
                    .Select(i => "Hello World " + i)
                    .ToList()
            };

            return message;
        }
    }
}
