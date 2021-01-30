using BibliotecaWeb.Models;
using Core;
using Google.DataTable.Net.Wrapper;
using Google.DataTable.Net.Wrapper.Extension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BibliotecaWeb.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ILivroService _livroService;

		public HomeController(ILogger<HomeController> logger, ILivroService livroService)
		{
			_logger = logger;
			_livroService = livroService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public string LivrosPorEditora()
		{
			var itens = _livroService.ObterNumeroLivrosPorEditora();
			var json = itens.ToGoogleDataTable()
				.NewColumn(new Column(ColumnType.String, "Editora"), x => x.NomeEditora)
				.NewColumn(new Column(ColumnType.Number, "Quantidade"), x => x.CountLivros)
				.Build()
				.GetJson();
			return json;
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
