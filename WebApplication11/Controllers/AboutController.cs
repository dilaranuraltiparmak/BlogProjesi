using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication11.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {var values = abm.GetList();
            return View(values);
        }
        public PartialViewResult SocialmediaAbout()
        {
            
            return PartialView();
        }
    }
}
