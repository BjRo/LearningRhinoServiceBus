using System;
using Rhino.ServiceBus.Sagas;

namespace Messages.Cashier
{
    public class SubmitPayment : ISagaMessage
    {
        public Guid CorrelationId { get; set; }
        public decimal Amount { get; set; }
    }
}