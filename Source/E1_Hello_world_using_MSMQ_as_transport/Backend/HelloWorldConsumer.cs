using System;
using Messages;
using Rhino.ServiceBus;

namespace Consumer
{
    public class HelloWorldConsumer : ConsumerOf<HelloWorldMessage>
    {
        public void Consume(HelloWorldMessage message)
        {
            Console.WriteLine("WOW, recieved  a message! Message text is: ");
            Console.WriteLine(message.Content);
        }
    }
}