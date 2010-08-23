using System;
using System.Threading;
using Messages.Barista;
using Messages.Cashier;
using Rhino.ServiceBus;
using Rhino.ServiceBus.Sagas;

namespace Barista
{
    public class BaristaSaga :
        ISaga<BaristaState>,
        InitiatedBy<PrepareDrink>,
        Orchestrates<PaymentComplete>
    {
        private readonly IServiceBus _bus;

        public BaristaSaga(IServiceBus bus)
        {
            _bus = bus;
            State = new BaristaState();
        }

        #region InitiatedBy<PrepareDrink> Members

        public void Consume(PrepareDrink message)
        {
            State.Drink = message.DrinkName;

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Barista: preparing drink: " + State.Drink);
                Thread.Sleep(500);
            }
            State.DrinkIsReady = true;
            SubmitOrderIfDone();
        }

        #endregion

        #region ISaga<BaristaState> Members

        public BaristaState State { get; set; }

        public Guid Id { get; set; }

        public bool IsCompleted { get; set; }

        #endregion

        #region Orchestrates<PaymentComplete> Members

        public void Consume(PaymentComplete message)
        {
            Console.WriteLine("Barista: got payment notification");
            State.GotPayment = true;
            SubmitOrderIfDone();
        }

        #endregion

        private void SubmitOrderIfDone()
        {
            if (State.GotPayment && State.DrinkIsReady)
            {
                Console.WriteLine("Barista: drink is ready");
                _bus.Publish(new DrinkReady
                {
                    CorrelationId = Id,
                    Drink = State.Drink
                });
                IsCompleted = true;
            }
        }
    }
}