using System;
using Messages;
using Rhino.ServiceBus;

namespace Backend
{
    public class OtherHelloWorldConsumer : ConsumerOf<HelloWorldMessage>
    {
        private readonly IServiceBus _serviceBus;

        public OtherHelloWorldConsumer(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        public void Consume(HelloWorldMessage message)
        {
            _serviceBus.Reply(new HelloWorldResponse
            {
                Content = "Well, hello back!!!"
            });
        }
    }
}