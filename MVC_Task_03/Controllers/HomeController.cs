using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MVC_Task_03.Models;

namespace MVC_Task_03.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;
        public HomeController(MobileContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Phones.ToList());
        }
    }
}