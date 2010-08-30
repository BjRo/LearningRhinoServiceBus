using System;
using Messages;
using Rhino.ServiceBus;

namespace Backend
{
    public class HelloWorldConsumer : ConsumerOf<HelloWorldMessage>
    {
        private readonly IServiceBus _serviceBus;

        public HelloWorldConsumer(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        public void Consume(HelloWorldMessage message)
        {
            Console.WriteLine(message.Content);

            _serviceBus.Reply(new HelloWorldResponse
            {
                Content = "Well, hello back!!!"
            });
        }
    }
}