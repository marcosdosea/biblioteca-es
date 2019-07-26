using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using Service;

namespace BibliotecaWeb.Controllers
{
    public class LivroController : Controller
    {
		IGerenciadorLivro gerenciadorLivro;
		IGerenciadorEditora gerenciadorEditora;

		public LivroController(IGerenciadorLivro _gerenciadorLivro, IGerenciadorEditora _gerenciadorEditora)
		{
			gerenciadorLivro = _gerenciadorLivro;
			gerenciadorEditora = _gerenciadorEditora;
		}

        public ActionResult Index()
        {
            return View(gerenciadorLivro.ObterTodos());
        }

        // GET: Livro/Details/5
        public ActionResult Details(int id)
        {
            return View(gerenciadorLivro.Obter(id));
        }

        // GET: Livro/Create
        public ActionResult Create()
        {
			ViewBag.IdEditora = new SelectList(gerenciadorEditora.ObterTodos(), "IdEditora", "Nome", null);
			return View();
        }

        // POST: Livro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Livro livro)
        {
            try
            {
				if (ModelState.IsValid)
				{
					gerenciadorLivro.Inserir(livro);
				}
				return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(livro);
            }
        }

        // GET: Livro/Edit/5
        public ActionResult Edit(int id)
        {
			Livro livro = gerenciadorLivro.Obter(id);
			IEnumerable<Editora> listaEditora = gerenciadorEditora.ObterTodos();
			ViewBag.IdEditora = new SelectList(listaEditora, "IdEditora", "Nome", 
				listaEditora.Where(editora=>editora.IdEditora==livro.IdEditora).FirstOrDefault());
			return View(livro);
        }

        // POST: Livro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Livro livro)
        {
            try
            {
				if (ModelState.IsValid)
				{
					gerenciadorLivro.Editar(livro);
				}

				return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(livro);
            }
        }

        // GET: Livro/Delete/5
        public ActionResult Delete(int id)
        {
            return View(gerenciadorLivro.Obter(id));
        }

        // POST: Livro/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Livro livro)
        {
            try
            {
				gerenciadorLivro.Remover(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}