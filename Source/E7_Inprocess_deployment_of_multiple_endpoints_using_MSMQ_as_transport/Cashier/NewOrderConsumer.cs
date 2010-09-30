using System;
using Messages.Cashier;
using Rhino.Queues.Utils;
using Rhino.ServiceBus;

namespace Cashier
{
    public class NewOrderConsumer : ConsumerOf<NewOrder>
    {
        private readonly IServiceBus _bus;

        public NewOrderConsumer(IServiceBus bus)
        {
            _bus = bus;
        }

        public void Consume(NewOrder message)
        {
            Console.WriteLine("Cashier: got new order");

            var correlationId = GuidCombGenerator.Generate();

            _bus.Publish(new PrepareDrink
            {
                CorrelationId = correlationId,
                CustomerName = message.CustomerName,
                DrinkName = message.DrinkName,
                Size = message.Size
            });
            
            _bus.Reply(new PaymentDue
            {
                CustomerName = message.CustomerName,
                StarbucksTransactionId = correlationId,
                Amount = ((int)message.Size) * 1.25m
            });
        }
    }
}