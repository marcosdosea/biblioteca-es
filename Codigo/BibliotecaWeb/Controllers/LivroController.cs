using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Models;

namespace BibliotecaWeb.Controllers
{
    public class LivroController : Controller
    {
        GerenciadorLivro gLivro;
        GerenciadorEditora gEditora;

        public LivroController()
        {
            gLivro = new GerenciadorLivro();
            gEditora = new GerenciadorEditora();
        }
        
        
        //
        // GET: /Livro/
        public ActionResult Index()
        {
            return View(gLivro.ObterTodos());
        }

        //
        // GET: /Livro/Details/5

        public ActionResult Details(string isbn)
        {
            return View(gLivro.Obter(isbn));
        }

        //
        // GET: /Livro/Create

        public ActionResult Create()
        {
            ViewBag.IdEditora = new SelectList(gEditora.ObterTodos(), "Codigo", "Nome");
            return View();
        } 

        //
        // POST: /Livro/Create

        [HttpPost]
        public ActionResult Create(Livro livroModel)
        {
            if (ModelState.IsValid)
            {
                gLivro.Inserir(livroModel);
                return RedirectToAction("Index");
            }

            return View(livroModel);
        }
        
        //
        // GET: /Livro/Edit/5
 
        public ActionResult Edit(string id)
        {
            Livro livroModel = gLivro.Obter(id.ToString());
            ViewBag.IdEditora = new SelectList(gEditora.ObterTodos(), "Codigo", "Nome", livroModel.IdEditora);
            return View(livroModel);
        }

        //
        // POST: /Livro/Edit/5

        [HttpPost]
        public ActionResult Edit(Livro livroModel)
        {
            if (ModelState.IsValid)
            {
                gLivro.Editar(livroModel);
                return RedirectToAction("Index");
            }
            return View(livroModel);
        }

        //
        // GET: /Livro/Delete/5
 
        public ActionResult Delete(string isbn)
        {
            Livro livroModel = gLivro.Obter(isbn);
            return View(livroModel);
        }

        //
        // POST: /Livro/Delete/5

        [HttpPost]
        public ActionResult Delete(string isbn, Livro livroModel)
        {
            gLivro.Remover(isbn);
            return RedirectToAction("Index");
        }
    }
}
