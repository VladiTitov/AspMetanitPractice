using Microsoft.AspNetCore.Mvc;

namespace MVC_Task_02.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}