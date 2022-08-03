using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication11.Areas.Admin.Models;

namespace WebApplication11.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var jsonWriters=JsonConvert.SerializeObject(writers);
           
            return Json(jsonWriters);
        }
        public IActionResult GetWriterByID(int id)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == id);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);

            return Json(jsonWriters);
        }
        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id=1,
                Name ="Ayşe"
            },
       new WriterClass
            {
                Id=2,
                Name ="Aybike"
            },
        new WriterClass
{
    Id = 3,
                Name = "Ayla"
}
        };
    }
}
