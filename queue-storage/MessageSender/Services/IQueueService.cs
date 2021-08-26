namespace MessageSender.Services
{
    public interface IQueueService
    {        
        void SendMessage(string queueName, string message);
    }
}