namespace Task_04.Services
{
    public class TimeService
    {
        public string GetTime() => 
            System.DateTime.Now.ToString("hh:mm:ss");
    }
}