using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication11.ViewComponents.Writer
{
    
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
#pragma warning disable CS8602 // Olası bir null başvurunun başvurma işlemi.
            var usermail = User.Identity.Name;
#pragma warning restore CS8602 // Olası bir null başvurunun başvurma işlemi.
            ViewBag.v = usermail;

#pragma warning disable CS8604 // Olası null başvuru bağımsız değişkeni.
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
#pragma warning restore CS8604 // Olası null başvuru bağımsız değişkeni.

            var values = wm.GetWriterById(writerID);
            return View(values);
        }
    }
}
