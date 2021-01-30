using AutoMapper;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System.Collections.Generic;

namespace BibliotecaWeb.Controllers
{
	public class LivroController : Controller
	{
		private readonly ILivroService _livroService;
		private readonly IEditoraService _editoraService;
		private readonly IAutorService _autorService;
		private readonly IMapper _mapper;

		public LivroController(ILivroService livroService, IEditoraService editoraService,
			IAutorService autorService, IMapper mapper)
		{
			_livroService = livroService;
			_editoraService = editoraService;
			_autorService = autorService;
			_mapper = mapper;
		}

		// GET: LivroController
		public ActionResult Index()
		{
			var listaLivroes = _livroService.ObterTodos();
			var listaLivrosModel = _mapper.Map<List<LivroModel>>(listaLivroes);
			return View(listaLivrosModel);
		}


		public ActionResult Get(string nomeLivro)
		{
			var listaLivroes = _livroService.ObterPorNome(nomeLivro);
			var listaLivrosModel = _mapper.Map<List<LivroModel>>(listaLivroes);
			return View(listaLivrosModel);
		}



		// GET: LivroController/Details/5
		public ActionResult Details(int id)
		{
			Livro livro = _livroService.Obter(id);
			LivroModel livroModel = _mapper.Map<LivroModel>(livro);
			return View(livroModel);
		}

		// GET: LivroController/Create
		public ActionResult Create()
		{
			IEnumerable<Autor> listaAutores = _autorService.ObterTodosOrdenadoPorNome();
			IEnumerable<Editora> listaEditoras = _editoraService.ObterTodos();
			
			ViewBag.IdEditora = new SelectList(listaEditoras, "IdEditora", "Nome", null);
			ViewBag.IdAutor  = new SelectList(listaAutores, "IdAutor", "Nome", null);
			return View();
		}

		// POST: LivroController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(LivroModel livroModel)
		{
			if (ModelState.IsValid)
			{
				var livro = _mapper.Map<Livro>(livroModel);
				_livroService.Inserir(livro);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: LivroController/Edit/5
		public ActionResult Edit(int id)
		{
			IEnumerable<Autor> listaAutores = _autorService.ObterTodos();
			IEnumerable<Editora> listaEditoras = _editoraService.ObterTodos();
			Livro livro = _livroService.Obter(id);

			ViewBag.IdEditora = new SelectList(listaEditoras, "IdEditora", "Nome", livro.IdEditoraNavigation);
			ViewBag.IdAutor = new SelectList(listaAutores, "IdAutor", "Nome", livro.IdEditoraNavigation);
			
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
				_livroService.Editar(livro);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: LivroController/Delete/5
		public ActionResult Delete(int id)
		{
			Livro livro = _livroService.Obter(id);
			LivroModel livroModel = _mapper.Map<LivroModel>(livro);
			return View(livroModel);
		}

		// POST: LivroController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, LivroModel livroModel)
		{
			_livroService.Remover(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
