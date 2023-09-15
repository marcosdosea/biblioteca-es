using AutoMapper;
using BibliotecaWEB.Models;
using Core;
using Core.DTO;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Service;
using System.Data;

namespace BibliotecaWEB.Controllers
{
	//[Authorize(Roles = "bibliotecario")]
	public class LivroController : Controller
	{

		private readonly ILivroService _livroService;
		private readonly IAutorService _autorService;
		private readonly IEditoraService _editoraService;
		private readonly IMapper _mapper;

		public LivroController(ILivroService livroService, 
			IAutorService autorService, IEditoraService editoraService,
			IMapper mapper)
		{
			_livroService = livroService;
			_autorService = autorService;
			_editoraService = editoraService;
			_mapper = mapper;
		}

		// GET: LivroController
		public ActionResult Index()
		{
			var listaLivros = _livroService.GetAll();
			return View(listaLivros);
		}

		
		// GET: LivroController/Details/5
		public ActionResult Details(uint id)
		{
			Livro? livro = _livroService.Get(id);
			LivroViewModel livroModel = _mapper.Map<LivroViewModel>(livro);
			return View(livroModel);
		}

		// GET: LivroController/Create
		public ActionResult Create()
		{
			LivroViewModel livroModel = new();

			IEnumerable<Autor> listaAutores = _autorService.GetAll();
			IEnumerable<Editora> listaEditoras = _editoraService.GetAll();

			livroModel.ListaEditoras = new SelectList(listaEditoras, "Id", "Nome", null);
			livroModel.ListaAutores = new SelectList(listaAutores, "Id", "Nome", null);
			return View(livroModel);
		}

		// POST: LivroController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(LivroViewModel livroModel)
		{
			if (ModelState.IsValid)
			{
				var livro = _mapper.Map<Livro>(livroModel);
				_livroService.Create(livro);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: LivroController/Edit/5
		public ActionResult Edit(uint id)
		{
			Livro? livro = _livroService.Get(id);
			LivroViewModel livroModel = _mapper.Map<LivroViewModel>(livro);

			IEnumerable<Autor> listaAutores = _autorService.GetAll();
			IEnumerable<Editora> listaEditoras = _editoraService.GetAll();

			livroModel.ListaEditoras = new SelectList(listaEditoras, "Id", "Nome", 
				listaEditoras.FirstOrDefault(e => e.Id.Equals(livro.IdEditora)));
			livroModel.ListaAutores = new SelectList(listaAutores, "Id", "Nome", null);

			return View(livroModel);
		}

		// POST: LivroController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, LivroViewModel livroModel)
		{
			if (ModelState.IsValid)
			{
				var livro = _mapper.Map<Livro>(livroModel);
				_livroService.Edit(livro);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: LivroController/Delete/5
		public ActionResult Delete(uint id)
		{
			Livro? livro = _livroService.Get(id);
			LivroViewModel livroModel = _mapper.Map<LivroViewModel>(livro);
			return View(livroModel);
		}

		// POST: LivroController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, LivroViewModel livroModel)
		{
			if (ModelState.IsValid)
			{
				var livro = _mapper.Map<Livro>(livroModel);
				_livroService.Edit(livro);
			}
			return RedirectToAction(nameof(Index));
		}
	}
}
