using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace BibliotecaWeb.Controllers
{
	
	public class EditoraController : Controller
    {

		private readonly IGerenciadorEditora gerenciadorEditora;

		public EditoraController(IGerenciadorEditora _gerenciadorEditora)
		{
			gerenciadorEditora = _gerenciadorEditora;
		}

		// GET: Editora
		public ActionResult Index()
        {
            return View(gerenciadorEditora.ObterTodos());
        }

        // GET: Editora/Details/5
        public ActionResult Details(int id)
        {
			Editora editora = gerenciadorEditora.Obter(id);
            return View(editora);
        }

        // GET: Editora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Editora/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Editora editora)
        {
            try
            {
				if (ModelState.IsValid)
				{
					gerenciadorEditora.Inserir(editora);
				}
				return RedirectToAction(nameof(Index));
			}
            catch
            {
                return View(editora);
            }
        }

        // GET: Editora/Edit/5
        public ActionResult Edit(int id)
        {
			Editora editora = gerenciadorEditora.Obter(id);
			return View(editora);
        }

        // POST: Editora/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Editora editora)
        {
            try
            {
				if (ModelState.IsValid)
				{
					gerenciadorEditora.Editar(editora);
				}
				return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(editora);
            }
        }

        // GET: Editora/Delete/5
        public ActionResult Delete(int id)
        {
			Editora editora = gerenciadorEditora.Obter(id);
			return View(editora);
        }

        // POST: Editora/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Editora editora)
        {
            try
            {
				gerenciadorEditora.Remover(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(editora);
            }
        }
    }
}