using BibliotecaWeb.Models;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BibliotecaWeb.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public const string SessionKeyUserName = "UserName";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyUserName)))
            {
                HttpContext.Session.SetString(SessionKeyUserName, "Marcos Dósea");
            }
            var userName = HttpContext.Session.GetString(SessionKeyUserName);
            
            ViewData["nomeUsuario"] = userName;
            
            ViewBag.PerfilUsuario = "Professor";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
