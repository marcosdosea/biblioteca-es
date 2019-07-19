using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace BibliotecaCore2.Controllers
{
	public class AutorController : Controller
	{

		private readonly IGerenciadorAutor gerenciadorAutor;


		public AutorController(IGerenciadorAutor _gerenciadorAutor)
		{
			gerenciadorAutor = _gerenciadorAutor;
		}

		// GET: Autor
		public ActionResult Index()
		{
			return View(gerenciadorAutor.ObterTodos());
		}

		// GET: Autor/Details/5
		public ActionResult Details(int id)
		{
			Autor autor = gerenciadorAutor.Obter(id);
			return View(autor);
		}

		// GET: Autor/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Autor/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Autor autor)
		{
			if (ModelState.IsValid)
			{
				gerenciadorAutor.Inserir(autor);
				return RedirectToAction(nameof(Index));
			}

			return View(autor);
		}

		// GET: Autor/Edit/5
		public ActionResult Edit(int id)
		{
			Autor autor = gerenciadorAutor.Obter(id);
			return View(autor);
		}

		// POST: Autor/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Autor autor)
		{
			if (ModelState.IsValid)
			{
				gerenciadorAutor.Editar(autor);
				return RedirectToAction(nameof(Index));
			}
			return View(autor);
		}

		// GET: Autor/Delete/5
		public ActionResult Delete(int id)
		{
			Autor autoModel = gerenciadorAutor.Obter(id);
			return View(autoModel);
		}

		// POST: Autor/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			gerenciadorAutor.Remover(id);
			return RedirectToAction(nameof(Index));
		}
	}
}