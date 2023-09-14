using AutoMapper;
using Core;
using Core.Datatables;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Text.Json;

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
			var listaAutoresModel = _mapper.Map<List<AutorViewModel>>(listaAutores);
			return View(listaAutoresModel);
		}
        
		[HttpPost]
        public IActionResult GetPage(DatatableRequest request)
        {
			var response = _autorService.GetPage(request);
            return Json(response);
        }

        // GET: AutorController/Details/5
        public ActionResult Details(uint id)
		{
			Autor? autor = _autorService.Get(id);
			AutorViewModel autorModel = _mapper.Map<AutorViewModel>(autor);
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
		public ActionResult Create(AutorViewModel autorModel)
		{
			if (ModelState.IsValid)
			{
				var autor = _mapper.Map<Autor>(autorModel);
				_autorService.Create(autor);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: AutorController/Edit/5
		public ActionResult Edit(uint id)
		{
            Autor? autor = _autorService.Get(id);
            AutorViewModel autorModel = _mapper.Map<AutorViewModel>(autor);
            return View(autorModel);
        }

		// POST: AutorController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(uint id, AutorViewModel autorModel)
		{
			if (ModelState.IsValid)
			{
				var autor = _mapper.Map<Autor>(autorModel);
				_autorService.Edit(autor);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: AutorController/Delete/5
		public ActionResult Delete(uint id)
		{
			Autor? autor = _autorService.Get(id);
			AutorViewModel autorModel = _mapper.Map<AutorViewModel>(autor);
			return View(autorModel);
		}

		// POST: AutorController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(uint id, AutorViewModel autorModel)
		{
			_autorService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
