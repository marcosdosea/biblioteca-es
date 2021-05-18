using AutoMapper;
using Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;

namespace BibliotecaWeb.Controllers
{
	[Authorize(Roles = "BALCONISTA")]
	public class AutorController : Controller
	{
		private readonly IAutorService _autorService;
		private readonly IMapper _mapper;

		public AutorController(IAutorService autorService, IMapper mapper)
		{
			_autorService = autorService;
			_mapper = mapper;
		}

		// GET: AutorController
		public ActionResult Index()
		{			
			var listaAutores = _autorService.ObterTodos();
			var listaAutoresModel = _mapper.Map<List<AutorModel>>(listaAutores);
			return View(listaAutoresModel);
		}

		// GET: AutorController/Details/5
		public ActionResult Details(int id)
		{
			Autor autor = _autorService.Obter(id);
			AutorModel autorModel = _mapper.Map<AutorModel>(autor);
			return View(autorModel);
		}

		// GET: AutorController/Create
		[Authorize]
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
				var autor = _mapper.Map<Autor>(autorModel);
				_autorService.Inserir(autor);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: AutorController/Edit/5
		public ActionResult Edit(int id)
		{
			Autor autor = _autorService.Obter(id);
			AutorModel autorModel = _mapper.Map<AutorModel>(autor);
			return View(autorModel);
		}

		// POST: AutorController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, AutorModel autorModel)
		{
			if (ModelState.IsValid)
			{
				var autor = _mapper.Map<Autor>(autorModel);
				_autorService.Editar(autor);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: AutorController/Delete/5
		public ActionResult Delete(int id)
		{
			Autor autor = _autorService.Obter(id);
			AutorModel autorModel = _mapper.Map<AutorModel>(autor);
			return View(autorModel);
		}

		// POST: AutorController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, AutorModel autorModel)
		{
			_autorService.Remover(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
