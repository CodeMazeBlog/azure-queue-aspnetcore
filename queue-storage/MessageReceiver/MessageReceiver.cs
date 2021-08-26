using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace MessageReceiver
{
    public static class MessageReceiver
    {
        private const string QUEUE_NAME = "message-queue";

        [FunctionName("MessageReceiver")]
        public static void Run([QueueTrigger(QUEUE_NAME, Connection = "StorageConnectionString")] string queueMessage, ILogger log)
        {
            log.LogInformation($"Queue trigger function processed message: {queueMessage}");
        }
    }
}
