namespace Task_05.Services
{
    public class MessageService
    {
        private IMessageSender _messageSender;

        public MessageService(IMessageSender messageSender) => 
            _messageSender = messageSender;

        public string Send() => 
            _messageSender.Send();
    }
}