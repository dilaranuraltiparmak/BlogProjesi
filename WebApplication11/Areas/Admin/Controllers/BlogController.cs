using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication11.Areas.Admin.Models;

namespace WebApplication11.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.BlogID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
using (var stream=new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Working1.xlsx");
                }
            }
              
        }
     public   List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel> {
                new BlogModel { BlogID=1,BlogName="C# Programlamaya Giriş"},
                new BlogModel { BlogID=2,BlogName="Araba firmaları dergisi"},
                new BlogModel { BlogID=3,BlogName="Gazete Gündemi"},
            };  
            return bm;
        }
        public IActionResult BlogListExcel()
        {
            return View();  
        }
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.BlogID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Working1.xlsx");
                }
            }
        }
        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2>bm=new List<BlogModel2>();
            using (var c = new Context())
            {
#pragma warning disable CS8604 // Olası null başvuru bağımsız değişkeni.
                bm =c.Blogs.Select(x=>new BlogModel2
#pragma warning restore CS8604 // Olası null başvuru bağımsız değişkeni.
                {
                   BlogID = x.BlogID,
                   BlogName=x.BlogTitle
                }).ToList();
            }
            return bm;
        }
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
