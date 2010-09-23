using System;
using Messages;
using Rhino.ServiceBus;

namespace Backend
{
    public class HelloWorldConsumer : ConsumerOf<HelloWorldMessage>
    {
        public void Consume(HelloWorldMessage message)
        {
            foreach (var helloWorldMessage in message.Content)
            {
                Console.WriteLine(helloWorldMessage);                
            }
        }
    }
}