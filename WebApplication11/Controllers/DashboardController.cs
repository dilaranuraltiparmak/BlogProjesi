using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication11.Controllers
{
    public class DashboardController : Controller
    {
       
        public IActionResult Index()
        {
            Context c = new Context();
#pragma warning disable CS8604 // Olası null başvuru bağımsız değişkeni.
            ViewBag.v1=c.Blogs.Count().ToString();
#pragma warning restore CS8604 // Olası null başvuru bağımsız değişkeni.
            ViewBag.v2=c.Blogs.Where(x=>x.WriterID==1).Count();
#pragma warning disable CS8604 // Olası null başvuru bağımsız değişkeni.
            ViewBag.v3=c.Categories.Count();
#pragma warning restore CS8604 // Olası null başvuru bağımsız değişkeni.
            return View();
        }
    }
}
