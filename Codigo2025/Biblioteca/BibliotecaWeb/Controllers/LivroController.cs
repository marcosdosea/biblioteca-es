using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Service;

namespace BibliotecaWeb.Controllers
{
    [Authorize]
    class LivroController : Controller
    {
        private readonly ILivroService livroService;
        private readonly IAutorService autorService;
        private readonly IEditoraService editoraService;
        private readonly IMapper mapper;

        public LivroController(ILivroService livroService, IAutorService autorService, IEditoraService editoraService, IMapper mapper)
        {
            this.livroService = livroService;
            this.autorService = autorService;
            this.editoraService = editoraService;
            this.mapper = mapper;
        }

        // GET: LivroController
        public ActionResult Index()
        {
            var listaLivros = livroService.GetAll();
            return View(listaLivros);
        }

        // GET: LivroController/Details/5
        public ActionResult Details(uint id)
        {
            var livro = livroService.Get(id);
            LivroViewModel livroViewModel = mapper.Map<LivroViewModel>(livro);
            return View(livroViewModel);
        }

        // GET: LivroController/Create
        public ActionResult Create()
        {
            LivroViewModel livroModel = new();

            IEnumerable<Autor> listaAutores = autorService.GetAll();
            IEnumerable<Editora> listaEditoras = editoraService.GetAll();

            livroModel.ListaEditoras = new SelectList(listaEditoras, "Id", "Nome", null);
            livroModel.ListaAutores = new SelectList(listaAutores, "Id", "Nome", null);
            return View(livroModel);
        }

        // POST: LivroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LivroViewModel livroViewModel)
        {
            if (ModelState.IsValid)
            {
                var livro = mapper.Map<Livro>(livroViewModel);
                livroService.Create(livro);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: LivroController/Edit/5
        public ActionResult Edit(uint id)
        {
            Livro? livro = livroService.Get(id);
            LivroViewModel livroModel = mapper.Map<LivroViewModel>(livro);

            IEnumerable<Autor> listaAutores = autorService.GetAll();
            IEnumerable<Editora> listaEditoras = editoraService.GetAll();

            livroModel.ListaEditoras = new SelectList(listaEditoras, "Id", "Nome",
                        listaEditoras.FirstOrDefault(e => e.Id.Equals(livro.IdEditora)));
            livroModel.ListaAutores = new SelectList(listaAutores, "Id", "Nome", null);

            return View(livroModel);
        }

        // POST: LivroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LivroViewModel livroViewModel)
        {
            if (ModelState.IsValid)
            {
                var livro = mapper.Map<Livro>(livroViewModel);
                livroService.Edit(livro);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: LivroController/Delete/5
        public ActionResult Delete(uint id)
        {
            var livro = livroService.Get(id);
            LivroViewModel livroViewModel = mapper.Map<LivroViewModel>(livro);
            return View(livroViewModel);
        }

        // POST: LivroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(uint id, LivroViewModel livroViewModel)
        {
            livroService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
