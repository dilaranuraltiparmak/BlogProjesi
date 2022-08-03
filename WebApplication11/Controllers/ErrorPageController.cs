using Microsoft.AspNetCore.Mvc;

namespace WebApplication11.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1(int code)
        {
            return View();
        }
    }
}
