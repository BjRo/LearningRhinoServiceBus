using System;
using System.IO;
using Rhino.ServiceBus.Hosting;

namespace Cashier
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Directory.Exists("cashier.esent"))
                Directory.Delete("cashier.esent", true);

            if (Directory.Exists("cashier_subscriptions.esent"))
                Directory.Delete("cashier_subscriptions.esent", true);

            var host = new DefaultHost();
            host.Start<CashierBootStrapper>();

            Console.WriteLine("Cashier: Waiting for message . . . ");

            Console.ReadLine();
        }
    }
}
