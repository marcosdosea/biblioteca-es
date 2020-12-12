using Core;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace BibliotecaWeb.Controllers
{
	public class AutorController : Controller
	{
		private readonly IAutorService autorService;

		public AutorController(IAutorService _autorService)
		{
			autorService = _autorService;
		}

		// GET: AutorController
		public ActionResult Index()
		{
			return View(autorService.ObterTodos());
		}

		// GET: AutorController/Details/5
		public ActionResult Details(int id)
		{
			return View(autorService.Obter(id));
		}

		// GET: AutorController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: AutorController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(AutorModel autorModel)
		{
			if (ModelState.IsValid)
			{
				Autor autor = new Autor();
				autor.IdAutor = autorModel.IdAutor;
				autor.Nome = autorModel.Nome;
				autor.AnoNascimento = autorModel.AnoNascimento;
				autorService.Inserir(autor);
				return RedirectToAction(nameof(Index));
			}
			return View(autorModel);
		}

		// GET: AutorController/Edit/5
		public ActionResult Edit(int id)
		{
			Autor autor = autorService.Obter(id);
			AutorModel autorModel = new AutorModel();
			autorModel.IdAutor = autor.IdAutor;
			autorModel.Nome = autor.Nome;
			autorModel.AnoNascimento = autor.AnoNascimento;
			return View(autorModel);
		}

		// POST: AutorController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, AutorModel autorModel)
		{
			if (ModelState.IsValid)
			{
				Autor autor = new Autor();
				autor.IdAutor = autorModel.IdAutor;
				autor.Nome = autorModel.Nome;
				autor.AnoNascimento = autorModel.AnoNascimento;
				autorService.Editar(autor);
				return RedirectToAction(nameof(Index));
			}
			return View(autorModel);
		}

		// GET: AutorController/Delete/5
		public ActionResult Delete(int id)
		{
			Autor autor = autorService.Obter(id);
			AutorModel autorModel = new AutorModel();
			autorModel.IdAutor = autor.IdAutor;
			autorModel.Nome = autor.Nome;
			autorModel.AnoNascimento = autor.AnoNascimento;
			return View(autorModel);
		}

		// POST: AutorController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, AutorModel autor)
		{
			autorService.Remover(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
