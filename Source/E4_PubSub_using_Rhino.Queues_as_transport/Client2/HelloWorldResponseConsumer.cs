using System;
using Messages;
using Rhino.ServiceBus;

namespace Client2
{
    public class HelloWorldResponseConsumer : ConsumerOf<HelloWorldResponse>
    {
        public void Consume(HelloWorldResponse message)
        {
            Console.WriteLine(message.Content);
        }
    }
}