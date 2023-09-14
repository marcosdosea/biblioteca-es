using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service;
using System.Data;

namespace BibliotecaWEB.Controllers
{
	//[Authorize(Roles = "bibliotecario")]
	public class EditoraController : Controller
	{

		private readonly IEditoraService _editoraService;
		private readonly IMapper _mapper;

		public EditoraController(IEditoraService editoraService, IMapper mapper)
		{
			_editoraService = editoraService;
			_mapper = mapper;
		}

		// GET: EditoraController
		public ActionResult Index()
		{
			var listaEditoras = _editoraService.GetAll();
			var listaEditorasModel = _mapper.Map<List<EditoraViewModel>>(listaEditoras);
			return View(listaEditorasModel);
		}

		// GET: EditoraController/Details/5
		public ActionResult Details(int id)
		{
			Editora? editora = _editoraService.Get(id);
			EditoraViewModel editoraModel = _mapper.Map<EditoraViewModel>(editora);
			return View(editoraModel);
		}

		// GET: EditoraController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: EditoraController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(EditoraViewModel editoraModel)
		{
			if (ModelState.IsValid)
			{
				var editora = _mapper.Map<Editora>(editoraModel);
				_editoraService.Create(editora);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: EditoraController/Edit/5
		public ActionResult Edit(int id)
		{
			Editora? editora = _editoraService.Get(id);
			EditoraViewModel editoraModel = _mapper.Map<EditoraViewModel>(editora);
			return View(editoraModel);
		}

		// POST: EditoraController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, EditoraViewModel editoraModel)
		{
			if (ModelState.IsValid)
			{
				var editora = _mapper.Map<Editora>(editoraModel);
				_editoraService.Edit(editora);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: EditoraController/Delete/5
		public ActionResult Delete(int id)
		{
			Editora? editora = _editoraService.Get(id);
			EditoraViewModel editoraModel = _mapper.Map<EditoraViewModel>(editora);
			return View(editoraModel);
		}

		// POST: EditoraController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, EditoraViewModel editoraModel)
		{
			_editoraService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}