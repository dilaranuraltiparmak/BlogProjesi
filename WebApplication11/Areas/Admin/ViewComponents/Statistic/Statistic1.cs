using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace WebApplication11.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {  
        BlogManager blogManager = new BlogManager(new EfBlogRepository()); // toplam blog sayısı
        Context c = new Context(); //Toplam Yeni mesaj sayısı
        public IViewComponentResult Invoke()
        {
            ViewBag.totelBlog = blogManager.GetList().Count(); //toplam blog sayısı **birden fazla manager kulllanılcaksa viewbag kullan 
            ViewBag.totelNewMessage = c.Contacts.Count(); //toplam mesaj sayısı
            ViewBag.totelComment = c.Comments.Count(); //toplam yorum sayısı

            string api = "da0d56b3b95e412d8799d554ba6221a7";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=kastamonu&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument xDocument = XDocument.Load(connection);
#pragma warning disable CS8602 // Olası bir null başvurunun başvurma işlemi.
            ViewBag.temperature = xDocument.Descendants("temperature").ElementAt(0).Attribute("value").Value;
#pragma warning restore CS8602 // Olası bir null başvurunun başvurma işlemi.
            return View();
        }
    }
}