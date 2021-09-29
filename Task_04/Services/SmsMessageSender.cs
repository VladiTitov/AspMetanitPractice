namespace Task_04.Services
{
    public class SmsMessageSender : IMessageSender
    {
        public string Send() => "Sent by SMS";
    }
}