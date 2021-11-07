using System;

namespace MVC_Task_04.Services
{
    public class TimeService : ITimeService
    {
        public TimeService()
        {
            Time = DateTime.Now.ToString("hh:mm:ss");
        }
        
        public string Time { get; set; }
    }
}