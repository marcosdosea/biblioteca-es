using BibliotecaWeb.Models;
using Core.Identity.Data;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BibliotecaWeb.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public const string SessionKeyUserName = "UserName";
        public const string SessionKeyUserRoles = "UserRoles";

        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<UsuarioIdentity> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<UsuarioIdentity> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            // Obter usuário/roles via UserManager
            var usuario = await _userManager.GetUserAsync(User);
            var userName = usuario?.UserName ?? User.Identity?.Name ?? "Convidado";
            var roles = usuario is not null ? await _userManager.GetRolesAsync(usuario) : new List<string>();
            var rolesString = string.Join(", ", roles);

            // armazenar na sessão
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyUserName)))
            {
                HttpContext.Session.SetString(SessionKeyUserName, userName);
            }

            // armazenar o(s) perfil(is) do usuário na sessão
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyUserRoles)))
            {
                HttpContext.Session.SetString(SessionKeyUserRoles, rolesString);
            }


            ViewData["nomeUsuario"] = userName;

            ViewData["idadeUsuario"] = 30;

            ViewBag.DataAcesso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

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
