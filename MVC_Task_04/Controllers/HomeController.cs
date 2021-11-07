using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Task_04.Models;
using MVC_Task_04.Util;

namespace MVC_Task_04.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //return RedirectToAction("GetHtml", new { message = $"Redirected message"});
            return RedirectToAction("AgeValidator", new { age = Request.Query.FirstOrDefault(a=>a.Key.Equals("age")).Value});
        }

        public IActionResult AgeValidator(int age = 0)
        {
            return age < 18 ? (IActionResult) Unauthorized(new ErrorViewModel {RequestId = "Вам нет 18 лет. Доступ запрещен!"}) : Content("Проверка пройдена");
        }

        public HtmlResult GetHtml(string message)
        {
            return message != null ? new HtmlResult($"<h2>{message}</h2>") : new HtmlResult("<h2>Привет ASP.NET 5</h2>");
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}