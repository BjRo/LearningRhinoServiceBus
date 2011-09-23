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
			PrepareQueues.Prepare("msmq://localhost/LearningRhinoESB.E11.Backend", QueueType.Standard);

            var host = new DefaultHost();
            host.Start<ClientBootStrapper>();

        	var bus = host.Bus as IServiceBus;
         
            Console.WriteLine("Hit enter to send message");
            Console.ReadLine();


            var helloWorldMessages = GetMessagesToSend();

            try
            {
                bus.Send(helloWorldMessages);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }
        
        private static object[] GetMessagesToSend()
        {
            return Enumerable.Range(0, 257)
                .Select(i => new HelloWorldMessage { Content = "Hello World " + i })
                .Cast<object>()
                .ToArray();
        }
    }
}
