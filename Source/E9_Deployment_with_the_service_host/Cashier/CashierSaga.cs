using System;
using Messages.Cashier;
using Rhino.Queues.Utils;
using Rhino.ServiceBus;

namespace Cashier
{
    public class CashierSaga :
        ConsumerOf<NewOrder>,
        ConsumerOf<SubmitPayment>
    {
        private readonly IServiceBus _bus;

        public CashierSaga(IServiceBus bus)
        {
            _bus = bus;
        }

        #region InitiatedBy<NewOrder> Members

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

        #endregion

        #region Orchestrates<SubmitPayment> Members

        public void Consume(SubmitPayment message)
        {
            Console.WriteLine("Cashier: got payment");
            
            _bus.Publish(new PaymentComplete
            {
                CorrelationId = message.CorrelationId
            });
        }

        #endregion
    }
}