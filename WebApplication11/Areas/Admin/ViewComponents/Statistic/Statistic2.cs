using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication11.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {

        Context c = new Context(); //Toplam Yeni mesaj sayısı

        public Context GetC()
        {
            return c;
        }

        public IViewComponentResult Invoke(Context c)
        {

            ViewBag.lastBlog = c.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.BlogTitle).Take(1).FirstOrDefault();//son eklenen blog
            ViewBag.totelComment = c.Comments.Count(); //toplam yorum sayısı
            return View();
        }
    }
}

