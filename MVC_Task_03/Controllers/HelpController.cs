using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Task_03.Controllers
{
    public class HelpController : Controller
    {
        [ActionName("Help")]
        public string Hello(int id)
        {
            return $"Hello ASP.NET\nYour Id={id}";
        }
    }
}