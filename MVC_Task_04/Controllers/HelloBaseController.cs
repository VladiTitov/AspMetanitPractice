using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVC_Task_04.Controllers
{
    public class HelloBaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Headers.ContainsKey("User-Agent"))
            {
                var userAgent = context.HttpContext.Request.Headers["User-Agent"].FirstOrDefault();
                if (userAgent.Contains("MSIE") || userAgent.Contains("Trident"))
                {
                    var userAgentUser = Request.Headers["User-Agent"].ToString();
                    context.Result = Content($"IE не поддерживается.\nВаш браузер - {userAgentUser}");
                }
            }
            base.OnActionExecuting(context);
        }
    }
}