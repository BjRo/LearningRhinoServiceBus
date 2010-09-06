using System;
using System.IO;

namespace Utils
{
    public class QueueUtil
    {
        public static void PrepareQueue(string queueName)
        {
            if (string.IsNullOrWhiteSpace(queueName))
            {
                throw new ArgumentNullException("queueName");
            }

            var esentName = queueName + ".esent";
            var subscriptionEsentDb = queueName + "_subscriptions.esent";

            if (Directory.Exists(esentName))
                Directory.Delete(esentName, true);

            if (Directory.Exists(subscriptionEsentDb))
                Directory.Delete(subscriptionEsentDb, true);
        }
    }
}
