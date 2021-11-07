using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace MVC_Task_03.Controllers
{
    public class HouseController : Controller
    {
        public IActionResult House()
        {
            return View();
        }
        
        [HttpPost]
        public string Area(int altitude, int height)
        {
            double square = altitude * height / 2;
            return $"Площадь треугольника с основанием {altitude} и высотой {height} равна {square}";
        }
        
        [HttpPost]
        public string AreaNew()
        {
            string altitudeString = Request.Form.FirstOrDefault(alt => alt.Key.Equals("altitude")).Value;
            int altitude = Int32.Parse(altitudeString);

            string heightString = Request.Form.FirstOrDefault(h => h.Key.Equals("height")).Value;
            int height = Int32.Parse(heightString);
            
            double square = altitude * height / 2;
            return $"Площадь треугольника с основанием {altitude} и высотой {height} равна {square}\nПосчитано без явной передачи аргументов";
        }
    }
}