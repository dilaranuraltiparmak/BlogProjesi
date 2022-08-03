using Microsoft.AspNetCore.Mvc;
using WebApplication11.Models;

namespace WebApplication11.ViewComponents
{
    public class CommentList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cmvalues = new List<UserComment>
            {
                new UserComment
                {
                    ID = 1, Username="Dilara"
                },
                new UserComment
                {
                       ID=2, Username="Hanife"
                }, new UserComment
                {
                    ID=3, Username="Semih"
                }
            };
            return View(cmvalues);
        }
    }
}
