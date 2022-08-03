using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebApplication11.Areas.Admin.Models;
using Ajax;
namespace WebApplication11.Areas.Admin.Controllers
{ [Area("Admin")]
    public class ChartController : Controller
    {
  
            Context c = new Context();
            public ActionResult Index()
            {
                return View();
            }

            //public ActionResult CategoryChart()
            //{
            //    return Json(CategoryList(), JsonRequestBehavior.AllowGet); //kullanılma izin ver 
            //}

            //public List<CategoryClass> CategoryList()
            //{
            //    List<CategoryClass> categoryVMs = new List<CategoryClass>();
            //    categoryVMs = c.Categories.Select(x => new CategoryClass
            //    {
            //        CategoryName = x.CategoryName,
            //        CategoryCount = x.CategoryName.Count(),

            //    }).ToList();

            //    return categoryVMs;
            //}

            public JsonResult CategoryChart()
            {
                List<CategoryClass> list = new List<CategoryClass>();
                list.Add(new CategoryClass
                {
                    categoryname = "Teknoloji",
                    categorycount = 10
                });
                list.Add(new CategoryClass
                {
                    categoryname = "Yazılım",
                    categorycount = 14
                });
                list.Add(new CategoryClass
                {
                    categoryname = "Spor",
                    categorycount = 5
                });
                list.Add(new CategoryClass
                {
                    categoryname = "Sinema",
                    categorycount = 2
                });
                return new JsonResult(new { jsonList = list });
            }






        }
    }

