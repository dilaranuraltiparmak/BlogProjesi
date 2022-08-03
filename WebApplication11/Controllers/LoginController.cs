using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebApplication11.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
    public async Task<IActionResult> Index( Writer p)
        {
            Context c = new Context();
            #pragma warning disable CS8604 // Olası null başvuru bağımsız değişkeni.
            var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            if (datavalue!= null)
            {
                var claims = new List<Claim>
            {
                    new Claim(ClaimTypes.Name,p.WriterMail)
            };
                var useridentity=new ClaimsIdentity(claims,"a");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Dashboard");
            }
            else { return View(); }
        }

    }
    }

//    public IActionResult Index(Writer p)
//{
//    Context c = new Context();
//#pragma warning disable CS8604 // Olası null başvuru bağımsız değişkeni.
//    var datavalue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
//#pragma warning restore CS8604 // Olası null başvuru bağımsız değişkeni.
//    if (datavalue != null)
//    {
//#pragma warning disable CS8604 // Olası null başvuru bağımsız değişkeni.
//        HttpContext.Session.SetString("username", p.WriterMail);
//#pragma warning restore CS8604 // Olası null başvuru bağımsız değişkeni.
//        return RedirectToAction("Index", "Writer");
//    }
//    else { return View(); }
