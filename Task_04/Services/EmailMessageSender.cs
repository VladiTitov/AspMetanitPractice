namespace Task_04.Services
{
    public class EmailMessageSender : IMessageSender
    {
        public string Send() => "Sent by Email";
    }
}