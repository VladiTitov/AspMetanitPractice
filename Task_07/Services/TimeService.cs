namespace Task_07.Services
{
    public class TimeService
    {
        public TimeService() => 
            Time = System.DateTime.Now.ToString("hh:mm:ss");
        
        public string Time { get; }

    }
}