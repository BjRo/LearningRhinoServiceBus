using System;
using System.Threading;
using Messages;
using Messages.Barista;
using Messages.Cashier;
using Rhino.ServiceBus;

namespace Customer
{
    public class CustomerController : 
        OccasionalConsumerOf<PaymentDue>,
        OccasionalConsumerOf<DrinkReady>
    {
        public string Name { get; set; }
        public string Drink { get; set; }
        public DrinkSize Size { get; set; }

        private readonly IServiceBus _bus;
        private ManualResetEvent _wait;

        public CustomerUserInterface CustomerUserInterface { get; set; }

        public CustomerController(IServiceBus bus)
        {
            CustomerUserInterface = new CustomerUserInterface();
            _bus = bus;
        }

        public void BuyDrinkSync()
        {
            using(_bus.AddInstanceSubscription(this))
            {
                _wait = new ManualResetEvent(false);

                _bus.Send(new NewOrder {CustomerName = Name, DrinkName = Drink, Size = Size});

                if(_wait.WaitOne(TimeSpan.FromSeconds(30), false)==false)
                    throw new InvalidOperationException("didn't get my coffee in time");
            }
        }

        public void Consume(PaymentDue message)
        {
            if(CustomerUserInterface.ShouldPayForDrink(Name, message.Amount)==false)
                return;

            _bus.Reply(new SubmitPayment
            {
                Amount = message.Amount, 
                CorrelationId = message.StarbucksTransactionId
            });
        }

        public void Consume(DrinkReady message)
        {
            CustomerUserInterface.CoffeeRush(Name);
            if (_wait != null)
                _wait.Set();
        }
    }
}
