using System;
using Messages.Cashier;
using Rhino.ServiceBus;

namespace Cashier
{
    public class SubmitPaymentConsumer : ConsumerOf<SubmitPayment>
    {
        private readonly IServiceBus _bus;

        public SubmitPaymentConsumer(IServiceBus bus)
        {
            _bus = bus;
        }

        public void Consume(SubmitPayment message)
        {
            Console.WriteLine("Cashier: got payment");

            _bus.Publish(new PaymentComplete
            {
                CorrelationId = message.CorrelationId
            });
        }
    }
}