using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication11.Controllers
{ 
	[AllowAnonymous]
	public class NewsLetterController : Controller
	{
      
		NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
		public PartialViewResult SubscribeMail()
		{
			return PartialView();
		}
		[HttpPost]
		public IActionResult SubsribeMail(NewsLetter p)
		{
			p.MailStatus = true;
			nm.AddNewsLetter(p);
			return PartialView();
		}
	}
  
}

