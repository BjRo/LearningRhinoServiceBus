using System;
using Rhino.ServiceBus;
using Rhino.ServiceBus.Impl;
using Rhino.ServiceBus.Internal;
using Rhino.ServiceBus.MessageModules;

namespace Utils
{
    public class EchoMessageModule : IMessageModule
    {
        public void Init(ITransport transport, IServiceBus bus)
        {
            transport.MessageArrived += OnMessageArrived;
            transport.MessageProcessingCompleted += OnMessageProcessingCompleted;
        }

        public void Stop(ITransport transport, IServiceBus bus)
        {
            transport.MessageArrived -= OnMessageArrived;
            transport.MessageProcessingCompleted -= OnMessageProcessingCompleted;
        }

        private static void OnMessageProcessingCompleted(CurrentMessageInformation arg1, Exception arg2)
        {
            Console.WriteLine("Message batch processing completed");
        }

        private static bool OnMessageArrived(CurrentMessageInformation arg)
        {
            Console.WriteLine("Message batch has arrived");
            return false;
        }
    }
}