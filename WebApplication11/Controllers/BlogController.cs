using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication11.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();
        public IActionResult Index()
        {
            var values=bm.GetBlogListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i=id;
           var values =bm.GetBlogByID(id);
            return View(values);
        }
        public IActionResult BlogListByWriter(int id)
        {

#pragma warning disable CS8602 // Olası bir null başvurunun başvurma işlemi.
            var usermail = User.Identity.Name;
#pragma warning restore CS8602 // Olası bir null başvurunun başvurma işlemi.
#pragma warning disable CS8604 // Olası null başvuru bağımsız değişkeni.
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
#pragma warning restore CS8604 // Olası null başvuru bağımsız değişkeni.
            var values = bm.GetListWithCategoryByWriterBm(writerID);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
         
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv=categoryvalues;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
#pragma warning disable CS8602 // Olası bir null başvurunun başvurma işlemi.
            var usermail = User.Identity.Name;
#pragma warning restore CS8602 // Olası bir null başvurunun başvurma işlemi.
#pragma warning disable CS8604 // Olası null başvuru bağımsız değişkeni.
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
#pragma warning restore CS8604 // Olası null başvuru bağımsız değişkeni.

            BlogValidator bv = new BlogValidator();
                ValidationResult results = bv.Validate(p);
                if (results.IsValid)
                {
                    p.BlogStatus = true;
                  p.BlogCreateDate= DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = writerID;
                    bm.TAdd(p);


                    return RedirectToAction("BlogListByWriter", "Blog");

                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
                return View();
            }
           public IActionResult DeleteBlog(int id)
        {
            var blogvalue=bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
          var blogvalue=bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(blogvalue);
        }
        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
#pragma warning disable CS8602 // Olası bir null başvurunun başvurma işlemi.
            var usermail = User.Identity.Name;
#pragma warning restore CS8602 // Olası bir null başvurunun başvurma işlemi.
#pragma warning disable CS8604 // Olası null başvuru bağımsız değişkeni.
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
#pragma warning restore CS8604 // Olası null başvuru bağımsız değişkeni.
            p.WriterID= writerID;
            p.BlogCreateDate= DateTime.Parse(DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
          bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }
    }

    }

