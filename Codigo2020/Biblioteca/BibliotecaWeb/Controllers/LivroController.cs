using AutoMapper;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaWeb.Controllers
{
	public class LivroController : Controller
	{
		ILivroService _livroService;
		IMapper _mapper;

		public LivroController(ILivroService livroService, IMapper mapper)
		{
			_livroService = livroService;
			_mapper = mapper;
		}

		// GET: LivroController
		public ActionResult Index()
		{
			var listaLivroes = _livroService.ObterTodos();
			var listaLivroesModel = _mapper.Map<List<LivroModel>>(listaLivroes);
			return View(listaLivroesModel);
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
			Livro livro = _livroService.Obter(id);
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
