using System;
using Rhino.ServiceBus.Hosting;

namespace Consumer
{
    public class ConsumerBootStrapper : AbstractBootStrapper
    {
        protected override bool IsTypeAcceptableForThisBootStrapper(Type t)
        {
            return t.Namespace == typeof (HelloWorldConsumer).Namespace;
        }
    }
}