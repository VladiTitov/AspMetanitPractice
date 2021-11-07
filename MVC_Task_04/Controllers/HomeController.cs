using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Task_04.Models;
using MVC_Task_04.Services;
using MVC_Task_04.Util;

namespace MVC_Task_04.Controllers
{
    public class HomeController : HelloBaseController
    {
        private readonly IWebHostEnvironment _appEnviroment;
        
        private readonly ILogger<HomeController> _logger;

        private readonly ITimeService _timeService;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment appEnviroment, ITimeService timeService)
        {
            _logger = logger;
            _appEnviroment = appEnviroment;
            _timeService = timeService;
        }

        public IActionResult Index()
        {
            //return RedirectToAction("GetHtml", new { message = $"Redirected message"});
            //return RedirectToAction("AgeValidator", new { age = Request.Query.FirstOrDefault(a=>a.Key.Equals("age")).Value});
            //return RedirectToAction("GetVirtualFile");
            return Content($"Запрос успешно выполнен!\nТекущее время: {_timeService.Time}");
        }

        public IActionResult GetFile()
        {
            var filePath = Path.Combine(_appEnviroment.ContentRootPath, "Files/book.pdf");
            var fileType = "application/pdf";
            var fileName = "book.pdf";
            return PhysicalFile(filePath, fileType, fileName);
        }

        public FileResult GetBytes()
        {
            var path = Path.Combine(_appEnviroment.ContentRootPath, "Files/book.pdf");
            var mass = System.IO.File.ReadAllBytes(path);
            var fileType = "application/pdf";
            var fileName = "book2.pdf";
            return File(mass, fileType, fileName);
        }

        public VirtualFileResult GetVirtualFile()
        {
            var filePath = Path.Combine("~/Files", "hello.txt");
            return File(filePath, "text/plain", "hello.txt");
        }
        
        public FileResult GetStream()
        {
            var path = Path.Combine(_appEnviroment.ContentRootPath, "Files/book.pdf");
            FileStream fs = new FileStream(path, FileMode.Open);
            var fileType = "application/pdf";
            var fileName = "book2.pdf";
            return File(fs, fileType, fileName);
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