using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Service;

namespace BibliotecaWEB.Controllers
{
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
			var listaLivrosModel = _mapper.Map<List<LivroModel>>(listaLivros);
			return View(listaLivrosModel);
		}

		// GET: LivroController/Details/5
		public ActionResult Details(int id)
		{
			Livro livro = _livroService.Get(id);
			LivroModel livroModel = _mapper.Map<LivroModel>(livro);
			return View(livroModel);
		}

		// GET: LivroController/Create
		public ActionResult Create()
		{
			LivroModel livroModel = new LivroModel();

			IEnumerable<Autor> listaAutores = _autorService.GetAll();
			IEnumerable<Editora> listaEditoras = _editoraService.GetAll();

			livroModel.ListaEditoras = new SelectList(listaEditoras, "IdEditora", "Nome", null);
			livroModel.ListaAutores = new SelectList(listaAutores, "IdAutor", "Nome", null);
			return View(livroModel);
		}

		// POST: LivroController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(LivroModel livroModel)
		{
			if (ModelState.IsValid)
			{
				var livro = _mapper.Map<Livro>(livroModel);
				_livroService.Create(livro);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: LivroController/Edit/5
		public ActionResult Edit(int id)
		{
			Livro livro = _livroService.Get(id);
			LivroModel livroModel = _mapper.Map<LivroModel>(livro);
			return View(livroModel);
		}

		// POST: LivroController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, LivroModel livroModel)
		{
			if (ModelState.IsValid)
			{
				var livro = _mapper.Map<Livro>(livroModel);
				_livroService.Edit(livro);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: LivroController/Delete/5
		public ActionResult Delete(int id)
		{
			Livro livro = _livroService.Get(id);
			LivroModel livroModel = _mapper.Map<LivroModel>(livro);
			return View(livroModel);
		}

		// POST: LivroController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, LivroModel livroModel)
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
