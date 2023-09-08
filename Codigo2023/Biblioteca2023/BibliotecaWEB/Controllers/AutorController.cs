using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BibliotecaWeb.Controllers
{
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
			var listaAutores = _autorService.GetAll();
			var listaAutoresModel = _mapper.Map<List<AutorModel>>(listaAutores);
			return View(listaAutoresModel);
		}

		// GET: AutorController/Details/5
		public ActionResult Details(int id)
		{
			Autor autor = _autorService.Get(id);
			AutorModel autorModel = _mapper.Map<AutorModel>(autor);
			return View(autorModel);
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
				var autor = _mapper.Map<Autor>(autorModel);
				_autorService.Create(autor);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: AutorController/Edit/5
		public ActionResult Edit(int id)
		{
            Autor autor = _autorService.Get(id);
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
				_autorService.Edit(autor);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: AutorController/Delete/5
		public ActionResult Delete(int id)
		{
			Autor autor = _autorService.Get(id);
			AutorModel autorModel = _mapper.Map<AutorModel>(autor);
			return View(autorModel);
		}

		// POST: AutorController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, AutorModel autorModel)
		{
			_autorService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
