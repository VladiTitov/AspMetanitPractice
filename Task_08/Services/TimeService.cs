using Task_08.Models;

namespace Task_08.Services
{
    public class TimeService
    {
        private readonly ITimer _timer;
        public TimeService(ITimer timer) => 
            _timer = timer;

        public string GetTime() =>
            _timer.Time;
    }
}