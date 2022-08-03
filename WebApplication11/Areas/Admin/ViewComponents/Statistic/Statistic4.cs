using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication11.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 :ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()

        {
#pragma warning disable CS8604 // Olası null başvuru bağımsız değişkeni.
            ViewBag.v1=c.Admins.Where(x=>x.AdminID==1).Select(y=>y.Name).FirstOrDefault();
#pragma warning restore CS8604 // Olası null başvuru bağımsız değişkeni.
            ViewBag.v2=c.Admins.Where(x=>x.AdminID==1).Select(y=>y.ImageURL).FirstOrDefault();
            ViewBag.v3=c.Admins.Where(x=>x.AdminID==1).Select(y=>y.ShortDescription).FirstOrDefault();
            return View(); }
        }
    }


