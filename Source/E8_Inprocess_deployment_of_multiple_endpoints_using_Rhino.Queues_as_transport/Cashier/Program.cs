using System;
using Rhino.ServiceBus.Hosting;
using Utils;

namespace Cashier
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueUtil.PrepareQueue("cashier");

            var host = new DefaultHost();
            host.Start<CashierBootStrapper>();

            Console.WriteLine("Cashier: Waiting for message . . . ");

            Console.ReadLine();
        }
    }
}
